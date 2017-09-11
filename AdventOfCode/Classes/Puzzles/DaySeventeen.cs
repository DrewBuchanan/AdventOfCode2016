using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;

namespace AdventOfCode.Puzzles
{
	// TODO: Clean up this class
	public class DaySeventeen
	{
		string puzzleInput = "yjjvjgan";

		string testOneInput = "kglvqrro";
		string openVals = "bcdef";
		static Point startPoint = new Point (0, 0);
		static Point current = new Point (0, 0);
		static Point goal = new Point (3, 3);
		MD5 md5 = MD5.Create ();

		string shortest = null;
		int longest = 0;

		/// <summary>
		/// Performs a breadth-first search on all possible states, then returns the shortest path
		/// </summary>
		/// <returns></returns>
		public string TestOne ()
		{
			ProcessStates (testOneInput);
			return shortest;
		}

		/// <summary>
		/// Performs a breath-first search on all possible states, then returns the shortest path
		/// </summary>
		/// <returns>the shortest path in directions to travel (UDLR)</returns>
		public string PartOne ()
		{
			ProcessStates (puzzleInput);
			return shortest;
		}

		/// <summary>
		/// Performs a breadth-first search on all possible states, then returns the length of the longest path
		/// </summary>
		/// <returns>length of longest path</returns>
		public int PartTwo ()
		{
			ProcessStates (puzzleInput);
			return longest;
		}

		/// <summary>
		/// Performs a breadth-first search on all possible states based on puzzle input, setting shortest and longest as necessary
		/// </summary>
		void ProcessStates (string input)
		{
			Queue<State> q = new Queue<State> (new [] { new State () });
			do
			{
				State state = q.Dequeue ();
				if (state.pos == goal)
				{
					shortest = shortest ?? state.path;
					longest = Math.Max (longest, state.path.Length);
				}
				else
				{
					string hash = GetHash (input + state.path);
					if (openVals.Contains (hash [0]) && state.pos.Y > 0)
						q.Enqueue (new State { path = state.path + 'U', pos = new Point (state.pos.X, state.pos.Y - 1) });
					if (openVals.Contains (hash [1]) && state.pos.Y < goal.Y)
						q.Enqueue (new State { path = state.path + 'D', pos = new Point (state.pos.X, state.pos.Y + 1) });
					if (openVals.Contains (hash [2]) && state.pos.X > 0)
						q.Enqueue (new State { path = state.path + 'L', pos = new Point (state.pos.X - 1, state.pos.Y) });
					if (openVals.Contains (hash [3]) && state.pos.X < goal.X)
						q.Enqueue (new State { path = state.path + 'R', pos = new Point (state.pos.X + 1, state.pos.Y) });
				}
			} while (q.Count > 0);
		}

		/// <summary>
		/// Holds the path taken thus far and the current position
		/// </summary>
		class State
		{
			public string path = "";
			public Point pos = startPoint;
		}

		/// <summary>
		/// Generates a hash code from a given input
		/// </summary>
		/// <param name="text">the input</param>
		/// <returns>the hash code generated from input</returns>
		string GetHash (string text)
		{
			byte [] hash = md5.ComputeHash (Encoding.ASCII.GetBytes (text));
			return BitConverter.ToString (hash).Replace ("-", "").ToLowerInvariant ();
		}
	}
}
