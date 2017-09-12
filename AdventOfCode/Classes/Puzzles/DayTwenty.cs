using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	public class DayTwenty
	{
		public uint Test ()
		{
			string [] input = System.IO.File.ReadAllLines ("Day20TestInput.txt");
			Blacklist blacklist = new Blacklist (input);
			bool found = false;
			uint minimum = uint.MaxValue;
			uint index = 0;
			while (!found)
			{
				if (!blacklist.IsBlocked (index))
				{
					minimum = index;
					found = true;
				}
				index++;
			}
			return minimum;
		}

		public uint PartOne ()
		{
			string [] input = System.IO.File.ReadAllLines ("Day20Input.txt");
			Blacklist blacklist = new Blacklist (input);
			bool found = false;
			uint minimum = uint.MaxValue;
			uint index = 0;
			while (!found)
			{
				if (!blacklist.IsBlocked (index))
				{
					minimum = index;
					found = true;
				}
				index++;
			}
			return minimum;
		}

		public uint PartTwo ()
		{
			string [] input = System.IO.File.ReadAllLines ("Day20Input.txt");
			Blacklist blacklist = new Blacklist (input);
			uint found = 0;
			uint index = 0;
			while (index < uint.MaxValue)
			{
				if (!blacklist.IsBlocked (index))
				{
					found++;
					index = blacklist.GetNextUnblockedIP (index + 1);
					//Console.WriteLine ("Index: {0:n0}", index);
					continue;
				}
				index++;

				if (index % 10000 == 0)
				{
					Console.SetCursorPosition (0, 0);
					Console.WriteLine ("Index: {0:n0}", index);
				}

			}
			return found;
		}

		public class Blacklist
		{
			public List<Range> ranges;
			public HashSet<uint> blockedIps;
			public Blacklist (string [] input)
			{
				ranges = new List<Range> ();
				for (int i = 0; i < input.Length; i++)
				{
					string [] range = input [i].Split ('-');
					ranges.Add (new Range (uint.Parse (range [0]), uint.Parse (range [1])));
					ranges.Sort (delegate (Range r1, Range r2) { return r1.min.CompareTo (r2.min); });
				}
			}

			public bool IsBlocked (uint ip)
			{
				for (int i = 0; i < ranges.Count; i++)
					if (ranges [i].Contains (ip))
						return true;
				return false;
			}

			public uint GetNextUnblockedIP (uint ip)
			{
				for (int i = 0; i < ranges.Count; i++)
					if (ip >= ranges [i].min && ip <= ranges [i].max && i < ranges.Count - 1)
						return ranges [i + 1].max;
				return ip;
			}
		}

		public struct Range
		{
			public uint min;
			public uint max;

			public Range (uint min, uint max)
			{
				this.min = min;
				this.max = max;
			}

			public bool Contains (uint i)
			{
				return i >= min && i <= max;
			}
		}
	}
}
