using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	public class DayEight
	{
		const int screenWidth = 50;
		const int screenHeight = 6;

		bool [,] screen;
		string [] inputs;

		char onChar = '#';
		char offChar = ' ';

		public DayEight ()
		{
			Initialize ();
		}

		/// <summary>
		/// Initializes screen with all pixels turned off and reads input
		/// </summary>
		void Initialize ()
		{
			screen = new bool [screenWidth, screenHeight];
			for (int i = 0; i < screenWidth; i++)
				for (int j = 0; j < screenHeight; j++)
					screen [i, j] = false;

			inputs = System.IO.File.ReadAllLines ("Day08Input.txt");
		}

		/// <summary>
		/// Processes a series of inputs, then returns the number of pixels lit by these inputs
		/// </summary>
		/// <returns>number of lit pixels</returns>
		public int PartOne ()
		{
			screen = ProcessInputs (screen);

			int lit = 0;
			for (int i = 0; i < screenWidth; i++)
				for (int j = 0; j < screenHeight; j++)
					if (screen [i, j])
						lit++;
			return lit;
		}

		/// <summary>
		/// Processes a series of inputs, then draws the screen as a result of these inputs
		/// </summary>
		public void PartTwo ()
		{
			screen = ProcessInputs (screen);
			DrawScreen (screen);
		}

		/// <summary>
		/// Processes all inputs then returns the result
		/// </summary>
		/// <param name="screen">the screen</param>
		/// <returns>the results of all inputs</returns>
		bool [,] ProcessInputs (bool [,] screen)
		{
			for (int i = 0; i < inputs.Length; i++)
			{
				string sanitized = inputs [i].Replace ("rotate", "").Replace (" ", "");
				if (inputs [i].Contains ("rect"))
				{
					string [] param = inputs [i].Replace ("rect", "").Split ('x');
					screen = Rect (int.Parse (param [0]), int.Parse (param [1]), screen);
				}
				if (inputs [i].Contains ("row"))
				{
					string [] param = sanitized.Replace ("rowy=", "").Replace ("by", "x").Split ('x');
					screen = RotateRowBy (int.Parse (param [0]), int.Parse (param [1]), screen);
				}
				if (inputs [i].Contains ("column"))
				{
					string [] param = sanitized.Replace ("columnx=", "").Replace ("by", "x").Split ('x');
					screen = RotateColumnBy (int.Parse (param [0]), int.Parse (param [1]), screen);
				}
			}
			return screen;
		}

		/// <summary>
		/// Turns on all pixels in an x by y rectangle on screen starting at 0,0
		/// </summary>
		/// <param name="x">rectangle width</param>
		/// <param name="y">rectangle height</param>
		/// <param name="screen">the screen</param>
		/// <returns></returns>
		bool [,] Rect (int x, int y, bool [,] screen)
		{
			for (int i = 0; i < x; i++)
				for (int j = 0; j < y; j++)
					screen [i, j] = true;

			return screen;
		}

		/// <summary>
		/// Rotates row in screen by times
		/// </summary>
		/// <param name="row">row to rotate</param>
		/// <param name="by">number of times to rotate</param>
		/// <param name="screen">the screen</param>
		/// <returns>the result of the rotation</returns>
		bool [,] RotateRowBy (int row, int by, bool [,] screen)
		{
			for (int i = 0; i < by; i++)
				screen = RotateRow (row, screen);
			return screen;
		}
		/// <summary>
		/// Rotates row in screen by one
		/// </summary>
		/// <param name="row">row to rotate</param>
		/// <param name="screen">the screen</param>
		/// <returns>the result of the rotation</returns>
		bool [,] RotateRow (int row, bool [,] screen)
		{
			List<bool> rowLights = new List<bool> ();

			for (int i = 0; i < screenWidth; i++)
				rowLights.Add (screen [i, row]);

			bool temp = rowLights [rowLights.Count - 1];
			rowLights.RemoveAt (rowLights.Count - 1);
			rowLights.Insert (0, temp);

			for (int i = 0; i < screenWidth; i++)
				screen [i, row] = rowLights [i];

			return screen;
		}

		/// <summary>
		/// Rotates column in screen by times
		/// </summary>
		/// <param name="column">column to rotate</param>
		/// <param name="by">number of times to rotate</param>
		/// <param name="screen">the screen</param>
		/// <returns>the result of the rotation</returns>
		bool [,] RotateColumnBy (int column, int by, bool [,] screen)
		{
			for (int i = 0; i < by; i++)
				screen = RotateColumn (column, screen);
			return screen;
		}
		/// <summary>
		/// Rotates column in screen by one
		/// </summary>
		/// <param name="column">the column to rotate</param>
		/// <param name="screen">the screen</param>
		/// <returns>the result of the rotation</returns>
		bool [,] RotateColumn (int column, bool [,] screen)
		{
			List<bool> columnLights = new List<bool> ();

			for (int i = 0; i < screenHeight; i++)
				columnLights.Add (screen [column, i]);

			bool temp = columnLights [columnLights.Count - 1];
			columnLights.RemoveAt (columnLights.Count - 1);
			columnLights.Insert (0, temp);

			for (int i = 0; i < screenHeight; i++)
				screen [column, i] = columnLights [i];

			return screen;
		}

		/// <summary>
		/// Draws the screen to the console
		/// </summary>
		/// <param name="screen">the screen to draw</param>
		void DrawScreen (bool [,] screen)
		{
			for (int j = 0; j < screenHeight; j++)
			{
				for (int i = 0; i < screenWidth; i++)
					Console.Write (screen [i, j] ? onChar : offChar);
				Console.WriteLine ();
			}
		}
	}
}
