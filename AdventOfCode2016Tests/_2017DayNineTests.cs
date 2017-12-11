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
	public class _2017DayNineTests
	{
		[TestClass]
		public class GroupingTests
		{
			private string test1 = "{}";
			private string test2 = "{{{}}}";
			private string test3 = "{{},{}}";
			private string test4 = "{{{},{},{{}}}}";
			private string test5 = "{<{},{},{{}}>}";
			private string test6 = "{<a>,<a>,<a>,<a>}";
			private string test7 = "{{<a>},{<a>},{<a>},{<a>}}";
			private string test8 = "{{<!>},{<!>},{<!>},{<a>}}";

			[TestMethod]
			public void Test_1_Returns_One_Group ()
			{
				int numberOfGroups = new DayNine (test1).totalGroups;
				Assert.AreEqual (1, numberOfGroups);
			}

			[TestMethod]
			public void Test_2_Returns_Three_Groups ()
			{
				int numberOfGroups = new DayNine (test2).totalGroups;
				Assert.AreEqual (3, numberOfGroups);
			}

			[TestMethod]
			public void Test_3_Returns_Three_Groups ()
			{
				int numberOfGroups = new DayNine (test3).totalGroups;
				Assert.AreEqual (3, numberOfGroups);
			}

			[TestMethod]
			public void Test_4_Returns_Six_Groups ()
			{
				int numberOfGroups = new DayNine (test4).totalGroups;
				Assert.AreEqual (6, numberOfGroups);
			}

			[TestMethod]
			public void Test_5_Returns_One_Group ()
			{
				int numberOfGroups = new DayNine (test5).totalGroups;
				Assert.AreEqual (1, numberOfGroups);
			}

			[TestMethod]
			public void Test_6_Returns_One_Group ()
			{
				int numberOfGroups = new DayNine (test6).totalGroups;
				Assert.AreEqual (1, numberOfGroups);
			}

			[TestMethod]
			public void Test_7_Returns_Five_Groups ()
			{
				int numberOfGroups = new DayNine (test7).totalGroups;
				Assert.AreEqual (5, numberOfGroups);
			}

			[TestMethod]
			public void Test_8_Returns_Two_Groups ()
			{
				int numberOfGroups = new DayNine (test8).totalGroups;
				Assert.AreEqual (2, numberOfGroups);
			}
		}

		[TestClass]
		public class ScoringTests
		{
			private string test1 = "{}";
			private string test2 = "{{{}}}";
			private string test3 = "{{},{}}";
			private string test4 = "{{{},{},{{}}}}";
			private string test5 = "{<a>,<a>,<a>,<a>}";
			private string test6 = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
			private string test7 = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
			private string test8 = "{{<a!>},{<a!>},{<a!>},{<ab>}}";

			[TestMethod]
			public void Test_1_Has_Score_1 ()
			{
				int score = new DayNine (test1).score;
				Assert.AreEqual (1, score);
			}

			[TestMethod]
			public void Test_2_Has_Score_6 ()
			{
				int score = new DayNine (test2).score;
				Assert.AreEqual (6, score);
			}

			[TestMethod]
			public void Test_3_Has_Score_5 ()
			{
				int score = new DayNine (test3).score;
				Assert.AreEqual (5, score);
			}

			[TestMethod]
			public void Test_4_Has_Score_16 ()
			{
				int score = new DayNine (test4).score;
				Assert.AreEqual (16, score);
			}

			[TestMethod]
			public void Test_5_Has_Score_1 ()
			{
				int score = new DayNine (test5).score;
				Assert.AreEqual (1, score);
			}

			[TestMethod]
			public void Test_6_Has_Score_9 ()
			{
				int score = new DayNine (test6).score;
				Assert.AreEqual (9, score);
			}

			[TestMethod]
			public void Test_7_Has_Score_9 ()
			{
				int score = new DayNine (test7).score;
				Assert.AreEqual (9, score);
			}

			[TestMethod]
			public void Test_8_Has_Score_3 ()
			{
				int score = new DayNine (test8).score;
				Assert.AreEqual (3, score);
			}
		}

		[TestClass]
		public class GarbageTests
		{
			private string test1 = "<>";
			private string test2 = "<random characters>";
			private string test3 = "<<<<>";
			private string test4 = "<{!>}>";
			private string test5 = "<!!>";
			private string test6 = "<!!!>>";
			private string test7 = "<{o\"i!a,<{i<a>";

			[TestMethod]
			public void Test_1_Has_0_Garbage_Characters ()
			{
				int garbage = new DayNine (test1).garbageCharacters;
				Assert.AreEqual (0, garbage);
			}

			[TestMethod]
			public void Test_2_Has_17_Garbage_Characters ()
			{
				int garbage = new DayNine (test2).garbageCharacters;
				Assert.AreEqual (17, garbage);
			}

			[TestMethod]
			public void Test_3_Has_3_Garbage_Characters ()
			{
				int garbage = new DayNine (test3).garbageCharacters;
				Assert.AreEqual (3, garbage);
			}

			[TestMethod]
			public void Test_4_Has_2_Garbage_Characters ()
			{
				int garbage = new DayNine (test4).garbageCharacters;
				Assert.AreEqual (2, garbage);
			}

			[TestMethod]
			public void Test_5_Has_0_Garbage_Characters ()
			{
				int garbage = new DayNine (test5).garbageCharacters;
				Assert.AreEqual (0, garbage);
			}

			[TestMethod]
			public void Test_6_Has_0_Garbage_Characters ()
			{
				int garbage = new DayNine (test6).garbageCharacters;
				Assert.AreEqual (0, garbage);
			}

			[TestMethod]
			public void Test_7_Has_10_Garbage_Characters ()
			{
				int garbage = new DayNine (test7).garbageCharacters;
				Assert.AreEqual (10, garbage);
			}
		}
	}
}
