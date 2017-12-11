using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayNine
	{
		string input;

		public int totalGroups;
		public int score;
		public int garbageCharacters;

		public DayNine ()
		{
			input = System.IO.File.ReadAllText ("../../Inputs/2017/Day09Input.txt");
			ProcessStream ();
		}

		public DayNine (string stream)
		{
			input = stream;
			ProcessStream ();
		}

		public int PartOne ()
		{
			return score;
		}

		public int PartTwo ()
		{
			return garbageCharacters;
		}

		private void ProcessStream ()
		{
			totalGroups = 0;
			score = 0;
			garbageCharacters = 0;

			int openGroups = 0;
			bool inGarbage = false;
			for (int i = 0; i < input.Length; i++)
			{
				if (!inGarbage)
				{
					if (input [i] == '<')
					{
						inGarbage = true;
						continue;
					}
					else if (input [i] == '{')
					{
						totalGroups++;
						openGroups++;
					}
					else if (input [i] == '}')
					{
						score += openGroups;
						openGroups--;
					}
				}
				if (input [i] == '!')
				{
					i++;
					continue;
				}
				else if (input [i] == '>')
					inGarbage = false;
				if (inGarbage)
					garbageCharacters++;
			}
		}
	}
}
