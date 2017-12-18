using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utilities
{
	// TODO: Clean this up
	public static class KnotHash
	{
		static int twistIterations = 64;
		static int [] addlLengths = new int [] { 17, 31, 73, 47, 23 };

		private static List<int> GetBaseHash ()
		{
			List<int> hash = new List<int> ();
			for (int i = 0; i < 256; i++)
				hash.Add (i);
			return hash;
		}

		public static string GenerateHash (string input)
		{
			List<int> hash = GetBaseHash ();

			int [] lengths = GenerateLengthsArray (input);

			hash = Twist (hash, lengths, twistIterations);


			for (int i = 0; i < 10; i++)
				Console.WriteLine (hash [i]);

			List<int> sparseHash = new List<int> ();
			for (int i = 0; i < hash.Count; i += 16)
			{
				sparseHash.Add (hash [i] ^ hash [i + 1] ^ hash [i + 2] ^ hash [i + 3] ^
							   hash [i + 4] ^ hash [i + 5] ^ hash [i + 6] ^ hash [i + 7] ^
							   hash [i + 8] ^ hash [i + 9] ^ hash [i + 10] ^ hash [i + 11] ^
							   hash [i + 12] ^ hash [i + 13] ^ hash [i + 14] ^ hash [i + 15]);
			}
			string hex = "";
			for (int i = 0; i < sparseHash.Count; i++)
				hex += sparseHash [i].ToString ("X").PadLeft (2, '0');

			return hex;
		}

		private static int [] GenerateLengthsArray (string input)
		{
			int [] lengths = new int [input.Length + 5];
			for (int i = 0; i < input.Length; i++)
				lengths [i] = input [i];
			for (int i = 0; i < addlLengths.Length; i++)
				lengths [lengths.Length - 5 + i] = addlLengths [i];
			return lengths;
		}

		private static List<int> Twist (List<int> hash, int [] lengths, int iterations)
		{
			int skipSize = 0;
			int currentPosition = 0;
			for (int k = 0; k < iterations; k++)
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
			return hash;
		}
	}
}
