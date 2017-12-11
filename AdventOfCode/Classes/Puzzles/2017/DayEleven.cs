using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				switch (steps [i].ToLower ())
				{
					case "n":
						currentPosition.Y -= 1;
						break;
					case "s":
						currentPosition.Y += 1;
						break;
					case "nw":
						currentPosition.X -= 1;
						break;
					case "se":
						currentPosition.X += 1;
						break;
					case "ne":
						currentPosition.X += 1;
						currentPosition.Y -= 1;
						break;
					case "sw":
						currentPosition.X -= 1;
						currentPosition.Y += 1;
						break;
					default:
						throw new InvalidOperationException (steps [i] + " is not valid");
				}
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
