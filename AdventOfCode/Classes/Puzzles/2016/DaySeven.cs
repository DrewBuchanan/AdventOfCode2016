using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: Comment the rest of this file and remove excess usings
namespace AdventOfCode.Puzzles
{
	public class DaySeven
	{
		int valid;
		string [] ips;

		public DaySeven ()
		{
			Initialize ();
		}

		/// <summary>
		/// Reads input and initializes valid IPs to 0
		/// </summary>
		void Initialize ()
		{
			valid = 0;
			ips = System.IO.File.ReadAllLines ("../../Inputs/Day07Input.txt");
		}

		/// <summary>
		/// Determines number of IPs that support TLS
		/// </summary>
		/// <returns>number of valid IPs</returns>
		public int PartOne ()
		{
			for (int i = 0; i < ips.Length; i++)
			{
				if (SupportsTLS (ips [i]))
					valid++;
			}
			return valid;
		}
		/// <summary>
		/// Checks whether ip supports TLS
		/// <para>must have ABBA outside of braces and no ABBA inside of braces</para>
		/// </summary>
		/// <param name="ip">the ip to check</param>
		/// <returns>true if ip supports TLS, false if it doesn't</returns>
		bool SupportsTLS (string ip)
		{
			bool hasOuter = false;
			bool hasInner = false;
			bool inBraces = false;
			for (int i = 0; i < ip.Length - 4; i++)
			{
				if (ip [i] == '[')
				{
					inBraces = true;
					i += 3;
					continue;
				}
				else if (ip [i] == ']')
				{
					inBraces = false;
					continue;
				}
				string check = ip.Substring (i, 4);
				if (IsAbba (check))
				{
					if (inBraces) hasInner = true;
					else hasOuter = true;
				}
			}
			return !hasInner && hasOuter;
		}
		/// <summary>
		/// Checks whether a 4 character string matches the ABBA pattern
		/// </summary>
		/// <param name="potAbba">the 4 character string</param>
		/// <returns>true if potAbba matches pattern, false if not</returns>
		bool IsAbba (string potAbba)
		{
			if (potAbba.Length != 4)
				throw new ArgumentException ("potAbba passed to IsAbba(string) must be 4 characters.");
			return (potAbba [0] == potAbba [3] &&
				potAbba [1] == potAbba [2] &&
				potAbba [0] != potAbba [1]);
		}

		/// <summary>
		/// Determines number of IPs that support SSL
		/// </summary>
		/// <returns>number of valid IPs</returns>
		public int PartTwo ()
		{
			for (int i = 0; i < ips.Length; i++)
			{
				if (SupportsSSL (ips [i]))
					valid++;
			}
			return valid;
		}
		/// <summary>
		/// Checks whether ip supports SSL
		/// </summary>
		/// <param name="ip">the IP address to check</param>
		/// <returns>true if ip supports SSL, false if it doesn't</returns>
		bool SupportsSSL (string ip)
		{
			List<string> abas = new List<string> ();
			List<string> babs = new List<string> ();
			// Splits ip into chunks for easier processing
			string [] chunks = ip.Replace ('[', '-').Replace (']', '-').Split ('-');

			// Iterates over chunks outside of braces and stores all ABAs
			for (int i = 0; i < chunks.Length; i += 2)
				abas.AddRange (GetAbas (chunks [i]));

			// Iterates over chunks inside of braces and stores all BABs
			for (int i = 1; i < chunks.Length; i += 2)
				babs.AddRange (GetAbas (chunks [i]));

			// If one ABA has a matching BAB, return true, otherwise return false
			if (AbasCorrespondWithBabs (abas, babs))
				return true;
			return false;
		}
		/// <summary>
		/// <para>Iterates over a list of ABAs and BABs and determines if there is one corresponding pair</para>
		/// <para>(i.e. xyx and yxy produces true)</para>
		/// </summary>
		/// <param name="abas">list of abas</param>
		/// <param name="babs">list of babs</param>
		/// <returns>returns true if corresponding pair, false if not</returns>
		bool AbasCorrespondWithBabs (List<string> abas, List<string> babs)
		{
			bool hasMatch = false;
			for (int i = 0; i < abas.Count; i++)
			{
				for (int j = 0; j < babs.Count; j++)
				{
					if (abas [i] [0] == babs [j] [1] && babs [j] [0] == abas [i] [1])
					{
						hasMatch = true;
						break;
					}
				}
				if (hasMatch)
					break;
			}
			return hasMatch;
		}
		/// <summary>
		/// Returns all ABAs in chunk
		/// </summary>
		/// <param name="chunk">chunk to process</param>
		/// <returns>List of ABAs in chunk</returns>
		List<string> GetAbas (string chunk)
		{
			List<string> abas = new List<string> ();
			for (int i = 0; i < chunk.Length - 2; i++)
			{
				string subChunk = chunk.Substring (i, 3);
				if (IsAba (subChunk))
					abas.Add (subChunk);
			}
			return abas;
		}
		/// <summary>
		/// Checks whether a 3 character string matches the ABA pattern
		/// </summary>
		/// <param name="potAba">the 3 character string</param>
		/// <returns>true of potAba matches pattern, false if not</returns>
		bool IsAba (string potAba)
		{
			if (potAba.Length != 3)
				throw new ArgumentException ("potAba passed to IsAba(string) must be 3 characters.");
			return potAba [0] == potAba [2] &&
				potAba [0] != potAba [1];
		}
	}
}
