using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;

namespace AdventOfCode.Puzzles
{
	public class DaySeventeen
	{
		string puzzleInput = "yjjvjgan";

		string testOneInput = "kglvqrro";
		string openVals = "bcdef";
		Point startPoint = new Point (0, 0);
		Point current = new Point (0, 0);
		Point goal = new Point (3, 3);
		MD5 md5;

		public string Test ()
		{
			md5 = MD5.Create ();
			string shortest = null;
			int longest = 0;
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
					string hash = GetHash (puzzleInput + state.path);
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
			Console.WriteLine (longest);
			return shortest;
		}

		class State
		{
			public string path = "";
			public Point pos = new Point (0, 0);
		}

		string GetHash (string text)
		{
			byte [] hash = md5.ComputeHash (Encoding.ASCII.GetBytes (text));
			return BitConverter.ToString (hash).Replace ("-", "").ToLowerInvariant ();
		}
	}
}
