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
	public class _2017DaySixTests
	{
		[TestMethod]
		public void Redistribute_0_2_7_0_Produces_2_4_1_2 ()
		{
			int [] banks = new int [] { 0, 2, 7, 0 };
			banks = DaySix.Iterate (banks);
			CollectionAssert.AreEqual (new int [] { 2, 4, 1, 2 }, banks);
		}

		[TestMethod]
		public void Redistribute_2_4_1_2_Produces_3_1_2_3 ()
		{
			int [] banks = new int [] { 2, 4, 1, 2 };
			banks = DaySix.Iterate (banks);
			CollectionAssert.AreEqual (new int [] { 3, 1, 2, 3 }, banks);
		}

		[TestMethod]
		public void Redistribute_3_1_2_3_Produces_0_2_3_4 ()
		{
			int [] banks = new int [] { 3, 1, 2, 3 };
			banks = DaySix.Iterate (banks);
			CollectionAssert.AreEqual (new int [] { 0, 2, 3, 4 }, banks);
		}

		[TestMethod]
		public void Test_Input_Repeats_After_5_Iterations ()
		{
			int [] banks = new int [] { 0, 2, 7, 0 };
			int iterations = DaySix.IterateUntilRepeatedState (banks);
			Assert.AreEqual (5, iterations);
		}
	}
}
