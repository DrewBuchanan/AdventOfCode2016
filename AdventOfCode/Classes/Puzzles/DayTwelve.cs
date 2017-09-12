using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	public class DayTwelve
	{
		Dictionary<string, int> registers;

		/// <summary>
		/// Processes the example input on the puzzle page
		/// </summary>
		/// <returns>the values of the registers</returns>
		public List<int> Test ()
		{
			InitializeRegisters ();
			string [] input = System.IO.File.ReadAllLines ("../../Inputs/Day12TestInput.txt");
			int i = 0;
			while (i < input.Length)
			{
				i += ProcessInstruction (input [i]);
			}
			return GetReturnValues ();
		}

		/// <summary>
		/// Processes puzzle input instructions
		/// </summary>
		/// <returns>the values of the registers</returns>
		public List<int> PartOne ()
		{
			InitializeRegisters ();
			string [] input = System.IO.File.ReadAllLines ("../../Inputs/Day12Input.txt");
			int i = 0;
			while (i < input.Length)
			{
				i += ProcessInstruction (input [i]);
			}
			return GetReturnValues ();
		}

		/// <summary>
		/// Processes puzzle input instructions with c=1 instead of c=0
		/// </summary>
		/// <returns>the values of the registers</returns>
		public List<int> PartTwo ()
		{
			InitializeRegisters ();
			registers ["c"] = 1;
			string [] input = System.IO.File.ReadAllLines ("../../Inputs/Day12Input.txt");
			int i = 0;
			while (i < input.Length)
			{
				i += ProcessInstruction (input [i]);
			}
			return GetReturnValues ();
		}

		/// <summary>
		/// Generates a list with the values a, b, c, and d
		/// </summary>
		/// <returns>The values in registers a, b, c, d</returns>
		List<int> GetReturnValues ()
		{
			return new List<int> { registers ["a"], registers ["b"], registers ["c"], registers ["d"] };
		}

		/// <summary>
		/// Generates dictionary and initializes values to 0
		/// </summary>
		void InitializeRegisters ()
		{
			registers = new Dictionary<string, int> ();
			registers.Add ("a", 0);
			registers.Add ("b", 0);
			registers.Add ("c", 0);
			registers.Add ("d", 0);
		}

		/// <summary>
		/// Processes an individual instruction and returns the number of instructions to jump
		/// </summary>
		/// <param name="instruction">the instruction to process</param>
		/// <returns>number of instructions to jump</returns>
		int ProcessInstruction (string instruction)
		{
			string [] split = instruction.Split (' ');
			switch (split [0])
			{
				case "inc":
					registers [split [1]]++;
					break;
				case "dec":
					registers [split [1]]--;
					break;
				case "cpy":
					int valueToCopy;
					if (int.TryParse (split [1], out valueToCopy))
						registers [split [2]] = valueToCopy;
					else
						registers [split [2]] = registers [split [1]];
					break;
				case "jnz":
					int value;
					int rtrnValue = int.Parse (split [2]);
					if (int.TryParse (split [1], out value))
					{
						if (value == 0)
							return 1;
						else
							return rtrnValue;
					}
					else
					{
						if (registers [split [1]] != 0)
							return rtrnValue;
						else
							return 1;
					}
			}
			return 1;
		}
	}
}
