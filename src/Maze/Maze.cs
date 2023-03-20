using System;
using System.Diagnostics;

namespace Tubes2_Ckptw.src
{
    internal class Maze
	{
		private char[,] map;
		public Maze(char[,] map)
		{
			this.map = map;
		}

		public void Print()
		{
			/*
			 * to make debug messages clearer, turn Symbol load message off
			 * how to:
			 * Go to Debug > Options
			 * on Tab Debugging > Output Window, turn "Module Load Messages" off
			 */
			for(int i = 0; i < map.GetLength(0); i++)
			{
				for(int j = 0; j < map.GetLength(1); j++)
				{
					Debug.Write(map[i, j] + " ");
				}
				Debug.WriteLine("");
			}
		}
	}
}