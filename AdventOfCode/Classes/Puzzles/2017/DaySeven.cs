using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DaySeven
	{
		string [] input;

		List<Program> programs;

		public DaySeven ()
		{
			input = System.IO.File.ReadAllLines ("../../Inputs/2017/Day07Input.txt");
			GeneratePrograms ();
			AssignChildren ();
		}

		private void AssignChildren ()
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input [i].Contains ("->"))
				{
					Program program = programs.Find (x => x.name == input [i].Split (' ') [0]);
					string [] children = input [i].Split ('>') [1].Replace (" ", "").Split (',');
					for (int j = 0; j < children.Length; j++)
					{
						program.AddChild (programs.Find (x => x.name == children [j]));
					}
				}
			}
		}

		private void GeneratePrograms ()
		{
			programs = new List<Program> ();
			for (int i = 0; i < input.Length; i++)
			{
				string [] split = input [i].Split (' ');
				string name = split [0];
				int weight = int.Parse (split [1].Replace ("(", "").Replace (")", ""));
				Program newNode = new Program (name, weight);
				programs.Add (newNode);
			}
		}

		public string PartOne ()
		{
			return GetProgramWithNoParent ().name;
		}

		public void PartTwo ()
		{
			Program parent = GetProgramWithNoParent ();
			while (parent.GetChildren ().Count > 0)
			{
				List<int> branchWeights = new List<int> ();
				List<Program> children = parent.GetChildren ();
				for (int i = 0; i < children.Count; i++)
				{
					branchWeights.Add (children [i].GetBranchWeight ());
				}
				if (branchWeights.Distinct ().Count () == 1)
				{
					parent = parent.GetParent ();
					break;
				}
				int unbalanced = branchWeights.GroupBy (x => x).OrderBy (group => group.Count ()).Select (x => x.Key).First ();
				parent = children [branchWeights.IndexOf (unbalanced)];
			}
			List<int> weights = new List<int> ();
			List<int> branch = new List<int> ();
			for (int i = 0; i < parent.GetChildren ().Count; i++)
			{
				weights.Add (parent.GetChildren () [i].GetWeight ());
				branch.Add (parent.GetChildren () [i].GetBranchWeight ());
			}
			List<int> distinct = branch.Distinct ().ToList ();
			int diff = distinct [0] - distinct [1];
			int un = weights [branch.IndexOf (branch.GroupBy (x => x).OrderBy (group => group.Count ()).Select (x => x.Key).First ())];
			int answer = un + diff;
			Console.WriteLine (un + " + " + diff + " = " + answer);
		}

		Program GetProgramWithNoParent ()
		{
			return programs.Find (x => x.GetParent () == null);
		}

		public class Program
		{
			private Program parent;
			private int weight;
			private List<Program> children;

			public readonly string name;

			public Program (string name, int weight)
			{
				this.name = name;
				this.weight = weight;
				this.children = new List<Program> ();
			}

			public void AddChild (Program child)
			{
				children.Add (child);
				child.parent = this;
			}

			public List<Program> GetChildren ()
			{
				return children;
			}

			public void SetParent (Program parent)
			{
				this.parent = parent;
			}

			public Program GetParent ()
			{
				return parent;
			}

			public int GetWeight ()
			{
				return weight;
			}

			public int GetBranchWeight ()
			{
				int sum = 0;
				for (int i = 0; i < children.Count; i++)
					sum += children [i].GetBranchWeight ();
				sum += GetWeight ();
				return sum;
			}
		}
	}
}
