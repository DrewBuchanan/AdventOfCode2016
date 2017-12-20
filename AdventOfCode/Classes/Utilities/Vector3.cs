namespace AdventOfCode.Utilities
{
	public struct Vector3
	{
		public int x;
		public int y;
		public int z;

		public Vector3 (int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public override bool Equals (object obj)
		{
			return obj is Vector3 && this == (Vector3)obj;
		}

		public override int GetHashCode ()
		{
			int hash = 17;
			hash = hash * 23 + x.GetHashCode ();
			hash = hash * 23 + y.GetHashCode ();
			return hash;
		}

		public static Vector3 operator + (Vector3 a, Vector3 b)
		{
			return new Vector3 (a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static bool operator == (Vector3 x, Vector3 y)
		{
			return x.x == y.x && x.y == y.y && x.z == y.z;
		}

		public static bool operator != (Vector3 x, Vector3 y)
		{
			return !(x == y);
		}

		public override string ToString ()
		{
			return "(" + x + ", " + y + ")";
		}
	}
}
