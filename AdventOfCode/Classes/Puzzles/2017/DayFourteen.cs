using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayFourteen
	{
		public const string puzzleInput = "oundnydw";
		public const string testInput = "flqrgnkx";

		public static string HexToBinary (string hex)
		{
			string to = "";
			to = Convert.ToString (Convert.ToInt32 (hex, 16), 2);
			return to;
		}
	}
}
