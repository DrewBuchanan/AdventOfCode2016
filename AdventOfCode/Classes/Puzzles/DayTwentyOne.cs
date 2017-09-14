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

		public string Test ()
		{
			StringBuilder password = new StringBuilder (TEST_PASSWORD);
			string [] operations = System.IO.File.ReadAllLines ("../../Inputs/Day21TestInput.txt");
			password = ProcessOperations (password, operations);
			return password.ToString ();
		}

		public string PartOne ()
		{
			StringBuilder password = new StringBuilder (PUZZLE_ONE_PASSWORD);
			string [] operations = System.IO.File.ReadAllLines ("../../Inputs/Day21Input.txt");
			password = ProcessOperations (password, operations);
			return password.ToString ();
		}

		public string PartTwo ()
		{
			StringBuilder password = new StringBuilder (PUZZLE_TWO_PASSWORD);
			string [] operations = System.IO.File.ReadAllLines ("../../Inputs/Day21Input.txt");
			password = ReverseOperations (password, operations);
			return password.ToString ();
		}

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
		static StringBuilder Move (StringBuilder password, int x, int y)
		{
			char charX = password [x];
			password.Remove (x, 1);
			password.Insert (y, charX);
			return password;
		}
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
		static StringBuilder Reverse (StringBuilder password, int x, int y)
		{
			string reverse = password.ToString ().Substring (x, y - x + 1);
			password.Remove (x, y - x + 1);
			for (int j = 0; j < reverse.Length; j++)
				password.Insert (x, reverse [j]);
			return password;
		}
		static StringBuilder SwapLetter (StringBuilder password, int x, int y)
		{
			char temp = password [x];
			password [x] = password [y];
			password [y] = temp;
			return password;
		}
		static StringBuilder SwapPosition (StringBuilder password, int x, int y)
		{
			char temp = password [x];
			password [x] = password [y];
			password [y] = temp;
			return password;
		}
	}
}
