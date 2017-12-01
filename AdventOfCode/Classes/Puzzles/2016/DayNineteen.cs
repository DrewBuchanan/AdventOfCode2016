using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
	public class DayNineteen
	{
		const int TEST_INPUT = 5;
		const int PUZZLE_INPUT = 3005290;

		/// <summary>
		/// Creates a list of elves, then iterates over it, skipping elves that don't have presents, and removing presents from the next eligible elf until one remains
		/// </summary>
		/// <returns>the id of the Elf with all the presents</returns>
		public int Test ()
		{
			List<bool> hasPresents = new List<bool> ();
			for (int i = 0; i < TEST_INPUT; i++)
				hasPresents.Add (true);
			int index = -1;
			// While more than one elf has a present
			while (hasPresents.Where (x => x == true).Take (2).Count () != 1)
			{
				index++;
				if (!hasPresents [index % hasPresents.Count])
					continue;

				int indexToTake = (index + 1) % hasPresents.Count;
				while (!hasPresents [indexToTake])
					indexToTake = (indexToTake + 1) % hasPresents.Count;
				hasPresents [indexToTake] = false;
			}
			return (hasPresents.IndexOf (true) + 1);
		}

		/// <summary>
		/// Creates a list of elves, then iterates over it, skipping elves that don't have presents, and removing presents from the next eligible elf until one remains
		/// <para>This method is incredibly slow. It is presented here for completion's sake. Avoid running it.</para>
		/// </summary>
		/// <returns>the id of the Elf with all the presents</returns>
		public int PartOne ()
		{
			List<bool> hasPresents = new List<bool> ();
			for (int i = 0; i < PUZZLE_INPUT; i++)
				hasPresents.Add (true);
			int index = -1;
			// While more than one elf has a present
			while (hasPresents.Where (x => x == true).Take (2).Count () != 1)
			{
				index++;
				if (!hasPresents [index % hasPresents.Count])
					continue;

				int indexToTake = (index + 1) % hasPresents.Count;
				while (!hasPresents [indexToTake])
					indexToTake = (indexToTake + 1) % hasPresents.Count;
				hasPresents [indexToTake] = false;
			}
			return (hasPresents.IndexOf (true) + 1);
		}

		/// <summary>
		/// Iterates over a queue, alternating between moving an element to the end of the queue and removing an element until one remains
		/// </summary>
		/// <returns>the id of the elf with all the presents</returns>
		public int PartOneFaster ()
		{
			Queue<int> elves = new Queue<int> ();
			for (int i = 0; i < PUZZLE_INPUT; i++)
				elves.Enqueue (i + 1);
			while (elves.Count > 1)
			{
				int taker = elves.Dequeue ();
				elves.Dequeue ();
				elves.Enqueue (taker);
			}
			return elves.Dequeue ();
		}

		/// <summary>
		/// Creates an array list, then iterates over it until one element remains, removing the element directly opposite
		/// <para>This method is incredibly slow. It is presented here for completion's sake. Avoid running it.</para>
		/// </summary>
		/// <returns>the id of the Elf with all the presents</returns>
		public int PartTwo ()
		{
			ArrayList elves = new ArrayList ();
			for (int i = 0; i < PUZZLE_INPUT; i++)
				elves.Add (i + 1);
			int index = -1;
			int prevTaker = -1;
			while (elves.Count > 1)
			{
				index = (index + 1) % elves.Count;
				if (prevTaker == (int)elves [index])
					index = (index + 1) % elves.Count;
				prevTaker = (int)elves [index];
				elves.RemoveAt ((index + (elves.Count / 2)) % elves.Count);
			}
			return ((int)elves [0]);
		}

		/// <summary>
		/// Creates a linked list, then iterates through it until one element remains, eliminating the node directly opposite it
		/// </summary>
		/// <param name="runTestCase">if true, uses test input to validate success, else, uses puzzle input</param>
		/// <returns>id of the Elf with all presents</returns>
		public int PartTwoFaster (bool runTestCase)
		{
			Elf root = new Elf { id = 1 };
			Elf current = root;
			Elf target = null;

			int size = PUZZLE_INPUT;
			if (runTestCase)
				size = TEST_INPUT;
			int count = size;

			for (int i = 1; i < size + 1; i++)
			{
				current.next = (i == size) ? root : new Elf { id = i + 1, prev = current };
				current = current.next;
				if (i == size / 2)
					target = current;
			}

			root.prev = current;

			while (current.next != current)
			{
				// removes target from linked list and links the surrounding nodes
				target.prev.next = target.next;
				target.next.prev = target.prev;

				// changes target
				target = count % 2 == 1 ? target.next.next : target.next;
				count--;

				current = current.next;
			}
			return current.id;
		}

		/// <summary>
		/// Manual implementation of linked list node used in PartTwoFaster
		/// </summary>
		class Elf
		{
			public int id;
			public Elf prev;
			public Elf next;
		}
	}
}
