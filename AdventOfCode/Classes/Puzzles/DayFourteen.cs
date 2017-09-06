using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode.Puzzles
{
	// TODO: Comment this class
	public class DayFourteen
	{
		Dictionary<int, string> cachedHashes;
		string puzzleInput = "yjdafjpo";
		string testInput = "abc";
		MD5 md5;

		public int PartOneTest ()
		{
			return GetNthKeyIndex (testInput, 64);
		}

		public int PartOne ()
		{
			return GetNthKeyIndex (puzzleInput, 64);
		}

		public int PartTwoTest ()
		{
			return GetNthKeyIndex (testInput, 64, true);
		}

		public int PartTwo ()
		{
			return GetNthKeyIndex (puzzleInput, 64, true);
		}

		int GetNthKeyIndex (string stream, int n, bool stretch = false)
		{
			cachedHashes = new Dictionary<int, string> ();
			md5 = MD5.Create ();
			int keysFound = 0;
			int index = 0;
			while (keysFound < n)
			{
				Console.WriteLine ("Keys: " + keysFound + " || Index : " + index);
				string hashString;
				if (cachedHashes.ContainsKey (index))
					hashString = cachedHashes [index];
				else
				{
					hashString = GenerateHash (stream + index.ToString (), stretch);
					cachedHashes.Add (index, hashString);
				}
				for (int i = 0; i < hashString.Length - 2; i++)
				{
					if (hashString [i] == hashString [i + 1] && hashString [i] == hashString [i + 2])
					{
						bool keyFound = false;
						for (int j = index + 1; j < (index + 1001); j++)
						{
							string newHashString;
							if (cachedHashes.ContainsKey (j))
								newHashString = cachedHashes [j];
							else
							{
								newHashString = GenerateHash (stream + j.ToString (), stretch);
								cachedHashes.Add (j, newHashString);
							}
							for (int k = 0; k < newHashString.Length - 5; k++)
								if (hashString [i] == newHashString [k] && hashString [i] == newHashString [k + 1] && hashString [i] == newHashString [k + 2] &&
									hashString [i] == newHashString [k + 3] && hashString [i] == newHashString [k + 4])
								{
									keysFound++;
									keyFound = true;
									break;
								}
							if (keyFound)
								break;
						}
						break;
					}
				}
				index++;
			}
			return index - 1;
		}

		string GenerateHash (string input, bool stretch)
		{
			byte [] inputHash = Encoding.ASCII.GetBytes (input);
			byte [] hashBytes = md5.ComputeHash (inputHash);
			string hashString = "";
			for (int i = 0; i < hashBytes.Length; i++)
				hashString += hashBytes [i].ToString ("X2").ToLower ();
			if (stretch)
				for (int i = 0; i < 2016; i++)
					hashString = GenerateHash (hashString, false);
			return hashString;
		}
	}
}
