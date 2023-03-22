using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
// using fr = Tubes2_Ckptw.src.FileReader;
// using Tubes2_Ckptw.src.Enums;

namespace Tubes2_Ckptw.Algorithm
{
    internal class BFS{
        private Tuple<int, int> start;
        private int treasureCount = 0;
        private Dictionary<Tuple<int, int>, List<Tuple<char,List<Tuple<int,int>>, Tuple<int, int>>>> graph;
        private Queue<Tuple<string,List<Tuple<int,int>>, Tuple<int, int>>> q = new Queue<Tuple<string, List<Tuple<int, int>>, Tuple<int, int>>>();
        private bool[,] visited;
        internal BFS(){
            // fr.FileReader file = new fr.FileReader("bfs1.txt");
            // char[,] mapMaze = file.getMapMaze();
            char[,] mapMaze = {
                {'K','R','R','R'},
                {'X','R','X','T'},
                {'X','T','R','R'},
                {'X','T','X','X'}
            };
            graph = toGraph(mapMaze);
            visited = new bool[mapMaze.GetLength(0), mapMaze.GetLength(1)];

            foreach(Tuple<int,int> node in graph.Keys)
            {
                foreach(var (direction, count, neighbour) in graph[node])
                {
                    Debug.WriteLine(String.Format("{0} {1} {2} {3} {4}", mapMaze[node.Item1,node.Item2], node, direction, count, neighbour));
                }
            }
        }
        private Dictionary<Tuple<int, int>, List<Tuple<char, List<Tuple<int, int>>, Tuple<int, int>>>> toGraph(char[,] maze){ // {(x,y): [(MOVEMENT, (a,b))]}
            int k_count = 0;

            int height = maze.GetLength(0);
            int width = maze.GetLength(1);
            var graph = new Dictionary<Tuple<int, int>, List<Tuple<char, List<Tuple<int, int>>, Tuple<int, int>>>>();

            for(int row = 0; row<height; row++){
                for(int col = 0; col<width; col++){
                    if("KRT".Contains(maze[row,col].ToString())){
                        graph.Add(Tuple.Create(row,col), new List<Tuple<char,List<Tuple<int,int>>, Tuple<int, int>>>());
                    }
                    else if(maze[row,col] != 'X') throw new Exception(String.Format("{0} is not a valid Symbol", maze[row,col]));
                    if(maze[row,col] == 'T') treasureCount++;
                    if(maze[row,col] == 'K') {
                        start = Tuple.Create(row,col);
                        k_count++;
                    }

                }
            }

            foreach(Tuple<int,int> current in graph.Keys){
                int row = current.Item1;
                int col = current.Item2;
                Tuple<int,int> down = new Tuple<int,int>(row+1,col);
                Tuple<int,int> right = new Tuple<int,int>(row,col+1);
                if(graph.ContainsKey(down)){
                    graph[current].Add(Tuple.Create('D', maze[row+1, col]=='T' ? new List<Tuple<int,int>>(){Tuple.Create(row+1,col)} : new List<Tuple<int,int>>(), Tuple.Create(row+1,col)));
                    graph[down].Add(Tuple.Create('U', maze[row, col]=='T' ? new List<Tuple<int,int>>(){Tuple.Create(row,col)} : new List<Tuple<int,int>>(), Tuple.Create(row,col)));
                }
                if(graph.ContainsKey(right)){
                    graph[current].Add(Tuple.Create('R', maze[row,col+1]=='T' ? new List<Tuple<int,int>>(){Tuple.Create(row,col+1)} : new List<Tuple<int,int>>(), Tuple.Create(row, col+1)));
                    graph[right].Add(Tuple.Create('L', maze[row,col]=='T' ? new List<Tuple<int,int>>(){Tuple.Create(row,col)} : new List<Tuple<int,int>>(), Tuple.Create(row, col)));
                }
            }

            if(k_count!=1) throw new Exception("There can only be 1 KrustyKrab");
            if(treasureCount==0) throw new Exception("There must be at least 1 Treasure");

            return graph;
        }

        public char[] solve(){
            int start_row = start.Item1;
            int start_col = start.Item2;
            q.Enqueue(Tuple.Create("",new List<Tuple<int,int>>(),start));

            while(q.Count != 0){
                var (path, treasures, current) = q.Dequeue();
                var (current_row, current_col) = current;

                Debug.WriteLine(String.Format("{0} {1} {2}", current, path, treasures.Count));
                if(treasures.Count==treasureCount) return path.ToCharArray();

                if(visited[current_row, current_col]) continue;
                visited[current_row,current_col] = true;

                foreach(var node in graph[current]){
                    char direction = node.Item1;
                    var newTreasures = treasures.Union(node.Item2).ToList();
                    Tuple<int,int> neighbour = node.Item3;
                    q.Enqueue(Tuple.Create(path+direction, newTreasures, neighbour));
                }
            }

            return "Tidak ada solusi".ToCharArray();
        }
    }
}