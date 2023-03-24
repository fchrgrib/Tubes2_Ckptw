using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Tubes2_Ckptw.Algorithm{
    internal class BFS{
        private Stopwatch sw = new Stopwatch();
        private int sizeStep = 0;
        private int lengthNode = 0;
        private Tuple<int, int> start;
        private int treasureCount = 0;
        private int height, width;
        private Dictionary<Tuple<int, int>, List<Tuple<char,List<Tuple<int,int>>, Tuple<int, int>>>> graph;
        private Queue<BFS_Tuple> q = new Queue<BFS_Tuple>();
        public BFS(char[,] mapMaze){
            graph = toGraph(mapMaze);
        }

        public string getTimeExec()
        {
            return this.sw.ElapsedMilliseconds.ToString();
        }
        public int getStep()
        {
            return this.sizeStep;
        }
        public int getNode()
        {
            return this.lengthNode;
        }
        private Dictionary<Tuple<int, int>, List<Tuple<char, List<Tuple<int, int>>, Tuple<int, int>>>> toGraph(char[,] maze){ // {(x,y): [(MOVEMENT, (a,b))]}
            int k_count = 0;

            height = maze.GetLength(0);
            width = maze.GetLength(1);
            var graph = new Dictionary<Tuple<int, int>, List<Tuple<char, List<Tuple<int, int>>, Tuple<int, int>>>>();

            for(int row = 0; row<height; row++){
                for(int col = 0; col<width; col++){
                    if("KRT".Contains(maze[row,col].ToString())){
                        graph.Add(Tuple.Create(row,col), new List<Tuple<char,List<Tuple<int,int>>, Tuple<int, int>>>());
                    }
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
            return graph;
        }

        public List<char> solve(bool tsp){
            sizeStep = 0;
            lengthNode = 0;
            sw.Reset();
            sw.Start();
            var (start_row, start_col) = start;
            q.Enqueue(new BFS_Tuple("", new List<Tuple<int,int>>(), new HashSet<Tuple<int,int>>(),start, new Stack<Tuple<Tuple<int,int>, int, char>>(), new int[height,width]));

            while(q.Count != 0){
                var bfs_tuple = q.Dequeue();
                lengthNode++;
                var (current_row, current_col) = bfs_tuple.position;

                Debug.WriteLine(String.Format("{0} {1} {2}", bfs_tuple.position, bfs_tuple.path, bfs_tuple.treasures.Count));
                if (bfs_tuple.treasures.Count == treasureCount) {
                    if (tsp)
                    {
                        Debug.WriteLine("Return tsp");
                        var pathBack = pathToStart(bfs_tuple);
                        sw.Stop();
                        sizeStep = bfs_tuple.path.Length + pathBack.path.Length;
                        return (bfs_tuple.path + pathBack.path).ToList();
                    }
                    else
                    {
                        Debug.WriteLine("Return");
                        sw.Stop();
                        sizeStep = bfs_tuple.path.Length;
                        return bfs_tuple.path.ToList();
                    }
                }

                if (allNeighboursVisited(bfs_tuple) && bfs_tuple.stack.Count != 0 && bfs_tuple.treasures.Count > bfs_tuple.stack.Peek().Item2) // backtrack
                {
                    var (previousPosition, previousTreasureCount, previousDirection) = bfs_tuple.stack.Pop();
                    bfs_tuple.path_list.Add(bfs_tuple.position);
                    var newPath = bfs_tuple.path + reverseDirection(previousDirection);
                    var newPathList = bfs_tuple.path_list.Union(new List<Tuple<int, int>>() { bfs_tuple.position }).ToList();
                    var newTreasures = bfs_tuple.treasures;
                    var newVisited = new int[height,width];
                    foreach(var path in newPathList)
                    {
                        newVisited[path.Item1, path.Item2]++;
                    }
                    q.Enqueue(new BFS_Tuple(newPath, newPathList, newTreasures, previousPosition, bfs_tuple.stack, newVisited));
                    bfs_tuple.visited[current_row,current_col]++;
                    continue;
                }
                if(bfs_tuple.visited[current_row, current_col]>0 && !(bfs_tuple.stack.Count != 0 && bfs_tuple.treasures.Count > bfs_tuple.stack.Peek().Item2))
                {
                    continue;
                }
                bfs_tuple.visited[current_row,current_col]++;

                foreach(var node in graph[bfs_tuple.position]){
                    char direction = node.Item1;

                    var newTreasures = new HashSet<Tuple<int,int>>(bfs_tuple.treasures);
                    if(node.Item2.Count!=0) newTreasures.Add(node.Item2[0]);

                    Tuple<int,int> neighbour = node.Item3;
                    var newPathList = bfs_tuple.path_list.Union(new List<Tuple<int, int>>() { neighbour }).ToList();

                    var newStack = new Stack<Tuple<Tuple<int, int>, int, char>>(new Stack<Tuple<Tuple<int,int>, int, char>>(bfs_tuple.stack));
                    if(!allNeighboursVisited(bfs_tuple))newStack.Push(Tuple.Create(bfs_tuple.position, bfs_tuple.treasures.Count, direction));

                    var newVisited = new int[height, width];
                    if (newTreasures.Count > bfs_tuple.treasures.Count)
                    {
                        foreach (var path in newPathList)
                        {
                            newVisited[path.Item1, path.Item2]++;
                        }
                    }
                    else
                    {
                        newVisited = bfs_tuple.visited;
                    }

                    q.Enqueue(new BFS_Tuple(bfs_tuple.path+direction, newPathList, newTreasures, neighbour, newStack, newVisited));
                }

                Debug.WriteLine("");
            }
            sw.Stop();
            return "".ToList();
        }

        private BFS_Tuple pathToStart(BFS_Tuple init_tuple)
        {
            Debug.WriteLine("TSP\n");

            var (init_row, init_col) = init_tuple.position;
            Queue<BFS_Tuple> qb = new Queue<BFS_Tuple>();
            qb.Enqueue(new BFS_Tuple("", new List<Tuple<int,int>>(), new HashSet<Tuple<int,int>>(),init_tuple.position, new Stack<Tuple<Tuple<int,int>, int, char>>(), new int[height,width]));

            while (qb.Count != 0)
            {
                var bfs_tuple = qb.Dequeue();
                lengthNode++;
                var (current_row, current_col) = bfs_tuple.position;
                Debug.WriteLine(String.Format("{0} {1} {2}", bfs_tuple.position, bfs_tuple.path, bfs_tuple.treasures.Count));
                if (bfs_tuple.position.Equals(start))
                {
                    Debug.WriteLine("Return Back");
                    return bfs_tuple;
                }
                if (bfs_tuple.visited[current_row, current_col]>0)
                {
                    continue;
                }
                bfs_tuple.visited[current_row, current_col]++;
                foreach(var node in graph[bfs_tuple.position])
                {
                    var direction = node.Item1;
                    var neighbour = node.Item3;
                    var newPathList = bfs_tuple.path_list.Union(new List<Tuple<int, int>>() { neighbour }).ToList();

                    qb.Enqueue(new BFS_Tuple(bfs_tuple.path+direction, newPathList, bfs_tuple.treasures, neighbour, bfs_tuple.stack, bfs_tuple.visited));
                }
            }
            return new BFS_Tuple("", new List<Tuple<int, int>>(), new HashSet<Tuple<int, int>>(), init_tuple.position, new Stack<Tuple<Tuple<int, int>, int, char>>(), new int[height, width]);
        }

        private char reverseDirection(char direction)
        {
            if (direction == 'D') return 'U';
            if (direction == 'U') return 'D';
            if (direction == 'L') return 'R';
            if (direction == 'R') return 'L';
            return '#';
        }

        private bool allNeighboursVisited(BFS_Tuple bfs_tuple)
        {
            bool found_unvisited = false;
            foreach(var node in graph[bfs_tuple.position])
            {
                var (neighbour_row, neighbour_col)= node.Item3;
                if (bfs_tuple.visited[neighbour_row, neighbour_col] == 0) {
                    found_unvisited = true;
                }
            }
            return !found_unvisited;
        }
    }
    internal class BFS_Tuple{
        public string path;
        public List<Tuple<int, int>> path_list;
        public HashSet<Tuple<int, int>> treasures;
        public Tuple<int, int> position;
        public Stack<Tuple<Tuple<int, int>, int, char>> stack;
        public int[,] visited;

        public BFS_Tuple(string _path, List<Tuple<int,int>> _path_list, HashSet<Tuple<int,int>> _treasures, Tuple<int, int> _position, Stack<Tuple<Tuple<int, int>, int, char>> _stack, int[,] _visited)
        {
            path = _path;
            path_list = _path_list;
            treasures = _treasures;
            position = _position;
            stack = _stack;
            visited = _visited;
        }

    }
}