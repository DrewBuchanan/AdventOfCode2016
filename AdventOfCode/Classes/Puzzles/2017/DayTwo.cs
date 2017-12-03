using System;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTwo
	{
		int [] [] spreadsheet;

		public DayTwo ()
		{
			string [] input = System.IO.File.ReadAllLines ("../../Inputs/2017/Day02Input.txt");
			for (int i = 0; i < input.Length; i++)
			{
				input [i] = WhitespaceTrimmer.Trim (input [i]).Replace (' ', ',');
			}
			spreadsheet = new int [input.Length] [];
			for (int i = 0; i < input.Length; i++)
			{
				string [] split = input [i].Split (',');
				Console.WriteLine (split.Length);
				spreadsheet [i] = new int [split.Length];
				for (int j = 0; j < split.Length; j++)
				{
					spreadsheet [i] [j] = int.Parse (split [j]);
				}
			}
		}

		public int PartOne ()
		{
			int checksum = 0;
			for (int i = 0; i < spreadsheet.Length; i++)
				checksum += RowDiff (spreadsheet [i]);
			return checksum;
		}

		public int PartTwo ()
		{
			int checksum = 0;
			for (int i = 0; i < spreadsheet.Length; i++)
				checksum += EvenlyDivisibleWithinRow (spreadsheet [i]);
			return checksum;
		}

		private int RowDiff (int [] row)
		{
			Array.Sort (row);
			return row [row.Length - 1] - row [0];
		}

		private int EvenlyDivisibleWithinRow (int [] row)
		{
			for (int i = 0; i < row.Length - 1; i++)
				for (int j = i + 1; j < row.Length; j++)
				{
					if (row [i] > row [j] && row [i] % row [j] == 0)
						return row [i] / row [j];
					else if (row [j] > row [i] && row [j] % row [i] == 0)
						return row [j] / row [i];
				}
			throw new Exception ("Shouldn't have gotten this far");
		}
	}
}
