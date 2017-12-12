using System;
using System.Drawing;

namespace AdventOfCode.Puzzles._2017
{
	public class DayEleven
	{
		string [] steps;
		Point currentPosition;
		int maxDistance;

		public DayEleven ()
		{
			maxDistance = 0;
			steps = System.IO.File.ReadAllText ("../../Inputs/2017/Day11Input.txt").Split (',');
			currentPosition = new Point ();
			Process ();
		}

		public DayEleven (string input)
		{
			maxDistance = 0;
			steps = input.Split (',');
			currentPosition = new Point ();
			Process ();
		}

		public int PartOne ()
		{
			return GetDistanceFromOrigin ();
		}

		public int PartTwo ()
		{
			return maxDistance;
		}

		void Process ()
		{
			for (int i = 0; i < steps.Length; i++)
			{
				if (steps [i].Contains ("n") && !steps [i].Contains ("w"))
					currentPosition.Y--;
				if (steps [i].Contains ("s") && !steps [i].Contains ("e"))
					currentPosition.Y++;
				if (steps [i].Contains ("w"))
					currentPosition.X--;
				if (steps [i].Contains ("e"))
					currentPosition.X++;
				int dist = GetDistanceFromOrigin ();
				if (dist > maxDistance)
					maxDistance = dist;
			}
		}

		int GetDistanceFromOrigin ()
		{
			return (Math.Abs (0 - currentPosition.X) +
				Math.Abs (0 + 0 - currentPosition.X - currentPosition.Y) +
				Math.Abs (0 - currentPosition.Y)) / 2;
		}
	}
}
