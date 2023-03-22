using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_Ckptw.src.DFS
{
    internal class DFS
    {
        private char[,] mapMaze;
        private int row;
        private int col;
        private int treasure;
        private Stack<Tuple<int,int>> stack = new Stack<Tuple<int,int>>();


        public DFS(char[,] mapMaze) { 
            this.mapMaze = mapMaze;
            this.row = mapMaze.GetLength(0);
            this.col = mapMaze.GetLength(1);

            for(int i = 0; i < this.row; i++)
            {
                for(int j = 0; j < this.col; j++)
                {
                    if (this.mapMaze[i, j] == 'K') this.stack.Push(new Tuple<int, int>(i, j));
                    if (this.mapMaze[i, j] == 'T') this.treasure++;
                }
            }
        }

        public List<char> getDFS()
        {
            List<char> list = new List<char>();
            List<Tuple<int, int>> direction = getDirection();

            for(int i = 0; i < getDirection().Count - 1; i++)
            {
                if (direction[i + 1].Item1 - direction[i].Item1 == 1) list.Add('D');
                if (direction[i + 1].Item1 - direction[i].Item1 == -1) list.Add('U');
                if (direction[i + 1].Item2 - direction[i].Item2 == 1) list.Add('R');
                if (direction[i + 1].Item2 - direction[i].Item2 == -1) list.Add('L');
            }
            return list;
        }
        private List<Tuple<int,int>> getDirection()
        {
            List<Tuple<int, int>> direction = new List<Tuple<int, int>>();
            Tuple<int, int> currentDir = this.stack.Pop();
            Tuple<int, int> prevDir = currentDir;
            direction.Add(currentDir);

            while (this.treasure != 0)
            {
                int check = 0;
                if (this.mapMaze[currentDir.Item1,currentDir.Item2]=='T') this.treasure--;
                try
                {
                    
                    if ((this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] == 'T' ||
                        this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] == 'R')&&
                        new Tuple<int,int>(currentDir.Item1 - 1, currentDir.Item2)!=prevDir
                        ) {

                        this.stack.Push(new Tuple<int, int>(currentDir.Item1 - 1, currentDir.Item2));
                        direction.Add(new Tuple<int, int>(currentDir.Item1 - 1, currentDir.Item2)); 
                        check = 1;
                    }
                    if ((this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] == 'T' ||
                        this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] == 'R')&&
                        new Tuple<int, int>(currentDir.Item1 + 1, currentDir.Item2)!=prevDir
                        ) {

                        this.stack.Push(new Tuple<int, int>(currentDir.Item1 + 1, currentDir.Item2));
                        direction.Add(new Tuple<int, int>(currentDir.Item1 + 1, currentDir.Item2));
                        check = 1;
                    }
                    if ((this.mapMaze[currentDir.Item1, currentDir.Item2 - 1] == 'T' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2 - 1] == 'R')&&
                        new Tuple<int, int>(currentDir.Item1, currentDir.Item2 - 1)!=prevDir
                        ) { 

                        this.stack.Push(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 - 1));
                        direction.Add(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 - 1));
                        check = 1;
                    }
                    if ((this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] == 'T' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] == 'R' )&& 
                        new Tuple<int, int>(currentDir.Item1, currentDir.Item2 + 1) != prevDir
                        ) { 

                        this.stack.Push(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 + 1));
                        direction.Add(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 + 1));
                        check = 1;
                    }
                } catch(IndexOutOfRangeException e){}

                if (check == 0)
                {
                    while (direction[direction.Count - 1] != currentDir)
                    {
                        direction.RemoveAt(direction.Count - 1);
                    }
                }

                prevDir = currentDir;
                currentDir = this.stack.Pop();
            }

            return direction;
        }




    }
}
