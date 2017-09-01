using System;
using System.Collections.Generic;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles
{
	public class DayOne
	{
		const char turnLeftCharacter = 'L';
		const char turnRightCharacter = 'R';

		Direction currentDirection;
		List<Vector2> visitedPositions;
		Vector2 currentPosition;

		string input;
		string [] steps;

		public DayOne ()
		{
			Reset ();
		}

		/// <summary>
		/// Loads input and initializes position tracking
		/// </summary>
		public void Reset ()
		{
			currentDirection = Direction.North;
			currentPosition = new Vector2 (0, 0);
			visitedPositions = new List<Vector2> ();

			input = System.IO.File.ReadAllText ("Day01Input.txt");
			steps = input.Replace (" ", "").Split (',');
		}

		/// <summary>
		/// Finds how many blocks away EBHQ is from a starting position of (0,0)
		/// </summary>
		/// <returns>returns an instance of DayOne.Result</returns>
		public Result PartOne ()
		{
			visitedPositions.Add (currentPosition);
			for (int i = 0; i < steps.Length; i++)
			{
				string step = steps [i];
				int numberOfSteps = int.Parse (step.Substring (1));
				Turn (step [0]);
				for (int j = 0; j < numberOfSteps; j++)
					Step ();
			}
			int difference = Math.Abs (currentPosition.x) + Math.Abs (currentPosition.y);
			return new Result (currentPosition);
		}

		/// <summary>
		/// Finds the first position we visit twice, then how far from (0,0) it is
		/// </summary>
		/// <returns>returns an instance of DayOne.Result</returns>
		public Result PartTwo ()
		{
			bool twice = false;
			visitedPositions.Add (currentPosition);
			for (int i = 0; i < steps.Length; i++)
			{
				string step = steps [i];
				int numberOfSteps = int.Parse (step.Substring (1));
				Turn (step [0]);
				for (int j = 0; j < numberOfSteps; j++)
				{
					if (Step ())
					{
						twice = true;
						break;
					}
				}
				if (twice)
					break;
			}
			int difference = Math.Abs (currentPosition.x) + Math.Abs (currentPosition.y);
			return new Result (currentPosition);
		}

		/// <summary>
		/// Changes current direction 
		/// </summary>
		/// <param name="direction">Determines which direction we should turn relative to currentDirection</param>
		public void Turn (char direction)
		{
			if (direction == turnRightCharacter)
				currentDirection = (Direction)(((int)currentDirection + 1) % 4);
			else if (direction == turnLeftCharacter)
				currentDirection = (Direction)(((int)currentDirection + 3) % 4);
			else
				throw new ArgumentException ("Must pass " + turnLeftCharacter + " or " + turnRightCharacter + " into Turn()");
		}

		/// <summary>
		/// Takes a step in currentDirection and records the new position in visitedPositions
		/// </summary>
		/// <returns>returns true if we have visited that position before</returns>
		public bool Step ()
		{
			switch (currentDirection)
			{
				case Direction.North:
					currentPosition.y++;
					break;
				case Direction.East:
					currentPosition.x++;
					break;
				case Direction.South:
					currentPosition.y--;
					break;
				case Direction.West:
					currentPosition.x--;
					break;
			}
			bool rtrn = HasVisited (currentPosition, visitedPositions);
			visitedPositions.Add (currentPosition);
			return rtrn;
		}

		/// <summary>
		/// Checks if we have visited currentPos
		/// </summary>
		/// <param name="currentPos"></param>
		/// <param name="visited"></param>
		/// <returns>returns true if we have visited currentPos, false if we haven't</returns>
		bool HasVisited (Vector2 currentPos, List<Vector2> visited)
		{
			for (int k = 0; k < visited.Count; k++)
				if (currentPos == visited [k])
					return true;
			return false;
		}

		/// <summary>
		/// Contains distance from origin and current position
		/// </summary>
		public struct Result
		{
			public int distanceFromOrigin;
			public Vector2 currentPosition;

			public Result (Vector2 currentPosition)
			{
				distanceFromOrigin = Math.Abs (currentPosition.x) + Math.Abs (currentPosition.y);
				this.currentPosition = currentPosition;
			}
		}
	}
}
