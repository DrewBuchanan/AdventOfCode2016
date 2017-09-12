using System;
using System.Collections.Generic;

namespace AdventOfCode.Puzzles
{
	public class DayTwenty
	{
		/// <summary>
		/// Finds the lowest-valued IP based on test input
		/// </summary>
		/// <returns>lowest valued IP</returns>
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

		/// <summary>
		/// Finds the lowest-valued IP based on puzzle input
		/// </summary>
		/// <returns>lowest valued IP</returns>
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

		/// <summary>
		/// Finds number of valid IPs based on puzzle input
		/// </summary>
		/// <returns>number of valid IPs</returns>
		public uint PartTwo ()
		{
			string [] input = System.IO.File.ReadAllLines ("Day20Input.txt");
			Blacklist blacklist = new Blacklist (input);
			uint found = 0;
			uint index = 0;
			while (index < uint.MaxValue)
			{
				if (blacklist.IsBlocked (index))
				{
					index = blacklist.GetNextUnblockedIP (index);
					if (index == 0)
						index = uint.MaxValue;
					continue;
				}
				found++;
				index++;
			}

			return found;
		}

		/// <summary>
		/// Contains all blocked IPs in a list of ranges
		/// </summary>
		public class Blacklist
		{
			public List<Range> ranges;

			/// <summary>
			/// Generates a list of ranges of blocked IPs and merges those that overlap
			/// </summary>
			/// <param name="input">list of ranges of blocked IPs in the form of "min-max"</param>
			public Blacklist (string [] input)
			{
				ranges = new List<Range> ();
				for (int i = 0; i < input.Length; i++)
				{
					string [] range = input [i].Split ('-');
					ranges.Add (new Range (uint.Parse (range [0]), uint.Parse (range [1])));
				}
				// Sort ranges based on min value
				ranges.Sort (delegate (Range r1, Range r2) { return r1.min.CompareTo (r2.min); });
				// Merge all ranges that overlap
				// This removed over 800 ranges with my input
				for (int i = 0; i < ranges.Count - 1; i++)
				{
					if (ranges [i].OverlapsWith (ranges [i + 1]))
					{
						ranges [i] = ranges [i].Merge (ranges [i + 1]);
						ranges.Remove (ranges [i + 1]);
						i--;
					}
				}
			}

			/// <summary>
			/// Determines if an IP is blocked
			/// </summary>
			/// <param name="ip">the IP to check</param>
			/// <returns>true if blocked, false if not</returns>
			public bool IsBlocked (uint ip)
			{
				for (int i = 0; i < ranges.Count; i++)
					if (ranges [i].Contains (ip))
						return true;
				return false;
			}

			/// <summary>
			/// Returns the next IP that isn't in a blocked range
			/// </summary>
			/// <param name="ip">first blocked IP</param>
			/// <returns>the next unblocked IP</returns>
			public uint GetNextUnblockedIP (uint ip)
			{
				for (int i = 0; i < ranges.Count; i++)
					if (ip >= ranges [i].min && ip <= ranges [i].max && i < ranges.Count)
						return ranges [i].max + 1;
				return ip;
			}

			/// <summary>
			/// Outputs ranges to console, used for debugging, here for completeness
			/// </summary>
			public void PrintRanges ()
			{
				for (int i = 0; i < ranges.Count; i++)
					Console.WriteLine (ranges [i].ToString ());
			}
		}

		/// <summary>
		/// Contains a minimum and a maximum
		/// </summary>
		public class Range
		{
			public uint min;
			public uint max;

			public Range (uint min, uint max)
			{
				this.min = min;
				this.max = max;
			}

			/// <summary>
			/// Determines if i is within this range
			/// </summary>
			/// <param name="i">IP to check</param>
			/// <returns>true if within range, false if not</returns>
			public bool Contains (uint i)
			{
				return i >= min && i <= max;
			}

			/// <summary>
			/// Checks if this overlaps with other
			/// </summary>
			/// <param name="other">the other Range</param>
			/// <returns>true if this and other overlap</returns>
			public bool OverlapsWith (Range other)
			{
				return this.max > other.min && this.min < other.max;
			}

			/// <summary>
			/// Merges this and other into one range
			/// </summary>
			/// <param name="other">the other range</param>
			/// <returns>the merged range</returns>
			public Range Merge (Range other)
			{
				uint min = this.min > other.min ? other.min : this.min;
				uint max = this.max < other.max ? other.max : this.max;
				return new Range (min, max);
			}

			/// <summary>
			/// Converts the range to display a min and a max, used for debugging, here for completeness
			/// </summary>
			/// <returns>string representation of this range</returns>
			public override string ToString ()
			{
				return min.ToString () + "-" + max.ToString ();
			}
		}
	}
}
