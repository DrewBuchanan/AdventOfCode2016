using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTwentyOne
	{
		public static DayTwentyOne Test ()
		{
			return new DayTwentyOne (testInputFile);
		}

		public static DayTwentyOne Puzzle ()
		{
			return new DayTwentyOne (puzzleInputFile);
		}

		const string testInputFile = "../../Inputs/2017/Day21TestInput.txt";
		const string puzzleInputFile = "../../Inputs/2017/Day21Input.txt";

		string image;
		string [] rules;

		public DayTwentyOne (string stream)
		{
			image = ".#./..#/###";
			rules = System.IO.File.ReadAllLines (stream);
		}

		public void PerformIterations (int iterations)
		{
			for (int i = 0; i < iterations; i++)
				Iterate ();
		}

		public int GetOnPixels ()
		{
			return image.Count (x => x == '#');
		}

		private string Iterate ()
		{
			int rowLength = image.Split ('/') [0].Length;
			List<string> chunks = new List<string> ();
			int chunkSize;
			int chunksPerRow;
			if (rowLength % 2 == 0)
			{
				chunkSize = 2;
				chunksPerRow = rowLength / 2;
				chunks = GetChunks (2);
			}
			else
			{
				chunkSize = 3;
				chunksPerRow = rowLength / 3;
				chunks = GetChunks (3);
			}
			string [] lines = new string [(chunkSize + 1) * chunksPerRow];
			for (int i = 0; i < lines.Length; i++)
				lines [i] = "";
			int row = -1;
			for (int i = 0; i < chunks.Count; i++)
			{
				if (i % chunksPerRow == 0)
					row++;
				string rule = FindRuleForChunk (chunks [i]);
				string [] outputSplit = rule.Split (' ') [2].Split ('/');
				for (int j = 0; j < outputSplit.Length; j++)
					lines [(row * (chunkSize + 1)) + j] += outputSplit [j];
			}
			image = string.Join ("/", lines);
			return image;
		}

		private List<string> GetChunks (int chunkSize)
		{
			List<string> chunks = new List<string> ();
			string [] lines = image.Split ('/');
			for (int i = 0; i < lines.Length; i += chunkSize)
			{
				for (int j = 0; j < lines [i].Length; j += chunkSize)
				{
					string chunk = "";
					for (int k = 0; k < chunkSize; k++)
					{
						for (int m = 0; m < chunkSize; m++)
						{
							chunk += lines [i + k] [j + m];
						}
						if (k != chunkSize - 1) chunk += "/";
					}
					chunks.Add (chunk);
				}
			}
			return chunks;
		}

		private string FindRuleForChunk (string chunk)
		{
			for (int i = 0; i < rules.Length; i++)
			{
				string inPattern = rules [i].Split (' ') [0];
				string flippedIn = FlipRule (inPattern);
				for (int j = 0; j < 4; j++)
				{
					if (inPattern == chunk || flippedIn == chunk)
						return rules [i];
					inPattern = RotateRuleClockwise (inPattern);
					flippedIn = RotateRuleClockwise (flippedIn);
				}
			}
			throw new Exception ("Rule for " + chunk + " does not exist");
		}

		private string FlipRule (string rule)
		{
			string [] split = rule.Split ('/');
			for (int i = 0; i < split.Length; i++)
				split [i] = new string (split [i].Reverse ().ToArray ());
			return string.Join ("/", split);
		}

		private string RotateRuleClockwise (string rule)
		{
			string [] split = rule.Split ('/');
			string [] rtrn = new string [split.Length];
			for (int i = 0; i < split.Length; i++)
				rtrn [i] = "";
			for (int i = 0; i < split.Length; i++)
				for (int j = split.Length - 1; j > -1; j--)
				{
					rtrn [i] += split [j] [i];
				}
			return string.Join ("/", rtrn);
		}
	}
}
