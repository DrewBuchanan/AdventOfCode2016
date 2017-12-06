using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Puzzles._2017;

namespace AdventOfCode2016Tests
{
	[TestClass]
	public class _2017DayFiveTests
	{
		int [] testInput = new int [] { 0, 3, 0, 1, -3 };
		[TestMethod]
		public void Test_Input_Returns_5_Steps ()
		{
			int steps = DayFive.Run (testInput);
			Assert.AreEqual (5, steps);
		}

		[TestMethod]
		public void Test_Input_Returns_10_Steps_With_Strange_Enabled ()
		{
			int steps = DayFive.Run (testInput, true);
			Assert.AreEqual (10, steps);
		}
	}
}
