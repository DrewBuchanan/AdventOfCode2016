using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utilities
{
	public class PathFinder
	{
		private int width;
		private int height;
		private Node [,] nodes;
		private Node startNode;
		private Node endNode;
		private SearchParameters searchParameters;

		public PathFinder (SearchParameters searchParameters)
		{
			this.searchParameters = searchParameters;
			InitializeNodes (searchParameters.Map);
			this.startNode = this.nodes [searchParameters.StartLocation.x, searchParameters.StartLocation.y];
			this.startNode.state = NodeState.Open;
			this.endNode = this.nodes [searchParameters.EndLocation.x, searchParameters.EndLocation.y];
		}

		public List<Vector2> FindPath ()
		{
			List<Vector2> path = new List<Vector2> ();
			bool success = Search (startNode);
			if (success)
			{
				Node node = this.endNode;
				while (node.ParentNode != null)
				{
					path.Add (node.Location);
					node = node.ParentNode;
				}
				path.Reverse ();
			}
			return path;
		}

		private void InitializeNodes (bool [,] map)
		{
			this.width = map.GetLength (0);
			this.height = map.GetLength (1);
			this.nodes = new Node [this.width, this.height];
			for (int y = 0; y < this.height; y++)
				for (int x = 0; x < this.width; x++)
					this.nodes [x, y] = new Node (x, y, map [x, y], this.searchParameters.EndLocation);
		}

		bool Search (Node currentNode)
		{
			currentNode.state = NodeState.Closed;
			List<Node> nextNodes = GetAdjacentWalkableNodes (currentNode);
			nextNodes.Sort ((node1, node2) => node1.F.CompareTo (node2.F));
			foreach (var nextNode in nextNodes)
			{
				if (nextNode.Location == endNode.Location)
					return true;
				if (Search (nextNode))
					return true;
			}
			return false;
		}

		List<Node> GetAdjacentWalkableNodes (Node currentNode)
		{
			List<Node> walkableNodes = new List<Node> ();
			IEnumerable<Vector2> nextLocations = GetAdjacentLocations (currentNode.Location);

			foreach (Vector2 location in nextLocations)
			{
				int x = location.x;
				int y = location.y;

				if (x < 0 || x >= this.width || y < 0 || y >= this.height)
					continue;

				Node node = nodes [x, y];
				if (!node.IsWalkable)
					continue;

				if (node.state == NodeState.Closed)
					continue;

				if (node.state == NodeState.Open)
				{
					float traversalCost = Node.GetTraversalCost (node.Location, node.ParentNode.Location);
					float gTemp = currentNode.G + traversalCost;
					if (gTemp < node.G)
					{
						node.ParentNode = currentNode;
						walkableNodes.Add (node);
					}
				}
				else
				{
					node.ParentNode = currentNode;
					node.state = NodeState.Open;
					walkableNodes.Add (node);
				}
			}

			return walkableNodes;
		}

		IEnumerable<Vector2> GetAdjacentLocations (Vector2 location)
		{
			return new Vector2 []
			{
					new Vector2(location.x - 1, location.y),
					new Vector2(location.x + 1, location.y),
					new Vector2(location.x, location.y - 1),
					new Vector2(location.x, location.y + 1)
			};
		}
	}

	public class SearchParameters
	{
		public SearchParameters (Vector2 startLocation, Vector2 endLocation, bool [,] grid)
		{
			this.StartLocation = startLocation;
			this.EndLocation = endLocation;
			this.Map = grid;
		}

		public Vector2 StartLocation { get; set; }
		public Vector2 EndLocation { get; set; }
		public bool [,] Map { get; set; }
	}
	public class Node
	{
		private Node parentNode;

		public Vector2 Location { get; private set; }
		public bool IsWalkable { get; set; }
		public float G { get; private set; } // Length of path from start to here
		public float H { get; private set; } // Straight line distance from this to end
		public float F { get { return this.G + this.H; } } // Estimated total distance
		public NodeState state { get; set; }
		public Node ParentNode
		{
			get { return parentNode; }
			set
			{
				this.parentNode = value;
				this.G = this.parentNode.G + GetTraversalCost (this.Location, this.parentNode.Location);
			}
		}

		public Node (int x, int y, bool isWalkable, Vector2 endLocation)
		{
			this.Location = new Vector2 (x, y);
			this.state = NodeState.Untested;
			this.IsWalkable = isWalkable;
			this.H = GetTraversalCost (this.Location, endLocation);
			this.G = 0;
		}

		internal static float GetTraversalCost (Vector2 location, Vector2 otherLocation)
		{
			float deltaX = otherLocation.x - location.x;
			float deltaY = otherLocation.y - location.y;
			return (float)Math.Sqrt (deltaX * deltaX + deltaY * deltaY);
		}
	}
	public enum NodeState { Untested, Open, Closed }
}
