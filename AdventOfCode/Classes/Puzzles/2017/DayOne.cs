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
			return Solve (input, 1);
		}

		public int PartTwo ()
		{
			return Solve (input, input.Length / 2);
		}

		public static int Solve (string sequence, int comparator)
		{
			int sum = 0;
			for (int i = 0; i < sequence.Length; i++)
				if (sequence [i] == sequence [(i + comparator) % sequence.Length])
					sum += int.Parse (sequence [i].ToString ());
			return sum;
		}
	}
}
