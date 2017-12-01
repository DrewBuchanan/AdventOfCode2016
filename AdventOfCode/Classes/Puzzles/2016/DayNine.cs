using System;

namespace AdventOfCode.Puzzles
{
	public class DayNine
	{
		string input;

		public DayNine ()
		{
			input = System.IO.File.ReadAllText ("../../Inputs/Day09Input.txt").Replace ("\r", "");
		}

		/// <summary>
		/// Decompresses input while not recursing through markers
		/// </summary>
		/// <returns>Decompressed input</returns>
		public long PartOne ()
		{
			long length = Decompress (input, false);
			return length;
		}

		/// <summary>
		/// Decompresses input while recursing through markers
		/// </summary>
		/// <returns>Decompressed input</returns>
		public long PartTwo ()
		{
			long length = Decompress (input, true);
			return length;
		}

		/// <summary>
		/// Iterates over input and processes markers to find length of decompressed input
		/// </summary>
		/// <param name="input">input file to process</param>
		/// <param name="recurse">should we recursively process markers</param>
		/// <returns>Decompressed input length</returns>
		private long Decompress (string input, bool recurse)
		{
			long length = 0;

			for (var index = 0; index < input.Length; ++index)
			{

				if (input [index].Equals ('('))
				{
					var formula = input.Substring (index + 1, (input.IndexOf (')', index) - 1) - index).Split ('x');
					var numberOfCharacters = Convert.ToInt32 (formula [0]);
					var times = Convert.ToInt32 (formula [1]);
					var endOfString = input.IndexOf (')', index) + numberOfCharacters;
					string chunk = input.Substring (input.IndexOf (')', index) + 1, numberOfCharacters);

					if (chunk.Contains ("(") && recurse)
					{
						length += (times * Decompress (chunk, true));
					}
					else
					{
						length += (numberOfCharacters * times);
					}

					index = endOfString;
				}
				else
				{
					++length;
				}
			}

			return length;
		}
	}
}
