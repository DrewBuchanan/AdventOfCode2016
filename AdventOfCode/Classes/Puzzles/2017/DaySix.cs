using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles._2017
{
	public class DaySix
	{
		string [] input;
		int [] banks;

		static List<string> states = new List<string> ();

		public DaySix ()
		{
			input = WhitespaceTrimmer.Trim (System.IO.File.ReadAllText ("../../Inputs/2017/Day06Input.txt")).Replace (' ', ',').Split (',');
			banks = new int [input.Length];
			for (int i = 0; i < input.Length; i++)
				banks [i] = int.Parse (input [i]);
		}

		public int PartOne ()
		{
			return IterateUntilRepeatedState (banks);
		}

		public int PartTwo ()
		{
			int totalIterations = IterateUntilRepeatedState (banks);
			string repeatedState = string.Join (",", banks);
			int firstOccurence = states.IndexOf (repeatedState);
			return totalIterations - firstOccurence;
		}

		public static int IterateUntilRepeatedState (int [] banks)
		{
			int iterations = 0;
			while (!states.Contains (string.Join (",", banks)))
			{
				states.Add (string.Join (",", banks));
				banks = Iterate (banks);
				iterations++;
			}
			return iterations;
		}

		public static int [] Iterate (int [] banks)
		{
			int redistribute = banks.Max ();
			int index = Array.IndexOf (banks, redistribute);
			banks [index] = 0;
			index++;
			while (redistribute > 0)
			{
				banks [index % banks.Length]++;
				index++;
				redistribute--;
			}
			return banks;
		}
	}
}
