using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2016Tests
{
	[TestClass]
	public class DaySixteenTests
	{
		[TestMethod]
		public void Dragon_1_Becomes_100 ()
		{
			string one = AdventOfCode.Puzzles.DaySixteen.Dragon ("1");
			Assert.AreEqual ("100", one);
		}

		[TestMethod]
		public void Dragon_0_Becomes_001 ()
		{
			string zero = AdventOfCode.Puzzles.DaySixteen.Dragon ("0");
			Assert.AreEqual ("001", zero);
		}

		[TestMethod]
		public void Dragon_11111_Becomes_11111000000 ()
		{
			string output = AdventOfCode.Puzzles.DaySixteen.Dragon ("11111");
			Assert.AreEqual ("11111000000", output);
		}

		[TestMethod]
		public void Dragon_Complex_Processes_Properly ()
		{
			string output = AdventOfCode.Puzzles.DaySixteen.Dragon ("111100001010");
			Assert.AreEqual ("1111000010100101011110000", output);
		}

		[TestMethod]
		public void Checksum ()
		{
			string checksum = AdventOfCode.Puzzles.DaySixteen.GenerateChecksum ("110010110100");
			Assert.AreEqual ("100", checksum);
		}
	}
}
