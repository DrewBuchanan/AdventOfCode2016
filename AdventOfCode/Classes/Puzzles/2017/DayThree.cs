using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode.Puzzles._2017
{
	public class DayThree
	{
		static int puzzleInput = 325489;

		Dictionary<Point, int> _grid;
		public void Set (Point key, int value)
		{
			_grid [key] = value;
		}
		public int Get (Point key)
		{
			if (_grid.ContainsKey (key))
				return _grid [key];
			return 0;
		}
		public int GetSumOfSurrounding (Point key)
		{
			int sum = 0;
			for (int i = -1; i < 2; i++)
				for (int j = -1; j < 2; j++)
					sum += Get (new Point (key.X + i, key.Y + j));
			return sum;
		}

		public DayThree ()
		{
			_grid = new Dictionary<Point, int> ();
		}

		public static int PartOne ()
		{
			return ManhattanDistanceFromOrigin (SpiralToEuclidean (puzzleInput));
		}

		public int PartTwo ()
		{
			Point current = Point.Empty;
			Set (Point.Empty, 1);
			int currentSpiral = -1;
			int spiralWidth = 3;
			while (true)
			{
				current.X++;
				Set (current, GetSumOfSurrounding (current));
				if (_grid [current] > puzzleInput)
					return _grid [current];

				for (int i = 0; i < spiralWidth - 2; i++)
				{
					current.Y++;
					Set (current, GetSumOfSurrounding (current));
					if (_grid [current] > puzzleInput)
						return _grid [current];
				}

				for (int i = 0; i < spiralWidth - 1; i++)
				{
					current.X--;
					Set (current, GetSumOfSurrounding (current));
					if (_grid [current] > puzzleInput)
						return _grid [current];
				}

				for (int i = 0; i < spiralWidth - 1; i++)
				{
					current.Y--;
					Set (current, GetSumOfSurrounding (current));
					if (_grid [current] > puzzleInput)
						return _grid [current];
				}

				for (int i = 0; i < spiralWidth - 1; i++)
				{
					current.X++;
					Set (current, GetSumOfSurrounding (current));
					if (_grid [current] > puzzleInput)
						return _grid [current];
				}

				spiralWidth += 2;
			}
			return currentSpiral;
		}

		public static Point SpiralToEuclidean (int spiralPosition)
		{
			Point euclidean = new Point (0, 0);
			int currentSpiral = 1;
			int spiralWidth = 3;
			while (currentSpiral < spiralPosition)
			{
				int start = Math.Min (1, spiralPosition - currentSpiral);
				currentSpiral += start;
				euclidean.X += start;

				int up = Math.Min (spiralWidth - 2, spiralPosition - currentSpiral);
				currentSpiral += up;
				euclidean.Y += up;

				int left = Math.Min (spiralWidth - 1, spiralPosition - currentSpiral);
				currentSpiral += left;
				euclidean.X -= left;

				int down = Math.Min (spiralWidth - 1, spiralPosition - currentSpiral);
				currentSpiral += down;
				euclidean.Y -= down;

				int right = Math.Min (spiralWidth - 1, spiralPosition - currentSpiral);
				currentSpiral += right;
				euclidean.X += right;

				spiralWidth += 2;
			}
			return euclidean;
		}

		public static int ManhattanDistanceFromOrigin (Point euclideanPosition)
		{
			return Math.Abs (euclideanPosition.X) + Math.Abs (euclideanPosition.Y);
		}
	}
}
