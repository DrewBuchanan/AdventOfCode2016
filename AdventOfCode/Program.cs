using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Puzzles;
using AdventOfCode.Utilities;

namespace AdventOfCode
{
	class Program
	{
		static void Main (string [] args)
		{
			#region Day One
			/*
			DayOnePartOne ();
			DayOnePartTwo ();
			*/
			#endregion
			#region Day Two
			/*
			DayTwoPartOne ();
			DayTwoPartTwo ();
			*/
			#endregion
			#region Day Three
			/*
			DayThreePartOne ();
			DayThreePartTwo ();
			*/
			#endregion
			#region Day Four
			/*
			DayFourPartOne ();
			DayFourPartTwo ();
			*/
			#endregion
			#region Day Five
			/*
			DayFivePartOne ();
			DayFivePartTwo ();
			*/
			#endregion
			#region Day Six
			/*
			DaySixPartOne ();
			DaySixPartTwo ();
			*/
			#endregion
			#region Day Seven
			/*
			DaySevenPartOne ();
			DaySevenPartTwo ();
			*/
			#endregion
			#region Day Eight
			/*
			DayEightPartOne ();
			DayEightPartTwo ();
			*/
			#endregion
			#region Day Nine
			/*
			DayNinePartOne ();
			DayNinePartTwo ();
			*/
			#endregion
			#region Day Ten
			/*
			DayTenPartOne ();
			DayTenPartTwo ();
			*/
			#endregion
			#region Day Eleven
			/*
            DayElevenPartOne();
            DayElevenPartTwo();
            */
			#endregion
			#region Day Twelve
			/*
			DayTwelveTest ();
			DayTwelvePartOne ();
			DayTwelvePartTwo ();
			*/
			#endregion
			#region Day Thirteen
			/*
			DayThirteenTest ();
			DayThirteenPartOne ();
			DayThirteenPartTwo ();
			*/
			#endregion
			#region Day Fourteen
			/*
			DayFourteenPartOneTest ();
			DayFourteenPartOne ();
			DayFourteenPartTwoTest ();
			DayFourteenPartTwo ();
			*/
			#endregion
			#region Day Fifteen
			/*
			DayFifteenPartOneTest ();
			DayFifteenPartOne ();
			DayFifteenPartTwo ();
			*/
			#endregion
			#region Day Sixteen
			/*
			DaySixteenPartOneTest ();
			DaySixteenPartOne ();
			DaySixteenPartTwo ();
			*/
			#endregion
			#region Day Seventeen
			/*
			DaySeventeenTestOne ();
			DaySeventeenPartOne ();
			DaySeventeenPartTwo ();
			*/
			#endregion
			#region Day Eighteen
			/*
			DayEighteenPartOneTestOne ();
			DayEighteenPartOneTestTwo ();
			DayEighteenPartOne ();
			DayEighteenPartTwo ();
			*/
			#endregion
			#region Day Nineteen
			/*
			DayNineteenPartOneTest ();
			DayNineteenPartOne ();
			DayNineteenPartOneSlow ();
			DayNineteenPartTwoTest ();
			DayNineteenPartTwo ();
			DayNineteenPartTwoSlow ();
			*/
			#endregion
			#region Day Twenty
			/*
			DayTwentyTest ();
			DayTwentyPartOne ();
			DayTwentyPartTwo ();
			*/
			#endregion
			#region Day Twenty-One
			/*
			DayTwentyOneTest ();
			DayTwentyOnePartOne ();
			DayTwentyOnePartTwo ();
			*/
			#endregion
			#region Day Twenty-Two

			#endregion
		}
		#region Day Twenty-Two

		#endregion
		#region Day Twenty-One
		static void DayTwentyOneTest ()
		{
			Console.WriteLine ("Day 21 Part 1 Test Output");
			DayTwentyOne dayTwentyOne = new DayTwentyOne ();
			string scrambled = dayTwentyOne.Test ();
			Console.WriteLine ("Scrambled Password: " + scrambled);
			Console.ReadLine ();
		}
		static void DayTwentyOnePartOne ()
		{
			Console.WriteLine ("Day 21 Part 1 Output");
			DayTwentyOne dayTwentyOne = new DayTwentyOne ();
			string scrambled = dayTwentyOne.PartOne ();
			Console.WriteLine ("Scrambled Password: " + scrambled);
			Console.ReadLine ();
		}
		static void DayTwentyOnePartTwo ()
		{
			Console.WriteLine ("Day 21 Part 2 Output");
			DayTwentyOne dayTwentyOne = new Puzzles.DayTwentyOne ();
			string unscrambled = dayTwentyOne.PartTwo ();
			Console.WriteLine ("Unscrambled Password: " + unscrambled);
			Console.ReadLine ();
		}
		#endregion
		#region Day Twenty
		static void DayTwentyTest ()
		{
			Console.WriteLine ("Day 20 Part 1 Test Output");
			DayTwenty dayTwenty = new DayTwenty ();
			uint minimum = dayTwenty.Test ();
			Console.WriteLine ("Lowest Valued IP: " + minimum);
			Console.ReadLine ();
		}
		static void DayTwentyPartOne ()
		{
			Console.WriteLine ("Day 20 Part 1 Output");
			DayTwenty dayTwenty = new DayTwenty ();
			uint minimum = dayTwenty.PartOne ();
			Console.WriteLine ("Lowest Valued IP: " + minimum);
			Console.ReadLine ();
		}
		static void DayTwentyPartTwo ()
		{
			Console.WriteLine ("Day 20 Part 2 Output");
			DayTwenty dayTwenty = new DayTwenty ();
			uint valid = dayTwenty.PartTwo ();
			Console.WriteLine ("Valid IPs: " + valid);
			Console.ReadLine ();
		}
		#endregion
		#region Day Nineteen
		static void DayNineteenPartOneTest ()
		{
			Console.WriteLine ("Day 19 Part One Test Output");
			DayNineteen dayNineteen = new DayNineteen ();
			int id = dayNineteen.Test ();
			Console.WriteLine ("Elf " + id + " has all the presents.");
			Console.ReadLine ();
		}
		static void DayNineteenPartOne ()
		{
			Console.WriteLine ("Day 19 Part One Output");
			DayNineteen dayNineteen = new DayNineteen ();
			int id = dayNineteen.PartOneFaster ();
			Console.WriteLine ("Elf " + id + " has all the presents.");
			Console.ReadLine ();
		}
		static void DayNineteenPartOneSlow ()
		{
			Console.WriteLine ("Day 19 Part One Slow Impl Output");
			Console.WriteLine ("This method is suuuuuuuuuuuuper slow. Enter 'run' to run it.");
			string input = Console.ReadLine ();
			if (input.ToLower () == "run")
			{
				DayNineteen dayNineteen = new DayNineteen ();
				int id = dayNineteen.PartOne ();
				Console.WriteLine ("Elf " + id + " has all the presents.");
				Console.ReadLine ();
			}
		}
		static void DayNineteenPartTwoTest ()
		{
			Console.WriteLine ("Day 19 Part Two Test Output");
			DayNineteen dayNineteen = new DayNineteen ();
			int id = dayNineteen.PartTwoFaster (true);
			Console.WriteLine ("Elf " + id + " has all the presents.");
			Console.ReadLine ();
		}
		static void DayNineteenPartTwo ()
		{
			Console.WriteLine ("Day 19 Part Two Output");
			DayNineteen dayNineteen = new DayNineteen ();
			int id = dayNineteen.PartTwoFaster (false);
			Console.WriteLine ("Elf " + id + " has all the presents.");
			Console.ReadLine ();
		}
		static void DayNineteenPartTwoSlow ()
		{
			Console.WriteLine ("Day 19 Part Two Slow Impl Output");
			Console.WriteLine ("This method is suuuuuuuuuuuuper slow. Enter 'run' to run it.");
			string input = Console.ReadLine ();
			if (input.ToLower () == "run")
			{
				DayNineteen dayNineteen = new DayNineteen ();
				int id = dayNineteen.PartTwo ();
				Console.WriteLine ("Elf " + id + " has all the presents.");
				Console.ReadLine ();
			}
		}
		#endregion
		#region Day Eighteen
		static void DayEighteenPartOneTestOne ()
		{
			Console.WriteLine ("Day 18 Part One Test 1 Output");
			DayEighteen dayEighteen = new DayEighteen ();
			dayEighteen.PartOneTestOne ();
			Console.ReadLine ();
		}
		static void DayEighteenPartOneTestTwo ()
		{
			Console.WriteLine ("Day 18 Part One Test 1 Output");
			DayEighteen dayEighteen = new DayEighteen ();
			int safeTiles = dayEighteen.PartOneTestTwo ();
			Console.WriteLine ("Safe Tiles: " + safeTiles);
			Console.ReadLine ();
		}
		static void DayEighteenPartOne ()
		{
			Console.WriteLine ("Day 18 Part One Output");
			DayEighteen dayEighteen = new DayEighteen ();
			int safeTiles = dayEighteen.PartOne ();
			Console.WriteLine ("Safe Tiles: " + safeTiles);
			Console.ReadLine ();
		}
		static void DayEighteenPartTwo ()
		{
			Console.WriteLine ("Day 18 Part Two Output");
			DayEighteen dayEighteen = new DayEighteen ();
			int safeTiles = dayEighteen.PartTwo ();
			Console.WriteLine ("Safe Tiles: " + safeTiles);
			Console.ReadLine ();
		}
		#endregion
		#region Day Seventeen
		static void DaySeventeenTestOne ()
		{
			Console.WriteLine ("Day 17 Test One Output");
			DaySeventeen daySeventeen = new DaySeventeen ();
			string shortest = daySeventeen.TestOne ();
			Console.WriteLine ("Shortest: " + shortest);
			Console.ReadLine ();
		}
		static void DaySeventeenPartOne ()
		{
			Console.WriteLine ("Day 17 Part One Output");
			DaySeventeen daySeventeen = new DaySeventeen ();
			string shortest = daySeventeen.PartOne ();
			Console.WriteLine ("Shortest: " + shortest);
			Console.ReadLine ();
		}
		static void DaySeventeenPartTwo ()
		{
			Console.WriteLine ("Day 17 Part Two Output");
			DaySeventeen daySeventeen = new DaySeventeen ();
			int longest = daySeventeen.PartTwo ();
			Console.WriteLine ("Length of longest path: " + longest);
			Console.ReadLine ();
		}
		#endregion
		#region Day Sixteen
		static void DaySixteenPartOneTest ()
		{
			Console.WriteLine ("Day 16 Part 1 Test Output");
			DaySixteen daySixteen = new DaySixteen ();
			string checksum = daySixteen.PartOneTest ();
			Console.WriteLine ("Checksum: " + checksum);
			Console.ReadLine ();
		}
		static void DaySixteenPartOne ()
		{
			Console.WriteLine ("Day 16 Part 1 Output");
			DaySixteen daySixteen = new DaySixteen ();
			string checksum = daySixteen.PartOne ();
			Console.WriteLine ("Checksum: " + checksum);
			Console.ReadLine ();
		}
		static void DaySixteenPartTwo ()
		{
			Console.WriteLine ("Day 16 Part 2 Output");
			DaySixteen daySixteen = new DaySixteen ();
			string checksum = daySixteen.PartTwo ();
			Console.WriteLine ("Checksum: " + checksum);
			Console.ReadLine ();
		}
		#endregion
		#region Day Fifteen
		static void DayFifteenPartOneTest ()
		{
			Console.WriteLine ("Day 15 Part 1 Test Output");
			DayFifteen dayFifteen = new DayFifteen ();
			int t = dayFifteen.PartOneTest ();
			Console.WriteLine ("To get a capsule, press the button at t=" + t);
			Console.ReadLine ();
		}
		static void DayFifteenPartOne ()
		{
			Console.WriteLine ("Day 15 Part 1 Output");
			DayFifteen dayFifteen = new DayFifteen ();
			int t = dayFifteen.PartOne ();
			Console.WriteLine ("To get a capsule, press the button at t=" + t);
			Console.ReadLine ();
		}
		static void DayFifteenPartTwo ()
		{
			Console.WriteLine ("Day 15 Part 2 Output");
			DayFifteen dayFifteen = new Puzzles.DayFifteen ();
			int t = dayFifteen.PartTwo ();
			Console.WriteLine ("To get a capsule, press the button at t=" + t);
			Console.ReadLine ();
		}
		#endregion
		#region Day Fourteen
		static void DayFourteenPartOneTest ()
		{
			Console.WriteLine ("Day 14 Part 1 Test Output");
			DayFourteen dayFourteen = new DayFourteen ();
			int index = dayFourteen.PartOneTest ();
			Console.WriteLine ("Index of 64th key: " + index);
			Console.ReadLine ();
		}
		static void DayFourteenPartOne ()
		{
			Console.WriteLine ("Day 14 Part 1 Output");
			DayFourteen dayFourteen = new DayFourteen ();
			int index = dayFourteen.PartOne ();
			Console.WriteLine ("Index of 64th key: " + index);
			Console.ReadLine ();
		}
		static void DayFourteenPartTwoTest ()
		{
			Console.WriteLine ("Day 14 Part 2 Test Output");
			DayFourteen dayFourteen = new DayFourteen ();
			int index = dayFourteen.PartTwoTest ();
			Console.WriteLine ("Index of 64th key: " + index);
			Console.ReadLine ();
		}
		static void DayFourteenPartTwo ()
		{
			Console.WriteLine ("Day 14 Part 2 Output");
			DayFourteen dayFourteen = new DayFourteen ();
			int index = dayFourteen.PartTwo ();
			Console.WriteLine ("Index of 64th key: " + index);
			Console.ReadLine ();
		}
		#endregion
		#region Day Thirteen
		static void DayThirteenTest ()
		{
			Console.WriteLine ("Day 13 Test Output");
			DayThirteen dayThirteen = new DayThirteen ();
			List<Vector2> path = dayThirteen.Test ();
			for (int i = 0; i < path.Count; i++)
			{
				Console.SetCursorPosition (path [i].x, path [i].y + 1);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write ('0');
				Console.SetCursorPosition (0, 7 + 1 + i);
				Console.ResetColor ();
				Console.WriteLine (path [i].ToString ());
			}
			Console.WriteLine (path.Count);
			Console.ReadLine ();
		}
		static void DayThirteenPartOne ()
		{
			Console.WriteLine ("Day 13 Part 1 Output");
			DayThirteen dayThirteen = new DayThirteen ();
			List<Vector2> path = dayThirteen.PartOne ();
			Console.ReadLine ();
			for (int i = 0; i < path.Count; i++)
			{
				Console.SetCursorPosition (path [i].x, path [i].y + 1);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write ('0');
				//Console.SetCursorPosition (0, 42 + 1 + i);
				Console.ResetColor ();
				System.Threading.Thread.Sleep (100);
				//Console.WriteLine (path [i].ToString ());
			}
			Console.SetCursorPosition (0, 42 + 1);
			Console.WriteLine (path.Count);
			Console.ReadLine ();
		}
		static void DayThirteenPartTwo ()
		{
			Console.WriteLine ("Day 13 Part 2 Output");
			DayThirteen dayThirteen = new DayThirteen ();
			Dictionary<System.Drawing.Point, int> coords = dayThirteen.PartTwo ();
			Console.WriteLine (coords.Count);
			Console.ReadLine ();
		}
		#endregion
		#region Day Twelve
		static void DayTwelveTest ()
		{
			Console.WriteLine ("Day 12 Test Output");
			DayTwelve dayTwelve = new DayTwelve ();
			List<int> result = dayTwelve.Test ();
			Console.WriteLine (result [0].ToString ());
			Console.ReadLine ();
		}
		static void DayTwelvePartOne ()
		{
			Console.WriteLine ("Day 12 Part 1 Output");
			DayTwelve dayTwelve = new DayTwelve ();
			List<int> result = dayTwelve.PartOne ();
			Console.WriteLine (result [0].ToString ());
			Console.ReadLine ();
		}
		static void DayTwelvePartTwo ()
		{
			Console.WriteLine ("Day 12 Part 2 Output");
			DayTwelve dayTwelve = new DayTwelve ();
			List<int> result = dayTwelve.PartTwo ();
			Console.WriteLine (result [0].ToString ());
			Console.ReadLine ();
		}
		#endregion
		#region Day Eleven
		static void DayElevenPartOne ()
		{
			Console.WriteLine ("Day 11 Part 1 Output");
			Console.ReadLine ();
		}
		static void DayElevenPartTwo ()
		{
			Console.WriteLine ("Day 11 Part 2 Output");
			Console.ReadLine ();
		}
		#endregion
		#region Day Ten
		static void DayTenPartOne ()
		{
			Console.WriteLine ("Day 10 Part 1 Output");
			DayTen dayTen = new DayTen ();
			int droid = dayTen.PartOne ();
			Console.WriteLine (droid + " is the droid we're looking for.");
			Console.ReadLine ();
		}
		static void DayTenPartTwo ()
		{
			Console.WriteLine ("Day 10 Part 2 Output");
			DayTen dayTen = new DayTen ();
			List<int> results = dayTen.PartTwo ();
			Console.WriteLine ("The Values are " + results [0] + ", " + results [1] + ", and " + results [2] + " and the product is " + (results [0] * results [1] * results [2]));
			Console.ReadLine ();
		}
		#endregion
		#region Day Nine
		static void DayNinePartOne ()
		{
			Console.WriteLine ("Day 9 Part 1 Output");
			DayNine dayNine = new DayNine ();
			long dayNineResult = dayNine.PartOne ();
			Console.WriteLine (dayNineResult);
			Console.ReadLine ();
		}
		static void DayNinePartTwo ()
		{
			Console.WriteLine ("Day 9 Part 2 Output");
			DayNine dayNine = new DayNine ();
			long partTwoResult = dayNine.PartTwo ();
			Console.WriteLine (partTwoResult);
			Console.ReadLine ();
		}
		#endregion
		#region Day Eight
		static void DayEightPartOne ()
		{
			Console.WriteLine ("Day 8 Part 1 Output");
			DayEight dayEight = new DayEight ();
			int litPixels = dayEight.PartOne ();
			Console.WriteLine ("Lit Pixels: " + litPixels);
			Console.ReadLine ();
		}
		static void DayEightPartTwo ()
		{
			Console.WriteLine ("Day 8 Part 2 Output");
			DayEight dayEight = new DayEight ();
			dayEight.PartTwo ();
			Console.ReadLine ();
		}
		#endregion
		#region Day Seven
		static void DaySevenPartOne ()
		{
			Console.WriteLine ("Day 7 Part 1 Output");
			DaySeven daySeven = new DaySeven ();
			int valid = daySeven.PartOne ();
			Console.WriteLine ("Valid IPs: " + valid);
			Console.ReadLine ();
		}
		static void DaySevenPartTwo ()
		{
			Console.WriteLine ("Day 7 Part 2 Output");
			DaySeven daySeven = new DaySeven ();
			int valid = daySeven.PartTwo ();
			Console.WriteLine ("Valid IPs: " + valid);
			Console.ReadLine ();
		}
		#endregion
		#region Day Six
		static void DaySixPartOne ()
		{
			Console.WriteLine ("Day 6 Part 1 Output");
			DaySix daySix = new DaySix ();
			string result = daySix.PartOne ();
			Console.WriteLine ("Message: " + result);
			Console.ReadLine ();
		}
		static void DaySixPartTwo ()
		{
			Console.WriteLine ("Day 6 Part 2 Output");
			DaySix daySix = new DaySix ();
			string result = daySix.PartTwo ();
			Console.WriteLine ("Message: " + result);
			Console.ReadLine ();
		}
		#endregion
		#region Day Five
		static void DayFivePartOne ()
		{
			Console.WriteLine ("Day 5 Part 1 Output");
			DayFive dayFive = new DayFive ();
			dayFive.PartOne ();
			Console.ReadLine ();
		}
		static void DayFivePartTwo ()
		{
			Console.WriteLine ("Day 5 Part 2 Output");
			DayFive dayFive = new DayFive ();
			dayFive.PartTwo ();
			Console.ReadLine ();
		}
		#endregion
		#region Day Four
		static void DayFourPartOne ()
		{
			Console.WriteLine ("Day 4 Part 1 Output");
			DayFour dayFour = new DayFour ();
			int sum = dayFour.PartOne ();
			Console.WriteLine ("Sum of Real Room Sector IDs: " + sum);
			Console.ReadLine ();
		}
		static void DayFourPartTwo ()
		{
			Console.WriteLine ("Day 4 Part 2 Output");
			DayFour dayFour = new DayFour ();
			int sectorId = dayFour.PartTwo ();
			Console.WriteLine ("Sector ID: " + sectorId);
			Console.ReadLine ();
		}
		#endregion
		#region Day Three
		static void DayThreePartOne ()
		{
			Console.WriteLine ("Day 3 Part 1 Output");
			DayThree dayThree = new DayThree ();
			int result = dayThree.PartOne ();
			Console.WriteLine ("Valid Triangles: " + result);
			Console.ReadLine ();
		}
		static void DayThreePartTwo ()
		{
			Console.WriteLine ("Day 3 Part 2 Output");
			DayThree dayThree = new DayThree ();
			int result = dayThree.PartTwo ();
			Console.WriteLine ("Valid Triangles: " + result);
			Console.ReadLine ();
		}
		#endregion
		#region Day Two
		static void DayTwoPartOne ()
		{
			Console.WriteLine ("Day 2 Part 1 Output");
			DayTwo dayTwo = new DayTwo ();
			string result = dayTwo.PartOne ();
			Console.WriteLine (result);
			Console.ReadLine ();
		}
		static void DayTwoPartTwo ()
		{
			Console.WriteLine ("Day 2 Part 2 Output");
			DayTwo dayTwo = new DayTwo ();
			string result = dayTwo.PartTwo ();
			Console.WriteLine (result);
			Console.ReadLine ();
		}
		#endregion
		#region Day One
		static void DayOnePartOne ()
		{
			Console.WriteLine ("Day 1 Part 1 Output");
			DayOne dayOne = new DayOne ();
			DayOne.Result result = dayOne.PartOne ();
			Console.WriteLine (result.currentPosition.ToString ());
			Console.WriteLine ("Total blocks: " + result.distanceFromOrigin);
			Console.ReadLine ();
		}
		static void DayOnePartTwo ()
		{
			Console.WriteLine ("Day 1 Part 2 Output");
			DayOne dayOne = new DayOne ();
			DayOne.Result result = dayOne.PartTwo ();
			Console.WriteLine (result.currentPosition.ToString ());
			Console.WriteLine ("Total blocks: " + result.distanceFromOrigin);
			Console.ReadLine ();
		}
		#endregion
	}
}
