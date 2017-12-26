using System;
using System.Collections.Generic;
using AdventOfCode.Utilities;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTwentyTwo
	{
		const string puzzleInputFilePath = "../../Inputs/2017/Day22Input.txt";
		const string testInputFilePath = "../../Inputs/2017/Day22TestInput.txt";
		string [] input;

		Grid grid;
		Carrier carrier;

		public DayTwentyTwo ()
		{
			input = System.IO.File.ReadAllLines (puzzleInputFilePath);
		}

		public int PartOne ()
		{
			grid = new Grid (input, false);
			carrier = new Carrier (grid);
			for (int i = 0; i < 10000; i++)
				Burst ();
			return grid.GetInfectionsCaused ();
		}

		public int PartTwo ()
		{
			grid = new Grid (input, true);
			carrier = new Carrier (grid);
			for (int i = 0; i < 10000000; i++)
				Burst ();
			return grid.GetInfectionsCaused ();
		}

		void Burst ()
		{
			carrier.Turn ();
			carrier.Work ();
			carrier.Move ();
		}

		public class Carrier
		{
			public Point position;
			public Direction direction;
			public Grid grid;

			public Carrier (Grid grid)
			{
				position = Point.Empty;
				direction = Direction.North;
				this.grid = grid;
			}

			internal void Turn ()
			{
				Status status = grid.GetStatusAtPoint (position);
				if (status == Status.Infected)
					direction = (Direction)(((int)direction + 1) % 4);
				else if (status == Status.Clean)
					direction = (Direction)(((int)direction + 3) % 4);
				else if (status == Status.Flagged)
					direction = (Direction)(((int)direction + 2) % 4);
			}

			internal void Work ()
			{
				grid.InvertAtPoint (position);
			}

			internal void Move ()
			{
				switch (direction)
				{
					case Direction.North:
						position.Y++;
						break;
					case Direction.South:
						position.Y--;
						break;
					case Direction.West:
						position.X--;
						break;
					case Direction.East:
						position.X++;
						break;
				}
			}
		}

		public class Grid
		{
			int infectionsCaused;
			Dictionary<Point, Status> nodes;
			bool carrierIsEvolved;

			public Grid (string [] rows, bool evolve)
			{
				infectionsCaused = 0;
				nodes = new Dictionary<Point, Status> ();
				for (int i = 0; i < rows.Length; i++)
					for (int j = 0; j < rows [i].Length; j++)
					{
						Point point = new Point (-(rows [i].Length / 2) + j, (rows.Length / 2) - i);
						if (rows [i] [j] == '#')
							AddIfDoesntExist (point, Status.Infected);
						else
							AddIfDoesntExist (point);
					}
				carrierIsEvolved = evolve;
			}

			public int GetInfectionsCaused ()
			{
				return infectionsCaused;
			}

			void AddIfDoesntExist (Point point, Status status = Status.Clean)
			{
				if (!nodes.ContainsKey (point))
					nodes.Add (point, status);
			}

			public Status GetStatusAtPoint (Point point)
			{
				AddIfDoesntExist (point);
				return nodes [point];
			}

			public void InvertAtPoint (Point point)
			{
				AddIfDoesntExist (point);
				if (carrierIsEvolved)
				{
					if (nodes [point] == Status.Weakened)
						infectionsCaused++;
					nodes [point] = (Status)((int)(nodes [point] + 1) % 4);
				}
				else
				{
					if (nodes [point] == Status.Clean)
					{
						infectionsCaused++;
						nodes [point] = Status.Infected;
					}
					else
						nodes [point] = Status.Clean;
				}
			}
		}

		public enum Status
		{
			Clean,    // .
			Weakened, // W
			Infected, // #
			Flagged,  // F
		}
	}
}
