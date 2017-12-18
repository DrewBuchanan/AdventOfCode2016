using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DaySeventeen
	{
		const int puzzleInput = 301;
		const int testInput = 3;

		int steps;
		int currentPosition;
		List<long> buffer;

		public DaySeventeen ()
		{
			steps = puzzleInput;
			//steps = testInput;
			currentPosition = 0;
			buffer = new List<long> ();
		}

		public long PartOne ()
		{
			PopulateBuffer (2017);
			return buffer [(buffer.IndexOf (2017) + 1)];
		}

		public long PartTwo ()
		{
			long rtrn = 0;
			long insertedAt = 0;
			for (int i = 1; i <= 50000000; i++)
			{
				insertedAt = (insertedAt + steps) % i + 1;
				if (insertedAt == 1)
					rtrn = i;
			}
			return rtrn;
		}

		private void PopulateBuffer (int toFill)
		{
			buffer.Add (0);
			for (long i = 1; i <= toFill; i++)
			{
				currentPosition = (currentPosition + steps) % buffer.Count;
				buffer.Insert (currentPosition + 1, i);
				currentPosition = buffer.IndexOf (i);
			}
		}
	}
}
