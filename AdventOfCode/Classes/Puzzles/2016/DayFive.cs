using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace AdventOfCode.Puzzles
{
	public class DayFive
	{
		readonly string positions = "01234567";
		readonly string puzzleInput = "ffykfhsq";

		StringBuilder password;
		StringBuilder hashBuilder;
		MD5 md5;

		uint index;
		int charactersFound;

		public DayFive ()
		{
			password = new StringBuilder ("--------");
			hashBuilder = new StringBuilder ();
			md5 = MD5.Create ();

			index = 0;
			charactersFound = 0;
		}

		/// <summary>
		/// Generates a password sequentially by finding MD5 hashes of an increasing index
		/// </summary>
		/// <returns>Password</returns>
		public string PartOne ()
		{
			ConsoleOutput (false);

			while (charactersFound < 8)
			{
				byte [] inputBytes = Encoding.ASCII.GetBytes (puzzleInput + (index.ToString ()));
				byte [] hashBytes = md5.ComputeHash (inputBytes);

				for (int i = 0; i < hashBytes.Length; i++)
					hashBuilder.Append (hashBytes [i].ToString ("X2"));
				string hash = hashBuilder.ToString ();
				if (AreFirstFiveCharsZero (hash))
				{
					password [charactersFound] = hash [5];
					charactersFound++;
					ConsoleOutput (true);
				}
				hashBuilder.Clear ();
				index++;
			}
			return password.ToString ();
		}

		/// <summary>
		/// Generates a password based on first 6 characters of MD5 hashes of an increasing index
		/// </summary>
		/// <returns></returns>
		public string PartTwo ()
		{
			ConsoleOutput (false);

			while (charactersFound < 8)
			{
				byte [] inputBytes = Encoding.ASCII.GetBytes (puzzleInput + (index.ToString ()));
				byte [] hashBytes = md5.ComputeHash (inputBytes);

				for (int i = 0; i < hashBytes.Length; i++)
					hashBuilder.Append (hashBytes [i].ToString ("X2"));
				string hash = hashBuilder.ToString ();
				if (AreFirstFiveCharsZero (hash) && positions.Contains (hash [5]) && password [int.Parse (hash [5].ToString ())] == '-')
				{
					charactersFound++;
					password [int.Parse (hash [5].ToString ())] = hash [6];
					ConsoleOutput (true);
				}
				hashBuilder.Clear ();
				index++;
			}
			return password.ToString ();
		}

		/// <summary>
		/// Prints the current decryption state of password with optional beeps
		/// </summary>
		/// <param name="beep">produces a beep sound if true, does not if false</param>
		void ConsoleOutput (bool beep)
		{
			Console.SetCursorPosition (0, 0);
			Console.Write ("Password: " + password);
			if (beep)
				Console.Beep ();
		}

		/// <summary>
		/// Determines if the first 5 characters of hash are all 0
		/// </summary>
		/// <param name="hash">the hash</param>
		/// <returns>true if first 5 chars are 0, false if not</returns>
		bool AreFirstFiveCharsZero (string hash)
		{
			return (hash.Length > 4 &&
				hash [0] == '0' &&
				hash [1] == '0' &&
				hash [2] == '0' &&
				hash [3] == '0' &&
				hash [4] == '0');
		}
	}
}
