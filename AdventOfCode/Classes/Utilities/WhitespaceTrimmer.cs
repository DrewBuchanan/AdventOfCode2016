using System.Text.RegularExpressions;

namespace AdventOfCode.Utilities
{
	public static class WhitespaceTrimmer
	{
		static readonly Regex trimmer = new Regex (@"\s+");

		public static string Trim (string input)
		{
			return trimmer.Replace (input, " ");
		}
	}
}
