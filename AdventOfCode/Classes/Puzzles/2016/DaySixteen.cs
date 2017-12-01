using System;
using System.Linq;
using System.Text;

namespace AdventOfCode.Puzzles
{
	// TODO: Comment this class
	public class DaySixteen
	{
		string testInput = "10000";
		int testLength = 20;

		string puzzleInput = "00101000101111010";
		int puzzleLength = 272;
		int puzzleTwoLength = 35651584;

		public string PartOneTest ()
		{
			string data = GenerateRandomData (testInput, testLength);
			string checksum = GenerateChecksum (data);
			return checksum;
		}

		public string PartOne ()
		{
			string data = GenerateRandomData (puzzleInput, puzzleLength);
			string checksum = GenerateChecksum (data);
			return checksum;
		}

		public string PartTwo ()
		{
			string data = GenerateRandomData (puzzleInput, puzzleTwoLength);
			Console.WriteLine ("Data Generated");
			string checksum = GenerateChecksum (data);
			return checksum;
		}

		string GenerateRandomData (string initialState, int length)
		{
			string data = initialState;
			while (data.Length < length)
			{
				data = Dragon (data);
			}
			data = data.Substring (0, length);
			return data;
		}

		public static string Dragon (string data)
		{
			string a = data;
			string b = new string (a.Reverse ().ToArray ()).Replace ('0', '2').Replace ('1', '0').Replace ('2', '1');
			return a + '0' + b;
		}

		public static string GenerateChecksum (string input)
		{
			string data = input;
			StringBuilder checksum = new StringBuilder ();
			while (data.Length % 2 == 0)
			{
				for (int i = 0; i < data.Length; i += 2)
				{
					string pair = data.Substring (i, Math.Min (2, data.Length - i));
					if (pair [0] == pair [1])
						checksum.Append ('1');
					else
						checksum.Append ('0');
				}
				data = checksum.ToString ();
				checksum.Clear ();
			}
			return data;
		}
	}
}
