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
			int three = AdventOfCode.Puzzles._2017.DayOne.PartOneSolve ("1122");
			Assert.AreEqual (3, three);
		}

		[TestMethod]
		public void PartOne_1111_Produces_Solution_4 ()
		{
			int four = AdventOfCode.Puzzles._2017.DayOne.PartOneSolve ("1111");
			Assert.AreEqual (4, four);
		}

		[TestMethod]
		public void PartOne_1234_Produces_Solution_0 ()
		{
			int zero = AdventOfCode.Puzzles._2017.DayOne.PartOneSolve ("1234");
			Assert.AreEqual (0, zero);
		}

		[TestMethod]
		public void PartOne_91212129_Produces_Solution_9 ()
		{
			int nine = AdventOfCode.Puzzles._2017.DayOne.PartOneSolve ("91212129");
			Assert.AreEqual (9, nine);
		}

		[TestMethod]
		public void PartTwo_1212_Produces_Solution_6 ()
		{
			int six = AdventOfCode.Puzzles._2017.DayOne.PartTwoSolve ("1212");
			Assert.AreEqual (6, six);
		}

		[TestMethod]
		public void PartTwo_1221_Produces_Solution_0 ()
		{
			int zero = AdventOfCode.Puzzles._2017.DayOne.PartTwoSolve ("1221");
			Assert.AreEqual (0, zero);
		}

		[TestMethod]
		public void PartTwo_123425_Produces_Solution_4 ()
		{
			int four = AdventOfCode.Puzzles._2017.DayOne.PartTwoSolve ("123425");
			Assert.AreEqual (4, four);
		}

		[TestMethod]
		public void PartTwo_123123_Produces_Solution_12 ()
		{
			int twelve = AdventOfCode.Puzzles._2017.DayOne.PartTwoSolve ("123123");
			Assert.AreEqual (12, twelve);
		}

		[TestMethod]
		public void PartTwo_12131415_Produces_Solution_4 ()
		{
			int four = AdventOfCode.Puzzles._2017.DayOne.PartTwoSolve ("12131415");
			Assert.AreEqual (4, four);
		}
	}
}
