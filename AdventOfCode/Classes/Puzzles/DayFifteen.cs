using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	// TODO: Comment this class
	public class DayFifteen
	{
		public int PartOneTest ()
		{
			string [] input = System.IO.File.ReadAllLines ("Day15TestInput.txt");
			return GetTimeToPush (input);
		}

		public int PartOne ()
		{
			string [] input = System.IO.File.ReadAllLines ("Day15PartOneInput.txt");
			return GetTimeToPush (input);
		}

		public int PartTwo ()
		{
			string [] input = System.IO.File.ReadAllLines ("Day15PartTwoInput.txt");
			return GetTimeToPush (input);
		}

		int GetTimeToPush (string [] input)
		{
			Disc [] discs = new Disc [input.Length];
			for (int i = 0; i < discs.Length; i++)
			{
				string [] split = input [i].Split (' ');
				int numPos = int.Parse (split [3]);
				int startPos = int.Parse (split [11].Replace (".", ""));
				discs [i] = new Disc (numPos, startPos);
			}
			int t = 0;
			bool haveCapsule = false;
			while (!haveCapsule)
			{
				t++;
				for (int j = 0; j < discs.Length; j++)
					discs [j].Evaluate (t);
				for (int i = 0; i < discs.Length; i++)
				{
					for (int j = 0; j < discs.Length; j++)
						discs [j].Tick ();
					if (discs [i].currentPosition != 0)
						break;
					else if (i == discs.Length - 1)
					{
						haveCapsule = true;
						break;
					}
				}
				for (int i = 0; i < discs.Length; i++)
					discs [i].Reset ();
			}
			return t;
		}
	}

	// TODO: Comment this struct
	struct Disc
	{
		public int numPositions;
		public int currentPosition;
		public int startPosition;

		public Disc (int numPositions, int startPosition)
		{
			this.numPositions = numPositions;
			this.startPosition = startPosition;
			currentPosition = this.startPosition;
		}

		public void Evaluate (int t)
		{
			currentPosition = (startPosition + t) % numPositions;
		}

		public void Tick ()
		{
			currentPosition = (currentPosition + 1) % numPositions;
		}

		public void Reset ()
		{
			currentPosition = startPosition;
		}
	}
}
