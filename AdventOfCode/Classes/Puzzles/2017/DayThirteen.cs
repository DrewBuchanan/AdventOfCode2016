using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles._2017
{
	public class DayThirteen
	{
		public const string TEST_INPUT_PATH = "../../Inputs/2017/Day13TestInput.txt";
		public const string DATA_INPUT_PATH = "../../Inputs/2017/Day13Input.txt";

		public static DayThirteen Test ()
		{
			return new DayThirteen (TEST_INPUT_PATH);
		}

		public static DayThirteen RealData ()
		{
			return new DayThirteen (DATA_INPUT_PATH);
		}

		string [] input;
		List<Layer> layers;
		int currentPosition = -1;

		public DayThirteen (string stream)
		{
			input = System.IO.File.ReadAllLines (stream);
			GenerateLayers ();
		}

		public int GetSeverity ()
		{
			int severity = 0;
			while (currentPosition < layers.Count - 1)
			{
				currentPosition++;
				if (layers [currentPosition].GetScannerPosition () == 0)
					severity += currentPosition * layers [currentPosition].GetRange ();
				TickAllLayers ();
			}
			return severity;
		}

		public uint GetDelayThatAvoidsDetection ()
		{
			uint delay = 0;
			while (DoesGetCaught (delay))
			{
				delay++;
				ResetAll ();
			}
			return delay;
		}

		private void GenerateLayers ()
		{
			layers = new List<Layer> ();
			int maximumLayers = int.Parse (input [input.Length - 1].Replace (" ", "").Split (':') [0]);
			int inputCounter = 0;
			for (int i = 0; i <= maximumLayers; i++)
			{
				string [] split = input [inputCounter].Replace (" ", "").Split (':');
				if (i == int.Parse (split [0]))
				{
					layers.Add (new Layer (int.Parse (split [0]), int.Parse (split [1])));
					inputCounter++;
				}
				else
					layers.Add (new Layer (i, 0));
			}
		}

		bool DoesGetCaught (uint delay)
		{
			for (int i = 0; i < layers.Count; i++)
			{
				if (layers [i].GetsCaught (delay))
					return true;
			}
			return false;
		}

		private void TickAllLayers ()
		{
			for (int i = 0; i < layers.Count; i++)
				layers [i].Tick ();
		}

		private void ResetAll ()
		{
			currentPosition = -1;
			for (int i = 0; i < layers.Count; i++)
				layers [i].Reset ();
		}

		class Layer
		{
			int depth;
			int range;
			int currentScannerPosition;
			bool forward;

			public Layer (int depth, int range)
			{
				this.depth = depth;
				this.range = range;
				currentScannerPosition = 0;
				forward = true;
			}

			public void Tick ()
			{
				if (range > 0)
				{
					if (currentScannerPosition == 0)
						forward = true;
					else if (currentScannerPosition == range - 1)
						forward = false;
					if (forward)
						currentScannerPosition++;
					else
						currentScannerPosition--;
				}
			}

			public bool GetsCaught (uint delay)
			{
				if (range == 0)
					return false;
				return (depth + delay) % ((range - 1) * 2) == 0;
			}

			public int GetRange ()
			{
				return range;
			}

			public int GetScannerPosition ()
			{
				if (range > 0)
					return currentScannerPosition;
				else
					return -1;
			}

			internal void Reset ()
			{
				currentScannerPosition = 0;
				forward = true;
			}
		}
	}
}
