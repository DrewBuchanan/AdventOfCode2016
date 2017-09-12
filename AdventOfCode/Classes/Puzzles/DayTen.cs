using System;
using System.Collections.Generic;

namespace AdventOfCode.Puzzles
{
	public class DayTen
	{
		static int highValue = 61;
		static int lowValue = 17;

		Dictionary<int, Bot> bots;
		Dictionary<int, Output> outputs;
		List<string> instructions;

		/// <summary>
		/// Initializes bots and outputs, then runs through instructions until we find the bot that compares highValue and lowValue
		/// </summary>
		/// <returns>the id of the bot that compares highValue and lowValue</returns>
		public int PartOne ()
		{
			Initialize ();

			int droidWereLookingFor = Target.EMPTY_VALUE;
			while (droidWereLookingFor == Target.EMPTY_VALUE)
			{
				foreach (Bot bot in bots.Values)
				{
					if (!bot.HasTwoChips ())
						continue;
					if (bot.high == highValue && bot.low == lowValue)
					{
						droidWereLookingFor = bot.id;
						break;
					}
					bot.GiveLow ();
					bot.GiveHigh ();
				}
			}
			return droidWereLookingFor;
		}

		/// <summary>
		/// Initializes bots and outputs, then runs through instructions until outputs 0, 1, and 2 have values, then returns those values
		/// </summary>
		/// <returns>values of outputs 0, 1, and 2</returns>
		public List<int> PartTwo ()
		{
			Initialize ();
			while (outputs [0].value == Target.EMPTY_VALUE ||
				outputs [1].value == Target.EMPTY_VALUE ||
				outputs [2].value == Target.EMPTY_VALUE)
			{
				foreach (Bot bot in bots.Values)
				{
					if (!bot.HasTwoChips ())
						continue;
					bot.GiveLow ();
					bot.GiveHigh ();
				}
			}
			List<int> rtrn = new List<int> ();
			for (int i = 0; i < 3; i++)
				rtrn.Add (outputs [i].value);
			return rtrn;
		}

		/// <summary>
		/// Initializes data and populates Targets based on instruction
		/// </summary>
		void Initialize ()
		{
			// Initialize Data
			bots = new Dictionary<int, Bot> ();
			outputs = new Dictionary<int, Output> ();
			instructions = new List<string> (System.IO.File.ReadAllLines ("../../Inputs/Day10Input.txt"));

			// Iterate over instructions
			for (int i = 0; i < instructions.Count; i++)
			{
				string [] split = instructions [i].Split (' ');
				// Give bot value instruction
				if (split [0] == "value")
				{
					int id = int.Parse (split [split.Length - 1]);
					CreateBotIfNeeded (id);
					bots [id].Receive (int.Parse (split [1]));
				}
				#region Comparison instruction
				else if (split [0] == "bot")
				{
					#region Get Comparer
					int id = int.Parse (split [1]);
					CreateBotIfNeeded (id);
					Bot comparer = bots [id];
					#endregion

					#region Get Low Receiver
					Target lowReceiver;
					int lowReceiverId = int.Parse (split [6]);
					if (split [5] == "output")
					{
						CreateOutputIfNeeded (lowReceiverId);
						lowReceiver = outputs [lowReceiverId];
					}
					else
					{
						CreateBotIfNeeded (lowReceiverId);
						lowReceiver = bots [lowReceiverId];
					}
					#endregion

					#region Get High Receiver
					Target highReceiver;
					int highReceiverId = int.Parse (split [11]);
					if (split [10] == "output")
					{
						CreateOutputIfNeeded (highReceiverId);
						highReceiver = outputs [highReceiverId];
					}
					else
					{
						CreateBotIfNeeded (highReceiverId);
						highReceiver = bots [highReceiverId];
					}
					#endregion

					comparer.lowReceiver = lowReceiver;
					comparer.highReceiver = highReceiver;
				}
				#endregion
			}
		}

		/// <summary>
		/// Checks if there is an output with ID id, then creates one if there isn't.
		/// </summary>
		/// <param name="id">the id to check for and create if needed</param>
		void CreateOutputIfNeeded (int id)
		{
			if (!outputs.ContainsKey (id))
			{
				Output newOutput = new Output (id);
				outputs.Add (id, newOutput);
			}
		}

		/// <summary>
		/// Checks if there is a bot with ID id, then creates one if there isn't.
		/// </summary>
		/// <param name="id">the id to check for and create if needed</param>
		void CreateBotIfNeeded (int id)
		{
			if (!bots.ContainsKey (id))
			{
				Bot newBot = new Bot (id);
				bots.Add (id, newBot);
			}
		}
	}

	/// <summary>
	/// Base class for Bot and Output
	/// </summary>
	public class Target
	{
		public const int EMPTY_VALUE = -9999;
		public int id;

		public override int GetHashCode ()
		{
			return id;
		}

		public virtual void Receive (int received)
		{
			throw new NotImplementedException ();
		}
	}

	public class Bot : Target
	{
		public int low;
		public int high;
		public Target lowReceiver;
		public Target highReceiver;

		public Bot (int id)
		{
			this.id = id;
			low = EMPTY_VALUE;
			high = EMPTY_VALUE;
		}

		public void GiveHigh ()
		{
			GiveHighTo (highReceiver);
		}

		public void GiveHighTo (Target target)
		{
			target.Receive (high);
			high = EMPTY_VALUE;
		}

		public void GiveLow ()
		{
			GiveLowTo (lowReceiver);
		}

		public void GiveLowTo (Target target)
		{
			target.Receive (low);
			low = EMPTY_VALUE;
		}

		/// <summary>
		/// Receives an integer value and stores it, then swaps high and low if they are not assigned properly
		/// </summary>
		/// <param name="received">received value</param>
		public override void Receive (int received)
		{
			if (low == EMPTY_VALUE)
				low = received;
			else if (high == EMPTY_VALUE)
			{
				high = received;
				if (high < low)
				{
					int temp = high;
					high = low;
					low = temp;
				}
			}
		}

		public bool HasTwoChips ()
		{
			return low != EMPTY_VALUE && high != EMPTY_VALUE;
		}
	}

	public class Output : Target
	{
		public int value;

		public Output (int id)
		{
			this.id = id;
			value = EMPTY_VALUE;
		}

		public override void Receive (int received)
		{
			value = received;
		}
	}
}
