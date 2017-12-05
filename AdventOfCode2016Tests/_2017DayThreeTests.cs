using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Puzzles._2017;

namespace AdventOfCode2016Tests
{
	[TestClass]
	public class _2017DayThreeTests
	{
		[TestMethod]
		public void Spiral_To_Euclidean_1_Produces_0_0 ()
		{
			Point zero = DayThree.SpiralToEuclidean (1);
			Assert.AreEqual (new Point (0, 0), zero);
		}

		[TestMethod]
		public void Spiral_To_Euclidean_12_Produces_2_1 ()
		{
			Point twoCommaOne = DayThree.SpiralToEuclidean (12);
			Assert.AreEqual (new Point (2, 1), twoCommaOne);
		}

		[TestMethod]
		public void Spiral_To_Euclidean_23_Produces_0_Negative_2 ()
		{
			Point zeroNegativeTwo = DayThree.SpiralToEuclidean (23);
			Assert.AreEqual (new Point (0, -2), zeroNegativeTwo);
		}

		[TestMethod]
		public void Spiral_1_Is_0_Steps_Away ()
		{
			Point one = DayThree.SpiralToEuclidean (1);
			int steps = DayThree.ManhattanDistanceFromOrigin (one);
			Assert.AreEqual (0, steps);
		}

		[TestMethod]
		public void Spiral_12_Is_3_Steps_Away ()
		{
			Point three = DayThree.SpiralToEuclidean (12);
			int steps = DayThree.ManhattanDistanceFromOrigin (three);
			Assert.AreEqual (3, steps);
		}

		[TestMethod]
		public void Spiral_23_Is_2_Steps_Away ()
		{
			Point two = DayThree.SpiralToEuclidean (23);
			int steps = DayThree.ManhattanDistanceFromOrigin (two);
			Assert.AreEqual (2, steps);
		}

		[TestMethod]
		public void Spiral_1024_Is_31_Steps_Away ()
		{
			Point point = DayThree.SpiralToEuclidean (1024);
			int steps = DayThree.ManhattanDistanceFromOrigin (point);
			Assert.AreEqual (31, steps);
		}
	}
}
