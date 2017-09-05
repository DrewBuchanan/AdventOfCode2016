using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles
{
	public class DayThirteen
	{
		int favoriteNumber;
		bool [,] grid;
		ConsoleColor [,] coloredMap;

		public List<Vector2> Test ()
		{
			favoriteNumber = 10;
			int targetX = 7;
			int targetY = 4;
			grid = new bool [targetX + 3, targetY + 3];
			for (int i = 0; i < grid.GetLength (0); i++)
				for (int j = 0; j < grid.GetLength (1); j++)
					grid [i, j] = IsWalkable (i, j);
			Draw ();

			SearchParameters searchParams = new SearchParameters (new Vector2 (1, 1), new Vector2 (targetX, targetY), grid);
			PathFinder pathFinder = new PathFinder (searchParams);
			List<Vector2> path = pathFinder.FindPath ();
			return path;
		}

		public List<Vector2> PartOne ()
		{
			favoriteNumber = 1364;
			int targetX = 31;
			int targetY = 39;
			grid = new bool [targetX + 3, targetY + 3];
			for (int i = 0; i < grid.GetLength (0); i++)
				for (int j = 0; j < grid.GetLength (1); j++)
					grid [i, j] = IsWalkable (i, j);
			Draw ();

			SearchParameters searchParams = new SearchParameters (new Vector2 (1, 1), new Vector2 (targetX, targetY), grid);
			PathFinder pathFinder = new PathFinder (searchParams);
			List<Vector2> path = pathFinder.FindPath ();
			return path;
		}

		private static Size [] dirs;
		private static Dictionary<Point, int> shortest = new Dictionary<Point, int> ();

		public Dictionary<Point, int> PartTwo ()
		{
			int width = 150, height = 150;
			var map = new char [width, height];

			for (int y = 0; y < width; y++)
			{
				for (int x = 0; x < height; x++)
				{
					var e = x * x + 3 * x + 2 * x * y + y + y * y + 1364;

					var open = (Convert.ToString (e, 2).ToArray ().Count (c => c == '1') & 1) == 0;

					map [y, x] = open ? '.' : '#';
				}
			}

			dirs = new [] { new Size (-1, 0), new Size (1, 0), new Size (0, -1), new Size (0, 1) };

			var target = new Point (31, 39);
			var start = new Point (1, 1);

			int count = -1;
			Find (map, start, target, count);

			//Console.WriteLine("Shortest:" + shortest[target]);
			Console.WriteLine ("Locations:" + shortest.Count);
			return shortest;
		}

		private static void Find (char [,] map, Point current, Point target, int numSteps)
		{
			++numSteps;

			if (numSteps >= 50)
			{
				shortest [current] = numSteps;
				return;
			}

			//if (current == target)
			//{
			//  shortest[current] = numSteps;
			//  return;
			//}

			if (shortest.ContainsKey (current))
			{
				if (shortest [current] < numSteps)
				{
					Console.WriteLine ("dead end:" + shortest [current]);
					return;
				}
				shortest [current] = numSteps;
			}
			else
				shortest.Add (current, numSteps);

			if (current == new Point (1, 1))
				numSteps = 0;

			for (int i = 0; i < 4; i++)
			{
				var nm = Point.Add (current, dirs [i]);

				if (nm.X >= 0 && nm.Y >= 0 && map [nm.Y, nm.X] == '.')
				{
					Find (map, nm, target, numSteps);
				}
			}
		}

		IEnumerable<Vector2> GetAdjacentLocations (Vector2 location)
		{
			return new Vector2 []
			{
					new Vector2(location.x - 1, location.y),
					new Vector2(location.x + 1, location.y),
					new Vector2(location.x, location.y - 1),
					new Vector2(location.x, location.y + 1)
			};
		}

		void Draw ()
		{
			for (int j = 0; j < grid.GetLength (1); j++)
			{
				for (int i = 0; i < grid.GetLength (0); i++)
				{
					Console.Write (grid [i, j] ? "." : "#");
				}
				Console.WriteLine ();
			}
		}

		bool IsWalkable (int x, int y)
		{
			int sum = (x * x + 3 * x + 2 * x * y + y + y * y) + favoriteNumber;
			string binary = Convert.ToString (sum, 2);
			int ones = 0;
			for (int i = 0; i < binary.Length; i++)
				if (binary [i] == '1')
					ones++;
			if (ones % 2 == 1)
				return false;
			return true;
		}
	}
}
