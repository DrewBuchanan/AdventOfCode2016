using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayFive
	{
		string [] input;
		int [] instructions;

		public DayFive ()
		{
			input = System.IO.File.ReadAllLines ("../../Inputs/2017/Day05Input.txt");
			instructions = new int [input.Length];
			for (int i = 0; i < input.Length; i++)
				instructions [i] = int.Parse (input [i]);
		}

		public int PartOne ()
		{
			return Run (instructions);
		}

		public int PartTwo ()
		{
			return Run (instructions, true);
		}

		public static int Run (int [] instructions, bool strange = false)
		{
			int steps = 0;
			int index = 0;
			while (index < instructions.Length)
			{
				int jump = instructions [index];
				if (strange && instructions [index] >= 3)
					instructions [index]--;
				else
					instructions [index]++;
				index += jump;
				steps++;
			}
			return steps;
		}
	}
}
