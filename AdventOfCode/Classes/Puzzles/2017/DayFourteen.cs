using System;
using System.Linq;

namespace AdventOfCode.Puzzles._2017
{
	public class DayFourteen
	{
		public const string puzzleInput = "oundnydw";
		public const string testInput = "flqrgnkx";

		public static int PartOneTest ()
		{
			return GetUsedSquares (testInput);
		}

		public static int PartOne ()
		{
			return GetUsedSquares (puzzleInput);
		}

		public static int PartTwoTest ()
		{
			return GetNumberOfRegions (testInput);
		}

		public static int PartTwo ()
		{
			return GetNumberOfRegions (puzzleInput);
		}

		private static int GetNumberOfRegions (string input)
		{
			int [,] grid = new int [128, 128];
			int regionIndicator = 1;
			for (int i = 0; i < 128; i++)
			{
				string key = input + "-" + i.ToString ();
				Utilities.KnotHash knotHash = new Utilities.KnotHash (input);
				string hash = knotHash.GenerateHash ();
				string binary = HexToBinary (hash);
				for (int j = 0; j < 128; j++)
					grid [i, j] = binary [j] == '0' ? -1 : 0;
			}
			for (int i = 0; i < 128; i++)
			{
				for (int j = 0; j < 128; j++)
				{
					if (grid [i, j] == 0)
					{
						FloodFill (grid, i, j, 0, regionIndicator);
						regionIndicator++;
						continue;
					}
				}
			}
			return regionIndicator - 1;
		}

		private static int [,] FloodFill (int [,] grid, int x, int y, int targetColor, int replacementColor)
		{
			if (targetColor == replacementColor)
				return grid;
			if (grid [x, y] != targetColor)
				return grid;
			grid [x, y] = replacementColor;
			if (x > 0)
				grid = FloodFill (grid, x - 1, y, targetColor, replacementColor);
			if (x < 127)
				grid = FloodFill (grid, x + 1, y, targetColor, replacementColor);
			if (y > 0)
				grid = FloodFill (grid, x, y - 1, targetColor, replacementColor);
			if (y < 127)
				grid = FloodFill (grid, x, y + 1, targetColor, replacementColor);

			return grid;
		}

		private static int GetUsedSquares (string input)
		{
			int used = 0;
			for (int i = 0; i < 128; i++)
			{
				string key = input + "-" + i.ToString ();
				Utilities.KnotHash knotHash = new Utilities.KnotHash (input);
				string hash = knotHash.GenerateHash ();
				string binary = HexToBinary (hash);
				used += binary.Count (x => x == '1');
			}
			return used;
		}

		private static string HexToBinary (string hex)
		{
			string to = "";
			for (int i = 0; i < hex.Length; i++)
				to += Convert.ToString (Convert.ToInt32 (hex [i].ToString (), 16), 2).PadLeft (4, '0');
			return to;
		}
	}
}
