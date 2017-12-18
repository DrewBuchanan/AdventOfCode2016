using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayFifteen
	{
		// Input
		const int GENERATOR_A_START_VALUE = 883;
		const int GENERATOR_B_START_VALUE = 879;

		const int GENERATOR_A_FACTOR = 16807;
		const int GENERATOR_B_FACTOR = 48271;

		long generatorAValue;
		long generatorBValue;

		public DayFifteen ()
		{
			generatorAValue = GENERATOR_A_START_VALUE;
			generatorBValue = GENERATOR_B_START_VALUE;
		}

		public int PartOne ()
		{
			int judge = 0;
			for (long i = 0; i < 40000000; i++)
			{
				Generate ();
				if (Judge ())
					judge++;
			}
			return judge;
		}

		public int PartTwo ()
		{
			int judge = 0;
			for (long i = 0; i < 5000000; i++)
			{
				GenerateTilMultiple ();
				if (Judge ())
					judge++;
			}
			return judge;
		}

		private bool Judge ()
		{
			string genABinary = Convert.ToString (generatorAValue, 2).PadLeft (16, '0');
			string genBBinary = Convert.ToString (generatorBValue, 2).PadLeft (16, '0');
			string genASixteen = genABinary.Substring (genABinary.Length - 16);
			string genBSixteen = genBBinary.Substring (genBBinary.Length - 16);

			return genASixteen == genBSixteen;
		}

		private void TickGenA ()
		{
			generatorAValue = (generatorAValue * GENERATOR_A_FACTOR) % int.MaxValue;
		}

		private void TickGenB ()
		{
			generatorBValue = (generatorBValue * GENERATOR_B_FACTOR) % int.MaxValue;
		}

		private void Generate ()
		{
			TickGenA ();
			TickGenB ();
		}

		private void GenerateTilMultiple ()
		{
			TickGenA ();
			while (generatorAValue % 4 != 0)
				TickGenA ();
			TickGenB ();
			while (generatorBValue % 8 != 0)
				TickGenB ();
		}
	}
}
