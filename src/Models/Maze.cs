using DynamicData;
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
        public int Width
        {
            get;
        }
        public int Height
        {
            get;
        }
        private MazePath[,] path;

        public Maze()
        {
            Width = 0;
            Height = 0;
            path = new MazePath[Width, Height]; 
        }
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

        public MazePath[] MazePaths
        {
            get
            {
                List<MazePath> temp = new List<MazePath>();
                for(int i = 0; i < path.GetLength(0); i++)
                {
                    for(int j=0; j < path.GetLength(1); j++)
                    {
                        temp.Add(path[i, j]);
                    }
                }

                return temp.ToArray();
            }
        }
    }
}
