using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Puzzles._2017
{
	public class DayEight
	{
		string [] conditionMarker = new string [] { " if " };

		string [] input;
		Dictionary<string, int> registers;

		public DayEight ()
		{
			input = System.IO.File.ReadAllLines ("../../Inputs/2017/Day08Input.txt");
			InitializeRegisters (input);
		}

		public int PartOne ()
		{
			for (int i = 0; i < input.Length; i++)
				ProcessInstruction (input [i]);
			return registers.Values.Max ();
		}

		public int PartTwo ()
		{
			int max = int.MinValue;
			for (int i = 0; i < input.Length; i++)
			{
				ProcessInstruction (input [i]);
				int currMax = registers.Values.Max ();
				if (currMax > max)
					max = currMax;
			}
			return max;
		}

		private void ProcessInstruction (string instruction)
		{
			string condition = instruction.Split (conditionMarker, StringSplitOptions.RemoveEmptyEntries) [1];
			if (ConditionIsMet (condition))
			{
				string operation = instruction.Split (conditionMarker, StringSplitOptions.RemoveEmptyEntries) [0];
				string [] split = operation.Split (' ');
				string register = split [0];
				int value = int.Parse (split [2]);
				if (split [1] == "inc")
					registers [register] += value;
				else if (split [1] == "dec")
					registers [register] -= value;
			}
		}

		private bool ConditionIsMet (string condition)
		{
			string [] split = condition.Split (' ');
			string register = split [0];
			AddRegisterIfNotAlreadyAdded (register);

			int value = int.Parse (split [2]);
			switch (split [1])
			{
				case ">":
					return registers [register] > value;
				case "<":
					return registers [register] < value;
				case ">=":
					return registers [register] >= value;
				case "==":
					return registers [register] == value;
				case "<=":
					return registers [register] <= value;
				case "!=":
					return registers [register] != value;
				default:
					throw new NotImplementedException ("Operator " + split [1] + " not implemented");
			}
		}

		private void InitializeRegisters (string [] input)
		{
			registers = new Dictionary<string, int> ();
			for (int i = 0; i < input.Length; i++)
			{
				string id = input [i].Split (' ') [0];
				AddRegisterIfNotAlreadyAdded (id);
			}
		}

		private void AddRegisterIfNotAlreadyAdded (string id)
		{
			if (!registers.ContainsKey (id))
				registers.Add (id, 0);
		}
	}
}