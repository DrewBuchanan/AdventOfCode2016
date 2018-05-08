using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTwentyThree
	{
		Assembly assembly;

		public DayTwentyThree ()
		{
			string [] instructions = System.IO.File.ReadAllLines ("../../Inputs/2017/Day23Input.txt");
			assembly = new Assembly (instructions);
		}
		
		public long PartTwoManual ()
		{
			int primes = 0;
			for (int i = 109300; i <= 126300; i += 17)
			{
				for (int j = 2; j < 17000; j++)
				{
					if (i % j == 0)
					{
						primes++;
						break;
					}
				}
			}
			return primes;
		}

		public long PartOne ()
		{
			assembly.Process ();
			return assembly.GetMulCalls ();
		}

		public long PartTwo ()
		{
			assembly.Set ('a', "1");
			assembly.Process ();
			return assembly.Get ('h');
		}

		public class Assembly
		{
			Dictionary<char, long> registers;
			string [] instructions;
			long index;
			long mulCalls;

			public Assembly (string [] instructions)
			{
				registers = new Dictionary<char, long> ();
				for (int i = 97; i < 105; i++)
					registers.Add ((char)i, 0);
				this.instructions = instructions;
				index = 0;
				mulCalls = 0;
			}

			public void Process ()
			{
				while (index < instructions.Length && index > -1)
				{
					string [] split = instructions [index].Split (' ');
					ProcessInstruction (split);
				}
			}

			private void ProcessInstruction (string [] param)
			{
				switch (param [0])
				{
					case "set":
						Set (param [1] [0], param [2]);
						break;
					case "sub":
						Sub (param [1] [0], param [2]);
						break;
					case "mul":
						Mul (param [1] [0], param [2]);
						break;
					case "jnz":
						Jump (param [1] [0], param [2]);
						break;
				}
			}

			public long Get (char register) { return registers [register]; }

			public void Set (char register, string param)
			{
				long val = GetValueFromParam (param);
				registers [register] = val;
				index++;
			}

			private long GetValueFromParam (string param)
			{
				long val;
				if (long.TryParse (param, out val))
					return val;
				return Get (param [0]);
			}

			public void Sub (char register, string param)
			{
				long val = GetValueFromParam (param);
				registers [register] -= val;
				index++;
			}

			public void Mul (char register, string param)
			{
				long val = GetValueFromParam (param);
				registers [register] *= val;
				index++;
				mulCalls++;
			}

			public void Jump (char register, string param)
			{
				if (char.IsDigit (register) || registers [register] != 0)
					index += GetValueFromParam (param);
				else
					index++;
			}

			public long GetMulCalls ()
			{
				return mulCalls;
			}
		}
	}
}
