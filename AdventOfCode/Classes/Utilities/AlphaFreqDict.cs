using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Utilities
{
	public static class AlphaFreqDict
	{
		public static string alphabet = "abcdefghijklmnopqrstuvwxyz";

		public static Dictionary<char, int> GetLetterFrequencyDictionary ()
		{
			Dictionary<char, int> letterFrequencies = new Dictionary<char, int> ();
			for (int i = 0; i < alphabet.Length; i++)
				letterFrequencies.Add (alphabet [i], 0);
			return letterFrequencies;
		}

		public static char GetLeastFrequentCharacter (string characters)
		{
			List<KeyValuePair<char, int>> sortable = GenerateFrequencies (characters);
			return sortable [0].Key;
		}

		public static char GetMostFrequentCharacter (string characters)
		{
			List<KeyValuePair<char, int>> sortable = GenerateFrequencies (characters);
			sortable.Reverse ();
			return sortable [0].Key;
		}

		public static List<KeyValuePair<char, int>> GenerateFrequencies (string characters)
		{
			Dictionary<char, int> freqs = GetLetterFrequencyDictionary ();
			for (int i = 0; i < characters.Length; i++)
			{
				freqs [characters [i]]++;
			}
			for (int i = 0; i < alphabet.Length; i++)
			{
				if (freqs [alphabet [i]] == 0)
					freqs.Remove (alphabet [i]);
			}
			List<KeyValuePair<char, int>> sortable = freqs.ToList ();
			sortable.Sort (
				delegate (KeyValuePair<char, int> pair1, KeyValuePair<char, int> pair2)
				{
					int count = pair1.Value.CompareTo (pair2.Value);
					if (count != 0)
						return count;
					else
						return -pair1.Key.CompareTo (pair2.Key);
				});
			return sortable;
		}
	}
}
