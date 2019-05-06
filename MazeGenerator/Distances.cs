using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
	class Distances
	{
		Dictionary<Cell, int> cells;
		Cell root;

		public Distances(Cell root)
		{
			this.root = root;

			cells = new Dictionary<Cell, int>();
			cells[root] = 0;
		}

		//Set the distance for a given cell
		public void SetDistance(Cell cell, int distance)
		{
			cells[cell] = distance;
		}

		//Return the distance for a given cell
		public int GetDistance(Cell cell)
		{
			return cells[cell];
		}

		//Returns an array of the cells currently in the cells dictionary
		public Cell[] Cells()
		{
			return cells.Keys.ToArray();
		}
	}
}
