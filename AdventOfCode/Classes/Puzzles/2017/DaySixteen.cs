using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DaySixteen
	{
		StringBuilder programs;
		string [] instructions;

		public DaySixteen ()
		{
			instructions = System.IO.File.ReadAllText ("../../Inputs/2017/Day16Input.txt").Split (',');
			programs = new StringBuilder ();
			for (int i = 97; i < 113; i++)
				programs.Append ((char)i);
		}

		public string Test ()
		{
			programs = new StringBuilder ("abcde");
			instructions = new string [] { "s1", "x3/4", "pe/b" };
			for (int j = 0; j < 2; j++)
				for (int i = 0; i < instructions.Length; i++)
					PerformInstruction (instructions [i]);
			return programs.ToString ();
		}

		public string PartOne ()
		{
			for (int i = 0; i < instructions.Length; i++)
				PerformInstruction (instructions [i]);
			return programs.ToString ();
		}

		public string PartTwo ()
		{
			bool hasSkipped = false;
			List<string> seen = new List<string> ();
			for (long j = 0; j < 1000000000; j++)
			{
				for (int i = 0; i < instructions.Length; i++)
				{
					PerformInstruction (instructions [i]);
				}
				if (seen.Contains (programs.ToString ()) && !hasSkipped)
				{
					j = (1000000000 / j) * j;
					hasSkipped = true;
				}
				seen.Add (programs.ToString ());
			}
			System.Windows.Clipboard.SetText (programs.ToString ());
			return programs.ToString ();
		}

		private void PerformInstruction (string instruction)
		{
			char temp;
			switch (instruction [0])
			{
				case 's':
					int spin = int.Parse (instruction.Substring (1));
					string back = programs.ToString ().Substring (programs.Length - spin);
					programs.Remove (programs.Length - spin, spin);
					programs.Insert (0, back);
					break;
				case 'x':
					string [] positions = instruction.Substring (1).Split ('/');
					temp = programs [int.Parse (positions [0])];
					programs [int.Parse (positions [0])] = programs [int.Parse (positions [1])];
					programs [int.Parse (positions [1])] = temp;
					break;
				case 'p':
					string [] names = instruction.Substring (1).Split ('/');
					int pos1 = programs.ToString ().IndexOf (names [0]);
					int pos2 = programs.ToString ().IndexOf (names [1]);
					temp = programs [pos1];
					programs [pos1] = programs [pos2];
					programs [pos2] = temp;
					break;
			}
		}
	}
}
