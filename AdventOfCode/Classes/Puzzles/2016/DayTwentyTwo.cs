using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
	public class DayTwentyTwo
	{
		readonly Regex trimmer = new Regex (@"\s\s+", RegexOptions.Compiled);
		Dictionary<Point, Node> nodes;

		public int PartOne ()
		{
			GenerateNodes ("../../Inputs/Day22Input.txt");
			int viablePairs = 0;
			foreach (Node node in nodes.Values)
			{
				foreach (Node other in nodes.Values)
				{
					if (node.IsViable (other))
						viablePairs++;
				}
			}
			return viablePairs;
		}

		public int PartTwoTest ()
		{
			GenerateNodes ("../../Inputs/Day22TestInput.txt");
			nodes [new Point (0, 2)].goalData = true;
			return 0;
		}

		void GenerateNodes (string inputPath)
		{
			nodes = new Dictionary<Point, Node> ();
			string [] data = System.IO.File.ReadAllLines (inputPath);
			for (int i = 2; i < data.Length; i++)
			{
				Node newNode = new Node (data [i]);
				nodes.Add (newNode.position, newNode);
			}
			foreach (Node node in nodes.Values)
			{
				Point left = new Point (node.position.X - 1, node.position.Y);
				Point right = new Point (node.position.X + 1, node.position.Y);
				Point up = new Point (node.position.X, node.position.Y - 1);
				Point down = new Point (node.position.X, node.position.Y + 1);
				if (nodes.ContainsKey (left))
					node.left = nodes [left];
				if (nodes.ContainsKey (right))
					node.right = nodes [right];
				if (nodes.ContainsKey (up))
					node.up = nodes [up];
				if (nodes.ContainsKey (down))
					node.down = nodes [down];
			}
		}

		public class Node
		{
			public Node (string input)
			{
				string [] split = input.Split (new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				position = new Point (int.Parse (split [0].Split ('-') [1].Substring (1)), int.Parse (split [0].Split ('-') [2].Substring (1)));
				size = int.Parse (split [1].Substring (0, split [1].Length - 1));
				used = int.Parse (split [2].Substring (0, split [2].Length - 1));
			}
			public Node left;
			public Node right;
			public Node up;
			public Node down;
			public bool goalData = false;

			public Point position;
			public int size;
			public int used;
			public int Available ()
			{
				return size - used;
			}

			public int UsedPercent ()
			{
				return (int)(((float)used / size) * 100);
			}

			public override int GetHashCode ()
			{
				return 17 * position.X + 23 * position.Y;
			}

			public bool IsViable (Node other)
			{
				return this.GetHashCode () != other.GetHashCode () &&
					this.used != 0 &&
					this.used < other.Available ();
			}
		}
	}
}
