using System;

namespace MazeGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			Grid grid = null;

			bool makingMazes = true;
			bool choosing = true;

			while(makingMazes)
			{
				do
				{
					WriteOptions();
					string result = Console.ReadLine();
					Console.Write("\n\n");

					switch (result)
					{
						case "1":
							grid = new BinaryTree(4, 4).GenerateMaze();
							choosing = false;
							break;
						case "2":
							grid = new Sidewinder(4, 4).GenerateMaze();
							choosing = false;
							break;
						case "9":
							choosing = false;
							makingMazes = false;
							break;
						default:
							break;
					}
				} while (choosing);

				if (makingMazes)
				{
					choosing = true;
					Console.Write(grid.ToString());
					Console.WriteLine("\n\nPress enter to continue...");
					Console.ReadLine();
				}
			}
		}


		private static void WriteOptions()
		{
			Console.WriteLine("Choose from the options below to generate a maze of your choice:");
			Console.WriteLine("1: Binary Tree.");
			Console.WriteLine("2: Sidewinder.");
			Console.WriteLine("9: Exit.");
		}
	}
}
