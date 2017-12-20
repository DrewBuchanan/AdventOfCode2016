using System.Drawing;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles._2017
{
	public class DayNineteen
	{
		const string testInputFilePath = "../../Inputs/2017/Day19TestInput.txt";
		const string puzzleInputFilePath = "../../Inputs/2017/Day19Input.txt";

		Point position;
		string [] rows;
		Direction direction;
		string letters;
		int steps;

		public DayNineteen (string file)
		{
			rows = System.IO.File.ReadAllLines (file);
			position = new Point ();
			direction = Direction.South;
			letters = "";
			position = new Point (0, 0);
			steps = 1;
		}

		public static DayNineteen GetTest ()
		{
			return new DayNineteen (testInputFilePath);
		}

		public static DayNineteen GetPuzzle ()
		{
			return new DayNineteen (puzzleInputFilePath);
		}

		public string GetLetters ()
		{
			SetStartingPosition ();
			while (UpdatePosition ())
			{
			}
			return letters;
		}

		public int GetSteps ()
		{
			SetStartingPosition ();
			while (UpdatePosition ())
			{
				steps++;
			}
			return steps;
		}

		private void SetStartingPosition ()
		{
			position.X = rows [0].IndexOf ('|');
		}

		private bool UpdatePosition ()
		{
			switch (direction)
			{
				case Direction.North:
					position.Y--;
					break;
				case Direction.South:
					position.Y++;
					break;
				case Direction.West:
					position.X--;
					break;
				case Direction.East:
					position.X++;
					break;
			}

			if (char.IsLetter (rows [position.Y] [position.X]))
				letters += rows [position.Y] [position.X];

			else if (rows [position.Y] [position.X] == '+')
			{
				// Change direction if need be
				switch (direction)
				{
					case Direction.South:
						if (position.Y + 1 > rows.Length - 1 || rows [position.Y + 1] [position.X] != '|')
						{
							if (rows [position.Y] [position.X + 1] != ' ')
								direction = Direction.East;
							else if (rows [position.Y] [position.X - 1] != ' ')
								direction = Direction.West;
							else
								return false;
						}
						break;
					case Direction.East:
						if (position.X + 1 > rows [0].Length - 1 || rows [position.Y] [position.X + 1] != '-')
						{
							if (rows [position.Y - 1] [position.X] != ' ')
								direction = Direction.North;
							else if (rows [position.Y + 1] [position.X] != ' ')
								direction = Direction.South;
							else
								return false;
						}
						break;
					case Direction.North:
						if (position.Y - 1 > 0 || rows [position.Y - 1] [position.X] != '|')
						{
							if (rows [position.Y] [position.X + 1] != ' ')
								direction = Direction.East;
							else if (rows [position.Y] [position.X - 1] != ' ')
								direction = Direction.West;
							else
								return false;
						}
						break;
					case Direction.West:
						if (position.X - 1 > 0 || rows [position.Y] [position.X - 1] != '-')
						{
							if (rows [position.Y - 1] [position.X] != ' ')
								direction = Direction.North;
							else if (rows [position.Y + 1] [position.X] != ' ')
								direction = Direction.South;
							else
								return false;
						}
						break;
				}
			}

			else if (rows [position.Y] [position.X] == ' ')
				return false;
			return true;
		}
	}
}
