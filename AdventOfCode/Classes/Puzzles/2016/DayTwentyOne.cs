using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	public class DayTwentyOne
	{
		const string TEST_PASSWORD = "abcde";
		const string PUZZLE_ONE_PASSWORD = "abcdefgh";
		const string PUZZLE_TWO_PASSWORD = "fbgdceah";

		/// <summary>
		/// Scrambles TEST_PASSWORD based on test input's instructions
		/// </summary>
		/// <returns>the scrambled password</returns>
		public string Test ()
		{
			StringBuilder password = new StringBuilder (TEST_PASSWORD);
			string [] operations = System.IO.File.ReadAllLines ("../../Inputs/Day21TestInput.txt");
			password = ProcessOperations (password, operations);
			return password.ToString ();
		}

		/// <summary>
		/// Scrambles PUZZLE_ONE_PASSWORD based on input's instructions
		/// </summary>
		/// <returns>the scrambled password</returns>
		public string PartOne ()
		{
			StringBuilder password = new StringBuilder (PUZZLE_ONE_PASSWORD);
			string [] operations = System.IO.File.ReadAllLines ("../../Inputs/Day21Input.txt");
			password = ProcessOperations (password, operations);
			return password.ToString ();
		}

		/// <summary>
		/// Unscrambles PUZZLE_TWO_PASSWORD based on input's instructions
		/// </summary>
		/// <returns>the unscrambled password</returns>
		public string PartTwo ()
		{
			StringBuilder password = new StringBuilder (PUZZLE_TWO_PASSWORD);
			string [] operations = System.IO.File.ReadAllLines ("../../Inputs/Day21Input.txt");
			password = ReverseOperations (password, operations);
			return password.ToString ();
		}

		/// <summary>
		/// Performs operations on password
		/// </summary>
		/// <param name="password">StringBuilder containing password</param>
		/// <param name="operations">string array of operations to perform</param>
		/// <returns>a StringBuilder with the scrambled password</returns>
		static StringBuilder ProcessOperations (StringBuilder password, string [] operations)
		{
			for (int i = 0; i < operations.Length; i++)
			{
				string [] split = operations [i].Split (' ');
				if (operations [i].Contains ("swap position"))
					password = SwapPosition (password, int.Parse (split [2]), int.Parse (split [5]));
				else if (operations [i].Contains ("swap letter"))
				{
					int x = password.ToString ().IndexOf (split [2]);
					int y = password.ToString ().IndexOf (split [5]);
					password = SwapLetter (password, x, y);
				}
				else if (operations [i].Contains ("reverse"))
					password = Reverse (password, int.Parse (split [2]), int.Parse (split [4]));
				else if (operations [i].Contains ("rotate based"))
				{
					int index = password.ToString ().IndexOf (split [6] [0]);
					int x = index;
					if (x >= 4)
						x++;
					x++;
					password = RotateRight (password, x);
				}
				else if (operations [i].Contains ("rotate left"))
					password = RotateLeft (password, int.Parse (split [2]));
				else if (operations [i].Contains ("rotate right"))
					password = RotateRight (password, int.Parse (split [2]));
				else if (operations [i].Contains ("move"))
					password = Move (password, int.Parse (split [2]), int.Parse (split [5]));
			}
			return password;
		}
		/// <summary>
		/// Performs opposite of operations on password
		/// </summary>
		/// <param name="password">StringBuilder containing password</param>
		/// <param name="operations">string array of operations</param>
		/// <returns>a StringBuilder with the unscrambled password</returns>
		static StringBuilder ReverseOperations (StringBuilder password, string [] operations)
		{
			for (int i = operations.Length - 1; i >= 0; i--)
			{
				string [] split = operations [i].Split (' ');
				if (operations [i].Contains ("swap position"))
					password = SwapPosition (password, int.Parse (split [2]), int.Parse (split [5]));
				else if (operations [i].Contains ("swap letter"))
				{
					int x = password.ToString ().IndexOf (split [2]);
					int y = password.ToString ().IndexOf (split [5]);
					password = SwapLetter (password, x, y);
				}
				else if (operations [i].Contains ("reverse"))
					password = Reverse (password, int.Parse (split [2]), int.Parse (split [4]));
				else if (operations [i].Contains ("rotate based"))
				{
					int index = password.ToString ().IndexOf (split [6] [0]);
					int x = 0;
					x = index / 2 + (index % 2 == 1 || index == 0 ? 1 : 5);
					password = RotateLeft (password, x);
				}
				else if (operations [i].Contains ("rotate left"))
					password = RotateRight (password, int.Parse (split [2]));
				else if (operations [i].Contains ("rotate right"))
					password = RotateLeft (password, int.Parse (split [2]));
				else if (operations [i].Contains ("move"))
					password = Move (password, int.Parse (split [5]), int.Parse (split [2]));
			}
			return password;
		}
		/// <summary>
		/// Moves the character at position x to position y
		/// </summary>
		/// <param name="password">StringBuilder with password</param>
		/// <param name="x">position of character</param>
		/// <param name="y">target position</param>
		/// <returns>updated password</returns>
		static StringBuilder Move (StringBuilder password, int x, int y)
		{
			char charX = password [x];
			password.Remove (x, 1);
			password.Insert (y, charX);
			return password;
		}
		/// <summary>
		/// Rotates password left steps times
		/// </summary>
		/// <param name="password">StringBuilder with password</param>
		/// <param name="steps">number of times to rotate</param>
		/// <returns>updated password StringBuilder</returns>
		static StringBuilder RotateLeft (StringBuilder password, int steps)
		{
			for (int j = 0; j < steps; j++)
			{
				char first = password [0];
				password.Remove (0, 1);
				password.Append (first);
			}
			return password;
		}
		/// <summary>
		/// Rotates password right steps times
		/// </summary>
		/// <param name="password">StringBuilder with password</param>
		/// <param name="steps">number of times to rotate</param>
		/// <returns>updated password StringBuilder</returns>
		static StringBuilder RotateRight (StringBuilder password, int steps)
		{
			for (int j = 0; j < steps; j++)
			{
				char last = password [password.Length - 1];
				password.Remove (password.Length - 1, 1);
				password.Insert (0, last);
			}
			return password;
		}
		/// <summary>
		/// Reverses the characters of password between indices x and y
		/// </summary>
		/// <param name="password">StringBuilder with password</param>
		/// <param name="x">start index</param>
		/// <param name="y">end index</param>
		/// <returns>updated password StringBuilder</returns>
		static StringBuilder Reverse (StringBuilder password, int x, int y)
		{
			string reverse = password.ToString ().Substring (x, y - x + 1);
			password.Remove (x, y - x + 1);
			for (int j = 0; j < reverse.Length; j++)
				password.Insert (x, reverse [j]);
			return password;
		}
		/// <summary>
		/// Swaps the positions of the letters x and y
		/// </summary>
		/// <param name="password">StringBuilder with password</param>
		/// <param name="x">character to switch</param>
		/// <param name="y">other character to switch</param>
		/// <returns>updated passord StringBuilder</returns>
		static StringBuilder SwapLetter (StringBuilder password, int x, int y)
		{
			char temp = password [x];
			password [x] = password [y];
			password [y] = temp;
			return password;
		}
		/// <summary>
		/// Swaps the letters at indices x and y
		/// </summary>
		/// <param name="password">StringBuilder with password</param>
		/// <param name="x">index to swap</param>
		/// <param name="y">other index to swap</param>
		/// <returns>updated password StringBuilder</returns>
		static StringBuilder SwapPosition (StringBuilder password, int x, int y)
		{
			char temp = password [x];
			password [x] = password [y];
			password [y] = temp;
			return password;
		}
	}
}
