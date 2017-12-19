using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayEighteen
	{
		string puzzleInputFilePath = "../../Inputs/2017/Day18Input.txt";
		string testInputFilePath = "../../Inputs/2017/Day18TestInput.txt";

		string [] instructions;
		Assembly assembly1;
		Assembly assembly2;
		long lastFrequency;
		long index;
		bool jumped;

		public DayEighteen ()
		{
			assembly1 = new Assembly ();
			instructions = System.IO.File.ReadAllLines (puzzleInputFilePath);
			lastFrequency = 0;
			index = 0;
			jumped = false;
		}

		public long PartOne ()
		{
			string [] split = instructions [index].Split (' ');
			while (ProcessInstruction (split) && index > -1 && index < instructions.Length)
			{
				if (!jumped)
					index++;
				jumped = false;
				split = instructions [index].Split (' ');
			}
			return lastFrequency;
		}

		public long PartTwo ()
		{
			return 0;
		}

		private bool ProcessInstruction (string [] param)
		{
			switch (param [0])
			{
				case "snd":
					lastFrequency = assembly1.Get (param [1] [0]);
					break;
				case "set":
					assembly1.Set (param [1] [0], param [2]);
					break;
				case "add":
					assembly1.Add (param [1] [0], param [2]);
					break;
				case "mul":
					assembly1.Multiply (param [1] [0], param [2]);
					break;
				case "mod":
					assembly1.Modulo (param [1] [0], param [2]);
					break;
				case "rcv":
					if (assembly1.Get (param [1] [0]) != 0)
						return false;
					break;
				case "jgz":
					if (assembly1.Get (param [1] [0]) > 0)
					{
						Console.WriteLine (param [2] + " " + (index + assembly1.GetValueFromParam (param [2])));
						jumped = true;
						index += assembly1.GetValueFromParam (param [2]);
					}
					break;
			}
			return true;
		}

		public class Assembly
		{
			Dictionary<char, long> registers;

			public Assembly ()
			{
				registers = new Dictionary<char, long> ();
			}

			private void AddIfDoesntExist (char register)
			{
				if (!registers.ContainsKey (register))
					registers.Add (register, 0);
			}

			public long GetValueFromParam (string param)
			{
				long val;
				if (long.TryParse (param, out val))
					return val;
				return Get (param [0]);
			}

			public void Set (char register, string param)
			{
				AddIfDoesntExist (register);
				long val = GetValueFromParam (param);
				registers [register] = val;
			}

			public long Get (char register)
			{
				AddIfDoesntExist (register);
				return registers [register];
			}

			public void Add (char register, string param)
			{
				AddIfDoesntExist (register);
				long val = GetValueFromParam (param);
				registers [register] += val;
			}

			public void Multiply (char register, string param)
			{
				AddIfDoesntExist (register);
				long val = GetValueFromParam (param);
				registers [register] *= val;
			}

			public void Modulo (char register, string param)
			{
				AddIfDoesntExist (register);
				long val = GetValueFromParam (param);
				registers [register] %= val;
			}
		}
	}
}
