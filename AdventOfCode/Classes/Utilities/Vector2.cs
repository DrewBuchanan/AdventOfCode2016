using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utilities
{
	public struct Vector2
	{
		public int x;
		public int y;
		public Vector2 (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals (object obj)
		{
			return obj is Vector2 && this == (Vector2)obj;
		}

		public override int GetHashCode ()
		{
			return x.GetHashCode () ^ y.GetHashCode ();
		}

		public static bool operator == (Vector2 x, Vector2 y)
		{
			return x.x == y.x && x.y == y.y;
		}

		public static bool operator != (Vector2 x, Vector2 y)
		{
			return !(x == y);
		}

		public override string ToString ()
		{
			return "(" + x + ", " + y + ")";
		}
	}
}
