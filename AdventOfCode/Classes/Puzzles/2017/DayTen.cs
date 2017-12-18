using System;
using System.Collections.Generic;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTen
	{
		string stringInput = "212,254,178,237,2,0,1,54,167,92,117,125,255,61,159,164";
		int [] lengths = new int [] { 212, 254, 178, 237, 2, 0, 1, 54, 167, 92, 117, 125, 255, 61, 159, 164 };
		int [] addlLengths = new int [] { 17, 31, 73, 47, 23 };

		List<int> hash = new List<int> ();
		int skipSize = 0;
		int currentPosition = 0;

		public DayTen ()
		{
			for (int i = 0; i < 256; i++)
				hash.Add (i);
		}

		public string Test ()
		{
			hash = new List<int> ();
			for (int i = 0; i < 5; i++)
				hash.Add (i);
			lengths = new int [] { 3, 4, 1, 5 };
			Process ();
			return string.Join (",", hash);
		}

		public int PartOne ()
		{
			Process ();
			return hash [0] * hash [1];
		}

		public void PartTwo ()
		{
			Utilities.KnotHash knotHash = new Utilities.KnotHash (stringInput);
			string hex = knotHash.GenerateHash ();
			Console.WriteLine (hex);
			System.Windows.Clipboard.SetText (hex);
		}

		private void Process ()
		{
			for (int i = 0; i < lengths.Length; i++)
			{
				List<int> toReverse = new List<int> ();
				for (int j = 0; j < lengths [i]; j++)
				{
					toReverse.Add (hash [(currentPosition + j) % hash.Count]);
				}
				toReverse.Reverse ();
				for (int j = 0; j < toReverse.Count; j++)
				{
					hash [(currentPosition + j) % hash.Count] = toReverse [j];
				}

				currentPosition = (currentPosition + lengths [i] + skipSize) % hash.Count;
				skipSize++;
			}
		}
	}
}
