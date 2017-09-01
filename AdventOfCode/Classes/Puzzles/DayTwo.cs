using System;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles
{
	public class DayTwo
	{
		string [] directions;
		string [,] keypad;

		/// <summary>
		/// Generates a password based on a keypad and list of directions
		/// </summary>
		/// <returns>The password</returns>
		public string PartOne ()
		{
			directions = System.IO.File.ReadAllLines ("Day02Input.txt");
			keypad = PopulateKeypad (System.IO.File.ReadAllLines ("Day02Keypad1.txt"));

			Vector2 currentPosition = new Vector2 (1, 1);
			string code = GenerateCode (currentPosition);

			return code;
		}

		/// <summary>
		/// Generates a password based on a keypad and list of directions
		/// </summary>
		/// <returns>The password</returns>
		public string PartTwo ()
		{
			directions = System.IO.File.ReadAllLines ("Day02Input.txt");
			keypad = PopulateKeypad (System.IO.File.ReadAllLines ("Day02Keypad2.txt"));

			Vector2 currentPosition = new Vector2 (2, 0);
			string code = GenerateCode (currentPosition);

			return code;
		}

		/// <summary>
		/// Generates a password based on a starting position and directions
		/// </summary>
		/// <param name="startingPosition">Vector2 with starting position on keypad</param>
		/// <returns>a string containing the password</returns>
		string GenerateCode (Vector2 startingPosition)
		{
			string code = "";
			for (int i = 0; i < directions.Length; i++)
			{
				for (int j = 0; j < directions [i].Length; j++)
				{
					switch (directions [i] [j])
					{
						case 'U':
							if (startingPosition.x > 0 && keypad [startingPosition.x - 1, startingPosition.y] != " ")
								startingPosition.x--;
							break;
						case 'L':
							if (startingPosition.y > 0 && keypad [startingPosition.x, startingPosition.y - 1] != " ")
								startingPosition.y--;
							break;
						case 'D':
							if (startingPosition.x < keypad.GetLength (1) - 1 && keypad [startingPosition.x + 1, startingPosition.y] != " ")
								startingPosition.x++;
							break;
						case 'R':
							if (startingPosition.y < keypad.GetLength (1) - 1 && keypad [startingPosition.x, startingPosition.y + 1] != " ")
								startingPosition.y++;
							break;
						default:
							throw new Exception ("Directions file can only contain U, L, D, and R");
					}
				}
				code += keypad [startingPosition.x, startingPosition.y];
			}
			return code;
		}

		/// <summary>
		/// Populates the keypad array
		/// </summary>
		/// <param name="input">Keypad file</param>
		/// <returns>A populated keypad</returns>
		string [,] PopulateKeypad (string [] input)
		{
			string [,] rtrn = new string [input.Length, input [0].Length];
			for (int i = 0; i < input.Length; i++)
				for (int j = 0; j < input [0].Length; j++)
					rtrn [i, j] = input [i] [j].ToString ();
			return rtrn;
		}
	}
}