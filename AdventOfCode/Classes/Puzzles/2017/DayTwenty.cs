using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utilities;

namespace AdventOfCode.Puzzles._2017
{
	public class DayTwenty
	{
		Dictionary<int, Particle> particles;

		public DayTwenty ()
		{
			particles = new Dictionary<int, Particle> ();
			string [] stream = System.IO.File.ReadAllLines ("../../Inputs/2017/Day20Input.txt");
			for (int i = 0; i < stream.Length; i++)
				particles.Add (i, new Particle (stream [i]));
		}

		public int PartOne ()
		{
			int currentClosest = -2;
			int closestParticle = -1;
			int stayed = 0;
			while (stayed < 1000)
			{
				if (currentClosest == closestParticle)
					stayed++;
				else
					stayed = 0;
				closestParticle = currentClosest;
				currentClosest = -1;
				int currentDistance = int.MaxValue;
				foreach (KeyValuePair<int, Particle> p in particles)
				{
					p.Value.Tick ();
					int dist = p.Value.GetDistanceFromZero ();
					if (dist < currentDistance)
					{
						currentClosest = p.Key;
						currentDistance = dist;
					}
				}
			}
			return closestParticle;
		}

		public int PartTwo ()
		{
			int currentClosest = -2;
			int closestParticle = -1;
			int stayed = 0;
			while (stayed < 1000)
			{
				if (currentClosest == closestParticle)
					stayed++;
				else
					stayed = 0;
				closestParticle = currentClosest;
				currentClosest = -1;
				int currentDistance = int.MaxValue;
				foreach (KeyValuePair<int, Particle> p in particles)
				{
					p.Value.Tick ();
					int dist = p.Value.GetDistanceFromZero ();
					if (dist < currentDistance)
					{
						currentClosest = p.Key;
						currentDistance = dist;
					}
				}
				List<int> toRemove = new List<int> ();
				foreach (KeyValuePair<int, Particle> p in particles)
				{
					Vector3 position = p.Value.GetPosition ();
					bool didCollide = false;
					foreach (KeyValuePair<int, Particle> q in particles)
					{
						if (p.Key != q.Key)
						{
							if (position == q.Value.GetPosition ())
							{
								didCollide = true;
								toRemove.Add (q.Key);
							}
						}
					}
					if (didCollide)
						toRemove.Add (p.Key);
				}
				for (int i = 0; i < toRemove.Count; i++)
					particles.Remove (toRemove [i]);
			}
			return particles.Count;
		}

		public class Particle
		{
			Vector3 position;
			Vector3 velocity;
			Vector3 acceleration;

			public Particle (string v)
			{
				string [] split = v.Split (' ');
				string [] pos = split [0].Replace ("p=<", "").Replace (">,", "").Split (',');
				position = new Vector3 (int.Parse (pos [0]), int.Parse (pos [1]), int.Parse (pos [2]));
				string [] vel = split [1].Replace ("v=<", "").Replace (">,", "").Split (',');
				velocity = new Vector3 (int.Parse (vel [0]), int.Parse (vel [1]), int.Parse (vel [2]));
				string [] acc = split [2].Replace ("a=<", "").Replace (">", "").Split (',');
				acceleration = new Vector3 (int.Parse (acc [0]), int.Parse (acc [1]), int.Parse (acc [2]));
			}

			public Vector3 GetPosition ()
			{
				return position;
			}

			public int GetDistanceFromZero ()
			{
				return Math.Abs (position.x) + Math.Abs (position.y) + Math.Abs (position.z);
			}

			public void Tick ()
			{
				velocity += acceleration;
				position += velocity;
			}
		}
	}
}
