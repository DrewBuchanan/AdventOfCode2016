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

		public int PartOne ()
		{
			Initialize ();
			ProcessInstructions ();

			int droidWereLookingFor = -9999;
			while (droidWereLookingFor == -9999)
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

		public List<int> PartTwo ()
		{
			Initialize ();
			ProcessInstructions ();
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

		void Initialize ()
		{
			bots = new Dictionary<int, Bot> ();
			outputs = new Dictionary<int, Output> ();
			instructions = new List<string> (System.IO.File.ReadAllLines ("Day10Input.txt"));
			for (int i = 0; i < instructions.Count; i++)
			{
				string [] split = instructions [i].Split (' ');
				if (split [0] == "value")
				{
					int id = int.Parse (split [split.Length - 1]);
					if (!bots.ContainsKey (id))
					{
						Bot newBot = new Bot (id);
						bots.Add (id, newBot);
					}
				}
				else if (split [0] == "bot")
				{
					int id = int.Parse (split [1]);
					if (!bots.ContainsKey (id))
					{
						Bot newBot = new Bot (id);
						bots.Add (id, newBot);
					}

					int receiverOneId = int.Parse (split [6]);
					if (split [5] == "output" && !outputs.ContainsKey (receiverOneId))
					{
						Output newOutput = new Output ();
						outputs.Add (receiverOneId, newOutput);
					}
					else if (split [5] == "bot" && !bots.ContainsKey (receiverOneId))
					{
						Bot newBot = new Bot (receiverOneId);
						bots.Add (receiverOneId, newBot);
					}

					int receiverTwoId = int.Parse (split [11]);
					if (split [5] == "output" && !outputs.ContainsKey (receiverTwoId))
					{
						Output newOutput = new Output ();
						outputs.Add (receiverTwoId, newOutput);
					}
					else if (split [5] == "bot" && !bots.ContainsKey (receiverTwoId))
					{
						Bot newBot = new Bot (receiverTwoId);
						bots.Add (receiverTwoId, newBot);
					}
				}
			}
		}

		void ProcessInstructions ()
		{
			for (int i = 0; i < instructions.Count; i++)
			{
				string [] split = instructions [i].Split (' ');
				if (split [0] == "value")
				{
					int receiver = int.Parse (split [split.Length - 1]);
					bots [receiver].Receive (int.Parse (split [1]));
				}
				else if (split [0] == "bot")
				{
					int giverId = int.Parse (split [1]);
					Bot giver = bots [giverId];

					Target lowReceiver;
					int lowReceiverId = int.Parse (split [6]);
					if (split [5] == "bot")
						lowReceiver = bots [lowReceiverId];
					else
						lowReceiver = outputs [lowReceiverId];


					Target highReceiver;
					int highReceiverId = int.Parse (split [11]);
					if (split [10] == "bot")
						highReceiver = bots [highReceiverId];
					else
						highReceiver = outputs [highReceiverId];

					giver.lowReceiver = lowReceiver;
					giver.highReceiver = highReceiver;
				}
			}
		}
	}

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

		public Output ()
		{
			value = EMPTY_VALUE;
		}

		public override void Receive (int received)
		{
			value = received;
		}
	}
}
