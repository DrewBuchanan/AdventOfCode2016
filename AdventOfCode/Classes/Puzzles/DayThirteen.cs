using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles
{
	public class DayThirteen
	{
		int favoriteNumber;
		bool [,] grid;

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
