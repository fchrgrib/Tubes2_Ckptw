﻿using Avalonia.Media;
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
            Height = 0;
            Width = 0;

            path = new MazePath[Height, Width]; 
        }
        public Maze(char[,] _maze)
        {
            Height = _maze.GetLength(0);    // i
            Width = _maze.GetLength(1);     // j

            path = new MazePath[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
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
                    Debug.Write(path[i, j].PathSymbol + " ");
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
                //Debug.WriteLine("ngambil " + temp.Count);
                return temp.ToArray();
            }
        }
    }
}
