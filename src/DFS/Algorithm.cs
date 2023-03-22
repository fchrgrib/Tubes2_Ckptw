﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes2_Ckptw.src.FileReader;
using static Tubes2_Ckptw.src.FileReader.FileReader;

namespace Tubes2_Ckptw.src.DFS
{
    internal class DFS
    {


        static void Main()
        {
            FileReader.FileReader fr = new FileReader.FileReader("text.txt");


            DFS dfs = new DFS(fr.getMapMaze());
            List<char> movement = dfs.getMovementTSP();
            Debug.WriteLine(movement.Count);
            for (int i = 0; i < movement.Count; i++)
            {

                Debug.WriteLine(movement[i]);
            }
        }
        private char[,] mapMaze;
        private int row;
        private int col;
        private int treasure;
        private List<Tuple<int,int>> liveNode = new List<Tuple<int,int>>();
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

        public List<char> getMovementTreasure()
        {
            List<char> list = new List<char>();
            List<Tuple<int, int>> direction = getDirectionTreasure();

            for(int i = 0; i < direction.Count - 1; i++)
            {
                if (direction[i + 1].Item1 - direction[i].Item1 == 1) list.Add('D');
                if (direction[i + 1].Item1 - direction[i].Item1 == -1) list.Add('U');
                if (direction[i + 1].Item2 - direction[i].Item2 == 1) list.Add('R');
                if (direction[i + 1].Item2 - direction[i].Item2 == -1) list.Add('L');
            }
            return list;
        }
        public List<char> getMovementTSP()
        {
            List<char> list = new List<char>();
            List<Tuple<int, int>> direction = getDirectionTSP();

            for (int i = 0; i < direction.Count - 1; i++)
            {
                if (direction[i + 1].Item1 - direction[i].Item1 == 1) list.Add('D');
                if (direction[i + 1].Item1 - direction[i].Item1 == -1) list.Add('U');
                if (direction[i + 1].Item2 - direction[i].Item2 == 1) list.Add('R');
                if (direction[i + 1].Item2 - direction[i].Item2 == -1) list.Add('L');
            }
            return list;
        }
        private List<Tuple<int,int>> getDirectionTreasure()
        {
            List<Tuple<int, int>> direction = new List<Tuple<int, int>>();
            Tuple<int, int> currentDir=this.stack.Pop();
            Tuple<int, int> prevDir= new Tuple<int, int>(-1,-1) ;
            direction.Add(currentDir);
            this.liveNode.Add(currentDir);

            

            while (this.treasure > 0)
            {
                int check = 0;

                try
                {
                    if ((this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] == 'T' ||
                        this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] == 'R') && (
                        isLiveNode(new Tuple<int, int>(currentDir.Item1-1,currentDir.Item2))&&
                        this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] != 'X')
                        )
                    {
                        this.stack.Push(new Tuple<int, int>(currentDir.Item1 - 1, currentDir.Item2));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }


                try
                {
                    if ((this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] == 'T' ||
                        this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] == 'R') &&(
                        isLiveNode(new Tuple<int, int>(currentDir.Item1+1,currentDir.Item2)) &&
                        this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] != 'X')
                        )
                    {
                        this.stack.Push(new Tuple<int, int>(currentDir.Item1 + 1, currentDir.Item2));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }

                try
                {
                    if ((this.mapMaze[currentDir.Item1, currentDir.Item2 - 1] == 'T' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2 - 1] == 'R') &&(
                        isLiveNode(new Tuple<int, int>(currentDir.Item1,currentDir.Item2-1)) &&
                        this.mapMaze[currentDir.Item1, currentDir.Item2-1] != 'X')
                        )
                    {
                        this.stack.Push(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 - 1));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }

                try
                {
                    if ((this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] == 'T' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] == 'R') &&(
                        isLiveNode(new Tuple<int,int>(currentDir.Item1,currentDir.Item2+1)) &&
                        this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] != 'X')
                        )
                    {

                        this.stack.Push(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 + 1));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }



                prevDir = currentDir;


                currentDir = this.stack.Pop();
                
                if (this.mapMaze[currentDir.Item1, currentDir.Item2] == 'T') this.treasure--;

                if (check == 0)
                {
                    int lebi = Math.Abs(currentDir.Item1 - prevDir.Item1 + currentDir.Item2 - prevDir.Item2) - 1;
                    int jumlah = direction[direction.Count-1].Item1 + direction[direction.Count-1].Item2-(lebi);
                    int calculate = Math.Abs(jumlah - (currentDir.Item1 + currentDir.Item2 - 1));
                   


                        for (int i = 0; i < Math.Abs(calculate); i++)
                        {
                            direction.RemoveAt(direction.Count - 1);
                        }
                    
                    prevDir = new Tuple<int, int>(direction[direction.Count - 1].Item1-1, direction[direction.Count - 1].Item2-1);
                }
                direction.Add(currentDir);
                this.liveNode.Add(currentDir);

            }
            this.stack.Clear();
            this.liveNode.Clear();
            return direction;
        }

        private List<Tuple<int,int>> getDirectionTSP()
        {
            List<Tuple<int, int>> direction = getDirectionTreasure();
            Tuple<int, int> currentDir = direction[direction.Count-1];
            Tuple<int, int> prevDir = new Tuple<int, int>(-1, -1);
            this.liveNode.Add(currentDir);
            this.stack.Push(currentDir);

            int start = 1;



            while (start > 0)
            {
                int check = 0;

                try
                {
                    if ((this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] == 'T' ||
                        this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] == 'R'||
                        this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] == 'K') && (
                        isLiveNode(new Tuple<int, int>(currentDir.Item1 - 1, currentDir.Item2)) &&
                        this.mapMaze[currentDir.Item1 - 1, currentDir.Item2] != 'X')
                        )
                    {
                        this.stack.Push(new Tuple<int, int>(currentDir.Item1 - 1, currentDir.Item2));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }


                try
                {
                    if ((this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] == 'T' ||
                        this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] == 'R' ||
                        this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] == 'K') && (
                        isLiveNode(new Tuple<int, int>(currentDir.Item1 + 1, currentDir.Item2)) &&
                        this.mapMaze[currentDir.Item1 + 1, currentDir.Item2] != 'X')
                        )
                    {
                        this.stack.Push(new Tuple<int, int>(currentDir.Item1 + 1, currentDir.Item2));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }

                try
                {
                    if ((this.mapMaze[currentDir.Item1, currentDir.Item2 - 1] == 'T' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2 - 1] == 'R' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2-1] == 'K') && (
                        isLiveNode(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 - 1)) &&
                        this.mapMaze[currentDir.Item1, currentDir.Item2-1] != 'X')
                        )
                    {
                        this.stack.Push(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 - 1));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }

                try
                {
                    if ((this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] == 'T' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] == 'R' ||
                        this.mapMaze[currentDir.Item1, currentDir.Item2+1] == 'K') && (
                        isLiveNode(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 + 1)) &&
                        this.mapMaze[currentDir.Item1, currentDir.Item2 + 1] != 'X')
                        )
                    {

                        this.stack.Push(new Tuple<int, int>(currentDir.Item1, currentDir.Item2 + 1));
                        check = 1;
                    }
                }
                catch (ArgumentOutOfRangeException e) { }
                catch (IndexOutOfRangeException e) { }



                prevDir = currentDir;

                currentDir = this.stack.Pop();

                if (this.mapMaze[currentDir.Item1, currentDir.Item2] == 'K') start--;

                if (check == 0)
                {
                    int lebi = Math.Abs(currentDir.Item1 - prevDir.Item1 + currentDir.Item2 - prevDir.Item2) - 1;
                    int jumlah = direction[direction.Count - 1].Item1 + direction[direction.Count - 1].Item2 - (lebi);
                    int calculate = Math.Abs(jumlah - (currentDir.Item1 + currentDir.Item2 - 1));



                    for (int i = 0; i < Math.Abs(calculate); i++)
                    {
                        direction.RemoveAt(direction.Count - 1);
                    }

                    prevDir = new Tuple<int, int>(direction[direction.Count - 1].Item1 - 1, direction[direction.Count - 1].Item2 - 1);
                }
                direction.Add(currentDir);
                this.liveNode.Add(currentDir);

            }
            this.stack.Clear();
            this.liveNode.Clear();
            return direction;
        }

        private bool isLiveNode(Tuple<int,int> sample)
        {
            bool itIs = true;

            for(int i = 0; i < this.liveNode.Count; i++)
            {
                if (sample.Item1 == this.liveNode[i].Item1 && sample.Item2 == this.liveNode[i].Item2) itIs = false;
            }

            return itIs;
        }


    }
}