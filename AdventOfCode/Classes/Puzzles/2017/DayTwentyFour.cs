using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTwentyFour
	{
		List<Component> components;

		public DayTwentyFour ()
		{
			string [] input = System.IO.File.ReadAllLines ("../../Inputs/2017/Day24TestInput.txt");
			GenerateComponents (input);
		}

		private void GenerateComponents (string [] input)
		{
			components = new List<Component> ();
			for (int i = 0; i < input.Length; i++)
				components.Add (new Component (input [i], (char)i));
		}

		public void Test ()
		{
			List<List<Component>> bridges = Permutations (components, 0);
		}

		public List<List<Component>> Permutations (List<Component> list, int requiredPins)
		{
			List<List<Component>> result = new List<List<Component>> ();
			if (list.Count == 1)
			{
				if (list [0].leftPortPins == requiredPins || list [0].rightPortPins == requiredPins)
					result.Add (list);
				return result;
			}
			foreach (var element in list)
			{
				var remainingList = new List<Component> (list);
				remainingList.Remove (element);
				foreach (var permutation in Permutations (list, requiredPins))
				{
					if (permutation [permutation.Count - 1].leftPortPins == requiredPins || permutation [permutation.Count - 1].rightPortPins == requiredPins)
					{
						permutation.Add (element);
						result.Add (permutation);
						if (permutation [permutation.Count - 1].leftPortPins == requiredPins)
							requiredPins = permutation [permutation.Count - 1].rightPortPins;
						else
							requiredPins = permutation [permutation.Count - 1].leftPortPins;
					}
				}
			}
			return result;
		}

		public class Component
		{
			public int leftPortPins;
			public int rightPortPins;
			public char id;

			public Component (string comp, char id)
			{
				string [] split = comp.Split ('/');
				leftPortPins = int.Parse (split [0]);
				rightPortPins = int.Parse (split [1]);
				this.id = id;
			}
		}
	}
}
