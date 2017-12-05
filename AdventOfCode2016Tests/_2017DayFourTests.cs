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
	public class _2017DayFourPartOneTests
	{
		string test1 = "aa bb cc dd ee";
		string test2 = "aa bb cc dd aa";
		string test3 = "aa bb cc dd aaa";
		
		[TestMethod]
		public void Test_1_Is_Valid ()
		{
			bool isValid = DayFour.DontShareWords (test1);
			Assert.AreEqual (true, isValid);
		}

		[TestMethod]
		public void Test_2_Is_Valid ()
		{
			bool isValid = DayFour.DontShareWords (test2);
			Assert.AreEqual (false, isValid);
		}

		[TestMethod]
		public void Test_3_Is_Valid ()
		{
			bool isValid = DayFour.DontShareWords (test3);
			Assert.AreEqual (true, isValid);
		}
	}

	[TestClass]
	public class _2017DayFourPartTwoTests
	{
		string test4 = "abcde fghij";
		string test5 = "abcde xyz ecdab";
		string test6 = "a ab abc abd abf abj";
		string test7 = "iiii oiii ooii oooi oooo";
		string test8 = "oiii ioii iioi iiio";

		[TestMethod]
		public void Test_4_Is_Valid ()
		{
			bool isValid = DayFour.DoesntContainAnagrams (test4);
			Assert.AreEqual (true, isValid);
		}

		[TestMethod]
		public void Test_5_Is_Valid ()
		{
			bool isValid = DayFour.DoesntContainAnagrams (test5);
			Assert.AreEqual (false, isValid);
		}

		[TestMethod]
		public void Test_6_Is_Valid ()
		{
			bool isValid = DayFour.DoesntContainAnagrams (test6);
			Assert.AreEqual (true, isValid);
		}

		[TestMethod]
		public void Test_7_Is_Valid ()
		{
			bool isValid = DayFour.DoesntContainAnagrams (test7);
			Assert.AreEqual (true, isValid);
		}

		[TestMethod]
		public void Test_8_Is_Valid ()
		{
			bool isValid = DayFour.DoesntContainAnagrams (test8);
			Assert.AreEqual (false, isValid);
		}
	}
}
