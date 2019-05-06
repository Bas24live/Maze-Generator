using System;
using System.Collections.Generic;

namespace MazeGenerator
{
	class Sidewinder
	{
		public Grid grid;

		int bias = 2;
		int rows, columns;

		///-----------------------------------------------------Initializer-----------------------------------------------------///
		public Sidewinder(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;

			grid = new Grid(rows, columns);
		}

		///-----------------------------------------------Accessors and Modifiers-----------------------------------------------///
		public int Rows { get => rows; set => rows = value; }

		public int Columns { get => columns; set => columns = value; }

		public int Bias { get => bias; set => bias = value; }

		///-------------------------------------------------------Methods-------------------------------------------------------///

		/// <summary>
		/// Generate a maze based of the Sidewinder algorithm, this will create a maze of the specified size generally with a string South to North texture,.
		/// Texture depends on the bias value, a bias of 2 has a strong South to North texture, while a bias of 3 creates a more uniform texture.
		/// </summary>
		/// <returns>Grid - a grid in the form of the Sidewinder maze.</returns>
		public Grid GenerateMaze()
		{
			Random random = new Random();

			foreach (Cell[] row in grid.EachRow())
			{
				List<Cell> run = new List<Cell>();
				foreach (Cell cell in row)
				{
					run.Add(cell);

					bool atNorthernBoundary = (cell.North == null);
					bool atEasternBoundary = (cell.East == null);

					// Note: A bias value of 3 creates a more uniform texture while a value of 2 creates a south to north texture
					bool closeOut = atEasternBoundary || (!atNorthernBoundary && random.Next(bias) == 0);

					if (closeOut)
					{
						Cell runCell = run[random.Next(run.Count)];

						if (runCell.North != null)
						{
							runCell.Link(runCell.North);
						}

						run.Clear();
					} else
					{
						cell.Link(cell.East);
					}
				}

			}

			return grid;
		}
	}
}
