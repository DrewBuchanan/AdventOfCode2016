using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayFour
	{
		string [] puzzleInput;

		public DayFour ()
		{
			puzzleInput = System.IO.File.ReadAllLines ("../../Inputs/2017/Day04Input.txt");
		}

		public int PartOne ()
		{
			int valid = 0;
			for (int i = 0; i < puzzleInput.Length; i++)
				if (DontShareWords (puzzleInput [i]))
					valid++;
			return valid;
		}

		public int PartTwo ()
		{
			int valid = 0;
			for (int i = 0; i < puzzleInput.Length; i++)
				if (DoesntContainAnagrams (puzzleInput [i]))
					valid++;
			return valid;
		}

		public static bool DontShareWords (string passphrase)
		{
			string [] words = passphrase.Split (' ');
			for (int i = 0; i < words.Length - 1; i++)
				for (int j = i + 1; j < words.Length; j++)
					if (words [i] == words [j])
						return false;
			return true;
		}

		public static bool DoesntContainAnagrams (string passphrase)
		{
			string [] words = passphrase.Split (' ');
			for (int i = 0; i < words.Length - 1; i++)
				for (int j = i + 1; j < words.Length; j++)
				{
					string a = string.Concat (words [i].OrderBy (c => c));
					string b = string.Concat (words [j].OrderBy (c => c));
					if (a == b)
						return false;
				}
			return true;
		}
	}
}
