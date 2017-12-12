using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTwelve
	{
		string [] input;
		List<Program> programs;

		public DayTwelve (string fileName)
		{
			input = System.IO.File.ReadAllLines (fileName);
			GeneratePrograms ();
			MakeConnections ();
		}

		public int PartOne ()
		{
			return GetConnections (programs [0], new List<Program> ()).Count;
		}

		public int PartTwo ()
		{
			List<List<Program>> groups = new List<List<Program>> ();
			while (programs.Count > 0)
			{
				List<Program> group = GetConnections (programs [0], new List<Program> ());
				for (int i = 0; i < group.Count; i++)
					programs.Remove (group [i]);
				groups.Add (group);
			}
			return groups.Count;
		}

		private List<Program> GetConnections (Program program, List<Program> connected)
		{
			connected.Add (program);
			List<Program> cons = program.GetConnectionList ();
			for (int i = 0; i < cons.Count; i++)
				if (!connected.Contains (cons [i]))
					connected.AddRange (GetConnections (cons [i], connected));
			connected = connected.Distinct ().ToList ();
			return connected;
		}

		private void GeneratePrograms ()
		{
			programs = new List<Program> (input.Length);
			for (int i = 0; i < input.Length; i++)
			{
				programs.Add (new Program (i));
			}
		}

		private void MakeConnections ()
		{
			for (int i = 0; i < input.Length; i++)
			{
				string [] connections = input [i].Split ('>') [1].Split (',');
				for (int j = 0; j < connections.Length; j++)
				{
					programs [i].AddConnection (programs [int.Parse (connections [j])]);
				}
			}
		}

		public class Program
		{
			int id;
			List<Program> connected;

			public Program (int id)
			{
				connected = new List<Program> ();
				this.id = id;
			}

			internal void AddConnection (Program program)
			{
				connected.Add (program);
			}

			internal List<Program> GetConnectionList ()
			{
				return connected;
			}
		}
	}
}
