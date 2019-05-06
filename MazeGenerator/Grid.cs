using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator
{
	class Grid
	{
		private int rows;
		private int columns;

		private Cell[,] grid;

        ///-----------------------------------------------Initializers-----------------------------------------------///

        public Grid(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;

			InitGrid();
			ConfigureCells();
		}

		/// <summary>
        /// Instanciate a cell at each grid point based on the number of rows and columns provided.
        /// </summary>
		private void InitGrid()
		{
			grid = new Cell[rows, columns];

			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < columns; ++j)
				{
					grid[i, j] = new Cell(i, j);
				}
			}
		}

		/// <summary>
        /// Sets up the neighbors for each of the cells in the grid.
        /// </summary>
		private void ConfigureCells()
		{
			foreach (Cell cell in grid)
			{
				int row = cell.Row;
				int column = cell.Column;

				cell.North = this[row - 1, column];
				cell.East = this[row, column + 1];
				cell.South = this[row + 1, column];
				cell.West = this[row, column - 1];
			}
		}

        ///-----------------------------------------------Accessors and Modifiers-----------------------------------------------///

        /// <summary>
        /// Custom accessors for the grid ensures that given values are within the bounds of the array.
        /// </summary>
        public Cell this[int i, int j]
		{
			get
			{

				if (i >= 0 && i < rows && j >= 0 && j < columns)
				{
					return grid[i, j];
				}

				return null;
			}

		}

        public int Size()
        {
            return rows * columns;
        }

        /// <summary>
        /// Iterates over each row in the grid.
        /// </summary>
        /// <returns>Cell[] - the current row of cells in the grid.</returns>
		public IEnumerable<Cell[]> EachRow()
        {
            for (int i = 0; i < rows; ++i)
            {
                yield return Enumerable.Range(0, rows)
                    .Select(x => grid[i, x])
                    .ToArray();
            }
        }

        /// <summary>
        /// Iterates over each Cell in the grid.
        /// </summary>
        /// <returns>Cell - the current Cell in the grid.</returns>
		public IEnumerable<Cell> EachCell()
        {
            foreach (Cell cell in grid)
            {
                yield return cell;
            }
        }

        /// <summary>
        /// Override the ToString method so that the grid can be displayed in the console in a human readable form.
        /// </summary>
        /// <returns>string - human readable version of the grid.</returns>
		public override string ToString()
        {
            string output = "+";

            for (int i = 0; i < columns; ++i)
                output = string.Concat(output, "---+");

            output = string.Concat(output, "\n");

            string corner = "+";

            foreach (Cell[] row in EachRow())
            {
                string top = "|";
                string bottom = "+";


                foreach (Cell cell in row)
                {

                    string body = "   ";
                    string eastBoundary = (cell.Linked(cell.East)) ? " " : "|";

                    top = string.Concat(top, body, eastBoundary);

                    string southBoundary = (cell.Linked(cell.South)) ? "   " : "---";

                    bottom = string.Concat(bottom, southBoundary, corner);
                }

                output = string.Concat(output, top, "\n", bottom, "\n");
            }

            return output;
        }

        ///-------------------------------------------------------Methods-------------------------------------------------------///

        /// <summary>
        /// Choose a cell in the grid at random.
        /// </summary>
        /// <returns>Cell - chosen cell.</returns>
        public Cell RandomCell()
		{
			Random rand = new Random();
			int row = rand.Next(rows);
			int column = rand.Next(columns);

			return grid[row, column];
		}
	}
}
