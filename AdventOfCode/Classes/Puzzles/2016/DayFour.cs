using AdventOfCode.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Puzzles
{
	public class DayFour
	{
		List<string> realRooms;
		string [] input;

		public DayFour ()
		{
			Initialize ();
		}

		/// <summary>
		/// Initializes realRooms and loads input file
		/// </summary>
		public void Initialize ()
		{
			realRooms = new List<string> ();
			input = System.IO.File.ReadAllLines ("../../Inputs/Day04Input.txt");
		}

		/// <summary>
		/// Finds all real rooms, then sums the sector IDs and returns the sum
		/// </summary>
		/// <returns>returns sum of real rooms</returns>
		public int PartOne ()
		{
			realRooms = GetRealRooms (input);

			int sum = 0;
			for (int i = 0; i < realRooms.Count; i++)
			{
				sum += GetSectorID (realRooms [i]);
			}
			return sum;
		}

		/// <summary>
		/// Finds all real rooms, decrypts their names, then finds the sector ID with north pole storage
		/// </summary>
		/// <returns></returns>
		public int PartTwo ()
		{
			realRooms = GetRealRooms (input);
			for (int i = 0; i < realRooms.Count; i++)
			{
				string decrypted = (Decrypt (realRooms [i]) + " " + GetSectorID (realRooms [i]));
				if (decrypted.Contains ("north") || decrypted.Contains ("pole"))
					return GetSectorID (realRooms [i]);
			}
			return 0;
		}

		/// <summary>
		/// Iterates over rooms to find the rooms that are real
		/// </summary>
		/// <param name="rooms">list of room names</param>
		/// <returns>List of valid room names</returns>
		List<string> GetRealRooms (string [] rooms)
		{
			List<string> rtrn = new List<string> ();
			for (int i = 0; i < rooms.Length; i++)
			{
				if (IsRealRoom (rooms [i]))
					rtrn.Add (rooms [i]);
			}
			return rtrn;
		}

		/// <summary>
		/// Turns roomName into something readable by humans
		/// </summary>
		/// <param name="roomName">full name of a single room</param>
		/// <returns>Human readable name of room</returns>
		string Decrypt (string roomName)
		{
			string decrypted = "";
			for (int i = 0; i < roomName.Length; i++)
			{
				if (char.IsLetter (roomName [i]))
				{
					int sectorId = GetSectorID (roomName);
					int modulo = sectorId % 26;
					decrypted += AlphaFreqDict.alphabet [(AlphaFreqDict.alphabet.IndexOf (roomName [i]) + modulo) % 26];
				}
				else if (roomName [i] == '-')
					decrypted += ' ';
			}
			return decrypted;
		}

		/// <summary>
		/// Uses checksum to determine whether roomName is real
		/// </summary>
		/// <param name="roomName">full name of a single room</param>
		/// <returns>returns true if room is real, false if not</returns>
		bool IsRealRoom (string roomName)
		{
			string checkSum = GetCheckSum (roomName);
			Dictionary<char, int> letterFrequencies = AlphaFreqDict.GetLetterFrequencyDictionary ();
			for (int i = 0; i < roomName.Length; i++)
			{
				if (char.IsLetter (roomName [i]))
					letterFrequencies [roomName [i]]++;
				if (char.IsNumber (roomName [i]))
					break;
			}
			for (int i = 0; i < AlphaFreqDict.alphabet.Length; i++)
			{
				if (letterFrequencies [AlphaFreqDict.alphabet [i]] == 0)
					letterFrequencies.Remove (AlphaFreqDict.alphabet [i]);
			}
			List<KeyValuePair<char, int>> sortable = letterFrequencies.ToList ();
			sortable.Sort (
				delegate (KeyValuePair<char, int> pair1, KeyValuePair<char, int> pair2)
				{
					int count = pair1.Value.CompareTo (pair2.Value);
					if (count != 0)
						return count;
					else
						return -pair1.Key.CompareTo (pair2.Key);
				});
			sortable.Reverse ();
			for (int i = 0; i < checkSum.Length; i++)
			{
				if (checkSum [i] != sortable [i].Key)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Returns checksum of roomName
		/// </summary>
		/// <param name="roomName">full name of a single room</param>
		/// <returns>string checksum used for validation</returns>
		string GetCheckSum (string roomName)
		{
			string checkSum = "";
			bool inBrace = false;
			for (int i = 0; i < roomName.Length; i++)
			{
				if (roomName [i] == '[')
				{
					inBrace = true;
					continue;
				}
				else if (roomName [i] == ']')
					return checkSum;
				if (inBrace)
					checkSum += roomName [i];
			}
			return checkSum;
		}

		/// <summary>
		/// Returns Sector ID of roomName
		/// </summary>
		/// <param name="roomName">full name of a single room</param>
		/// <returns>int sector ID used for identification</returns>
		int GetSectorID (string roomName)
		{
			string sectorID = "";
			bool inSector = false;
			for (int i = 0; i < roomName.Length; i++)
			{
				if (char.IsNumber (roomName [i]))
					inSector = true;
				else if (roomName [i] == '[')
					return int.Parse (sectorID);
				if (inSector)
					sectorID += roomName [i];
			}
			return int.Parse (sectorID);
		}
	}
}
