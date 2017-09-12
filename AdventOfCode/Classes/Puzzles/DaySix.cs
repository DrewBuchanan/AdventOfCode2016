using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles
{
	public class DaySix
	{
		string [] input;
		string [] columns;
		string message;

		/// <summary>
		/// Initializes input into columns
		/// </summary>
		public DaySix ()
		{
			input = System.IO.File.ReadAllLines ("../../Inputs/Day06Input.txt");
			columns = new string [input [0].Length];
			message = "";
			for (int i = 0; i < columns.Length; i++)
			{
				columns [i] = "";
			}
			for (int i = 0; i < input.Length; i++)
			{
				for (int j = 0; j < input [i].Length; j++)
				{
					columns [j] += input [i] [j];
				}
			}
		}

		/// <summary>
		/// Returns message constructed from least frequent character in each column in columns
		/// </summary>
		/// <returns></returns>
		public string PartOne ()
		{
			for (int i = 0; i < columns.Length; i++)
			{
				message += AlphaFreqDict.GetMostFrequentCharacter (columns [i]);
			}
			return message;
		}

		/// <summary>
		/// Returns message constructed from least frequent character in each column in columns
		/// </summary>
		/// <returns></returns>
		public string PartTwo ()
		{
			for (int i = 0; i < columns.Length; i++)
			{
				message += AlphaFreqDict.GetLeastFrequentCharacter (columns [i]);
			}
			return message;
		}
	}
}
