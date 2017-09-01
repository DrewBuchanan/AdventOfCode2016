using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
	public class DayThree
	{
		readonly Regex trimmer = new Regex (@"\s\s+", RegexOptions.Compiled);

		int numberOfTriangles;
		string [] triangles;

		public DayThree ()
		{
			Initialize ();
		}

		/// <summary>
		/// Initializes number of triangles and reads input
		/// </summary>
		void Initialize ()
		{
			numberOfTriangles = 0;
			triangles = System.IO.File.ReadAllLines ("Day03Input.txt");
		}

		/// <summary>
		/// Determines number of triangles when input is read horizontally
		/// </summary>
		/// <returns>number of valid triangles</returns>
		public int PartOne ()
		{
			int numberOfTriangles = 0;
			string [] triangles = System.IO.File.ReadAllLines ("Day03Input.txt");
			for (int i = 0; i < triangles.Length; i++)
			{
				string triangle = trimmer.Replace (triangles [i], " ").Replace (" ", ",");
				string [] sides = triangle.Split (',');
				if (IsValidTriangle (int.Parse (sides [1]), int.Parse (sides [2]), int.Parse (sides [3])))
					numberOfTriangles++;
			}
			return numberOfTriangles;
		}

		/// <summary>
		/// Determines number of triangles when input is read vertically
		/// </summary>
		/// <returns></returns>
		public int PartTwo ()
		{
			for (int i = 0; i < triangles.Length; i += 3)
			{
				string rowOne = trimmer.Replace (triangles [i], " ");
				string rowTwo = trimmer.Replace (triangles [i + 1], " ");
				string rowThree = trimmer.Replace (triangles [i + 2], " ");
				string [] rowOneSides = rowOne.Replace (" ", ",").Split (new char [] { ',' });
				string [] rowTwoSides = rowTwo.Replace (" ", ",").Split (new char [] { ',' });
				string [] rowThreeSides = rowThree.Replace (" ", ",").Split (new char [] { ',' });
				for (int j = 1; j < 4; j++)
					if (IsValidTriangle (int.Parse (rowOneSides [j]), int.Parse (rowTwoSides [j]), int.Parse (rowThreeSides [j])))
						numberOfTriangles++;
			}
			return numberOfTriangles;
		}

		/// <summary>
		/// Determines whether a triangle is valid
		/// </summary>
		/// <param name="a">The first side of the triangle</param>
		/// <param name="b">The second side of the triangle</param>
		/// <param name="c">The third side of the triangle</param>
		/// <returns>true if valid, false if not</returns>
		bool IsValidTriangle (int a, int b, int c)
		{
			if (a + b > c && b + c > a && a + c > b)
			{
				return true;
			}
			return false;
		}
	}
}
