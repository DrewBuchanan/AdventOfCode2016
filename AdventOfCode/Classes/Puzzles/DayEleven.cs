using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	// Generators can coexist
	// Microchips can coexist
	// Generators and microchips can only coexist if they share an element
	public class DayEleven
	{
		public int Test ()
		{
			return 0;
		}
	}

	public struct State
	{
		public State (int floor, ulong floorItems, int steps)
		{
			Floor = floor;
			FloorItems = floorItems;
			Steps = steps;
		}

		public int Floor { get; }
		public ulong FloorItems { get; }
		public int Steps { get; }

		public State? Move (int dir, int item1, int item2 = -1)
		{
			return null;
		}

		public bool Equals (State other)
		{
			return other.FloorItems == FloorItems && other.Floor == Floor;
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj))
				return false;
			if (ReferenceEquals (this, obj))
				return true;
			if (obj.GetType () != GetType ())
				return false;
			return Equals ((State)obj);
		}

		public override int GetHashCode ()
		{
			return unchecked((Floor * 397) ^ FloorItems.GetHashCode ());
		}
	}
}
