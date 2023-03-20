using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes2_Ckptw.ViewModels;

namespace Tubes2_Ckptw.Models
{
    public class Maze
    {
        private int Width
        {
            get; set;
        }
        private int Height
        {
            get; set;
        }
        private MazePath[,] path;

        public Maze(char[,] _maze)
        {
            Width = _maze.GetLength(0);
            Height = _maze.GetLength(1);

            path = new MazePath[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    path[i, j] = new MazePath(_maze[i, j]);
                }
            }
        }

        public void Print()
        {
            /*
			 * to make debug messages clearer, turn Symbol load message off
			 * how to:
			 * Go to Debug > Options
			 * on Tab Debugging > Output Window, turn "Module Load Messages" off
			 */
            for (int i = 0; i < path.GetLength(0); i++)
            {
                for (int j = 0; j < path.GetLength(1); j++)
                {
                    Debug.Write(path[i, j] + " ");
                }
                Debug.WriteLine("");
            }
        }
    }
}
