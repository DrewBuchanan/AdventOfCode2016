using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	public class DayEighteen
	{
		const char safeChar = '.';
		const char trapChar = '^';

		string [] rows;
		int numRows;
		int tilesPerRow;

		/// <summary>
		/// Generates rows, then draws rows to console
		/// </summary>
		public void PartOneTestOne ()
		{
			Initialize (3, System.IO.File.ReadAllText ("../../Inputs/Day18TestOneInput.txt"));
			PopulateRows ();
			for (int i = 0; i < rows.Length; i++)
				Console.WriteLine (rows [i]);
		}

		/// <summary>
		/// Generates rows, then returns the number of "safe" tiles
		/// </summary>
		/// <returns>number of "safe" tiles</returns>
		public int PartOneTestTwo ()
		{
			Initialize (10, System.IO.File.ReadAllText ("../../Inputs/Day18TestTwoInput.txt"));
			PopulateRows ();
			return GetNumberOfSafeTiles ();
		}

		/// <summary>
		/// Generates rows, then returns the number of "safe" tiles
		/// </summary>
		/// <returns>number of "safe" tiles</returns>
		public int PartOne ()
		{
			Initialize (40, System.IO.File.ReadAllText ("../../Inputs/Day18Input.txt"));
			PopulateRows ();
			return GetNumberOfSafeTiles ();
		}

		/// <summary>
		/// Generates rows, then returns the number of "safe" tiles
		/// </summary>
		/// <returns>number of "safe" tiles</returns>
		public int PartTwo ()
		{
			Initialize (400000, System.IO.File.ReadAllText ("../../Inputs/Day18Input.txt"));
			PopulateRows ();
			return GetNumberOfSafeTiles ();
		}

		/// <summary>
		/// Initializes rows, number of rows, and number of tiles per row
		/// </summary>
		/// <param name="numRows">total number of rows in room</param>
		/// <param name="firstRow">the first row of the room</param>
		void Initialize (int numRows, string firstRow)
		{
			this.numRows = numRows;
			rows = new string [numRows];
			rows [0] = firstRow;
			tilesPerRow = rows [0].Length;
		}

		/// <summary>
		/// Populates rows based on the prior row
		/// </summary>
		void PopulateRows ()
		{
			for (int i = 1; i < rows.Length; i++)
			{
				rows [i] = "";
				for (int j = 0; j < tilesPerRow; j++)
				{
					// If position is out of array bounds, assume it is safe
					char left = j > 0 ? rows [i - 1] [j - 1] : safeChar;
					char right = j < tilesPerRow - 1 ? rows [i - 1] [j + 1] : safeChar;
					char center = rows [i - 1] [j];
					bool isTrap = DetermineIfTrap (left, center, right);
					rows [i] += isTrap ? trapChar : safeChar;
				}
			}
		}

		/// <summary>
		/// Given a "left", "center", and "right" tile, determine if the tile is a trap
		/// <para>A tile is a trap if one of the following is true</para>
		/// <para>-Its left and center tiles are traps, but its right tile is not</para>
		/// <para>-Its center and right tiles are traps, but its left tile is not</para>
		/// <para>-Only its left tile is a trap</para>
		/// <para>-Only its right tile is a trap</para>
		/// </summary>
		/// <param name="left">value of tile above and to the left</param>
		/// <param name="center">value of tile directly above</param>
		/// <param name="right">value of tile above and to the right</param>
		/// <returns>true if trap, false if safe</returns>
		bool DetermineIfTrap (char left, char center, char right)
		{
			return (left == trapChar && center == trapChar && right != trapChar) ||
				(center == trapChar && right == trapChar && left != trapChar) ||
				(left == trapChar && center != trapChar && right != trapChar) ||
				(right == trapChar && center != trapChar && left != trapChar);
		}

		/// <summary>
		/// Iterates over rows and determines number of safe tiles
		/// </summary>
		/// <returns>total number of safe tiles</returns>
		int GetNumberOfSafeTiles ()
		{
			int safeTiles = 0;
			for (int i = 0; i < rows.Length; i++)
			{
				for (int j = 0; j < tilesPerRow; j++)
					safeTiles += rows [i] [j] == safeChar ? 1 : 0;
			}
			return safeTiles;
		}
	}
}
