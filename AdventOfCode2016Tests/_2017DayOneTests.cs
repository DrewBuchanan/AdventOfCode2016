using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2016Tests
{
	[TestClass]
	public class _2017DayOneTests
	{
		[TestMethod]
		public void PartOne_1122_Produces_Solution_3 ()
		{
			int three = AdventOfCode.Puzzles._2017.DayOne.Solve ("1122", 1);
			Assert.AreEqual (3, three);
		}

		[TestMethod]
		public void PartOne_1111_Produces_Solution_4 ()
		{
			int four = AdventOfCode.Puzzles._2017.DayOne.Solve ("1111", 1);
			Assert.AreEqual (4, four);
		}

		[TestMethod]
		public void PartOne_1234_Produces_Solution_0 ()
		{
			int zero = AdventOfCode.Puzzles._2017.DayOne.Solve ("1234", 1);
			Assert.AreEqual (0, zero);
		}

		[TestMethod]
		public void PartOne_91212129_Produces_Solution_9 ()
		{
			int nine = AdventOfCode.Puzzles._2017.DayOne.Solve ("91212129", 1);
			Assert.AreEqual (9, nine);
		}

		[TestMethod]
		public void PartTwo_1212_Produces_Solution_6 ()
		{
			string sequence = "1212";
			int six = AdventOfCode.Puzzles._2017.DayOne.Solve (sequence, sequence.Length / 2);
			Assert.AreEqual (6, six);
		}

		[TestMethod]
		public void PartTwo_1221_Produces_Solution_0 ()
		{
			string sequence = "1221";
			int zero = AdventOfCode.Puzzles._2017.DayOne.Solve (sequence, sequence.Length / 2);
			Assert.AreEqual (0, zero);
		}

		[TestMethod]
		public void PartTwo_123425_Produces_Solution_4 ()
		{
			string sequence = "123425";
			int four = AdventOfCode.Puzzles._2017.DayOne.Solve (sequence, sequence.Length / 2);
			Assert.AreEqual (4, four);
		}

		[TestMethod]
		public void PartTwo_123123_Produces_Solution_12 ()
		{
			string sequence = "123123";
			int twelve = AdventOfCode.Puzzles._2017.DayOne.Solve (sequence, sequence.Length / 2);
			Assert.AreEqual (12, twelve);
		}

		[TestMethod]
		public void PartTwo_12131415_Produces_Solution_4 ()
		{
			string sequence = "12131415";
			int four = AdventOfCode.Puzzles._2017.DayOne.Solve (sequence, sequence.Length / 2);
			Assert.AreEqual (4, four);
		}
	}
}
