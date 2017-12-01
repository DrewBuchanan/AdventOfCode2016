namespace AdventOfCode.Puzzles._2017
{
	public class DayOne
	{
		string input;

		public DayOne ()
		{
			input = System.IO.File.ReadAllText ("../../Inputs/2017/Day01Input.txt");
		}

		public int PartOne ()
		{
			return PartOneSolve (input);
		}

		public int PartTwo ()
		{
			return PartTwoSolve (input);
		}

		public static int PartOneSolve (string sequence)
		{
			int sum = 0;
			for (int i = 0; i < sequence.Length - 1; i++)
				if (sequence [i] == sequence [i + 1])
					sum += int.Parse (sequence [i].ToString ());
			if (sequence [sequence.Length - 1] == sequence [0])
				sum += int.Parse (sequence [0].ToString ());
			return sum;
		}

		public static int PartTwoSolve (string sequnce)
		{
			int sum = 0;
			int compareTo = sequnce.Length / 2;
			for (int i = 0; i < sequnce.Length; i++)
			{
				if (sequnce [i] == sequnce [(i + compareTo) % sequnce.Length])
					sum += int.Parse (sequnce [i].ToString ());
			}
			return sum;
		}
	}
}
