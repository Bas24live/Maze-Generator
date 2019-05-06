using System;
using System.Collections.Generic;

namespace MazeGenerator
{
	class BinaryTree
	{
		public Grid grid;

		int rows, columns;

		///-----------------------------------------------------Initializer-----------------------------------------------------///
		public BinaryTree(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;

			grid = new Grid(rows, columns);
		}

		///-----------------------------------------------Accessors and Modifiers-----------------------------------------------///
		public int Rows { get => rows; set => rows = value; }

		public int Columns { get => columns; set => columns = value; }

		///-------------------------------------------------------Methods-------------------------------------------------------///
		
		/// <summary>
		/// Generate a maze based of the Binary Tree algorithm, this will create a maze of the specified size, the maze will have a strong north east bias by default.
		/// </summary>
		/// <returns>Grid - a grid in the form of the Binary Tree maze.</returns>
		public Grid GenerateMaze()
		{
			Random random = new Random();

			foreach (Cell cell in grid.EachCell())
			{
				List<Cell> neighbors = new List<Cell>();

				if (cell.North != null)
					neighbors.Add(cell.North);

				if (cell.East != null)
					neighbors.Add(cell.East);

				if (neighbors.Count > 0)
				{
					int index = random.Next(neighbors.Count);

					cell.Link(neighbors[index]);
				}
			}

			return grid;
		}
	}
}
