using System.Collections.Generic;

namespace MazeGenerator
{
	class Cell
	{
		private int row;
		private int column;

		private Cell north;
		private Cell east;
		private Cell south;
		private Cell west;

		private Dictionary<Cell, bool> links;

		public Cell(int row, int column)
		{
			this.row = row;
			this.column = column;
			links = new Dictionary<Cell, bool>();
		}

		///-----------------------------------------------Accessors and Modifiers-----------------------------------------------///
		
		public int Row { get => row; set => row = value; }

		public int Column { get => column; set => column = value; }

		public Cell North { get => north; set => north = value; }

		public Cell East { get => east; set => east = value; }

		public Cell South { get => south; set => south = value; }

		public Cell West { get => west; set => west = value; }


		///-------------------------------------------------------Methods-------------------------------------------------------///
		
		/// <summary>
		/// Add a link from this cell to the given cell.
		/// If the there is no link from the given cell to this cell as denoted by the bidi param, 
		/// add a linked in the oposite direction.
		/// </summary>
		/// <param name="cell">Ths cell to be linked.</param>
		/// <param name="bidi">A parameter telling this function whether there is a link on the given cell or not.</param>
		/// <returns>this cell</returns>
		public Cell Link(Cell cell, bool bidi = true)
		{
			links.Add(cell, true);

			if (bidi)
			{
				cell.Link(this, false);
			}

			return this;
		}


		/// <summary>
		/// Remove the link from this cell to the given cell.
		/// If the there is a link from the given cell to this cell as denoted by the bidi param, 
		/// remove the linked in the oposite direction.
		/// </summary>
		/// <param name="cell">The cell to be unlinked</param>
		/// <param name="bidi">A parameter telling this function whether there is still a link on the given cell or not.</param>
		/// <returns>this cell</returns>
		public Cell Unlink(Cell cell, bool bidi = true)
		{
			links.Remove(cell);

			if (bidi)
			{
				cell.Unlink(this, false);
			}

			return this;
		}

		/// <summary>
		/// Returns a list of cells that are linked to this cell. 
		/// A cell is linked if it exists as a key in the links dictionary.
		/// </summary>
		/// <returns>A list of linked cells.</returns>
		public List<Cell> Links()

		{
			List<Cell> linkedCells = new List<Cell>();

			foreach (Cell cell in links.Keys)
			{
				linkedCells.Add(cell);
			}

			return linkedCells;
		}

		/// <summary>
		/// Is the given cell linked?
		/// </summary>
		/// <param name="cell">The cell that could be linked.</param>
		/// <returns>Whether there is a link to the given cell or not.</returns>
		public bool Linked(Cell cell)
		{
			if (cell != null)
				return links.ContainsKey(cell);

			return false;
		}

		/// <summary>
		/// Check for neighbours in all directions, if they exist, add them to a list.
		/// </summary>
		/// <returns>A list of all the neighbors of this cell.</returns>
		public List<Cell> Neighbors()
		{
			List<Cell> neighbors = new List<Cell>();

			if (north != null)
				neighbors.Add(north);

			if (east != null)
				neighbors.Add(east);

			if (south != null)
				neighbors.Add(south);

			if (west != null)
				neighbors.Add(west);

			return neighbors;
		}
	}
}
