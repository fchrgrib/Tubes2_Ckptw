using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes2_Ckptw.ViewModels;
using Tubes2_Ckptw.Models;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Tubes2_Ckptw.Utility;
using System.Diagnostics;

namespace Tubes2_Ckptw.ViewModels
{
    public class MazeViewModel : ViewModelBase
    {
        public int WindowWidth { get => 1600; }
        public int WindowHeight { get => 900; }

        public int MazeWidth { get => minBy * Mazeable.Width; }
        public int MazeHeight { get => minBy * Mazeable.Height; }

        public int MazePathWidth;
        public int MazePathHeight;
        

        private int PathWidth { get; set; }
        private int PathHeight { get; set; }


        public int minBy { get; set; }
        public MazeViewModel() {
            FileReader fileReader = new FileReader("map1.txt");
            this.Mazeable = new Maze(fileReader.getMapMaze());

            this.PathWidth = this.WindowWidth / this.Mazeable.Width;
            this.PathHeight = this.WindowHeight / this.Mazeable.Height;

            this.minBy = this.PathHeight < this.PathWidth ? this.PathHeight : this.PathWidth;

            MazePathWidth = MazePathHeight = minBy;

            //MazeWidth = minBy * Mazeable.Width;
            //MazeHeight = minBy * Mazeable.Height;

            //Debug.WriteLine(this.PathHeight + "<<<" + this.PathWidth);
            Debug.WriteLine(MazePathHeight + "-" + MazePathWidth + "-" + MazeHeight +"-"+ MazeWidth);

            this.Mazeable.Print();
          
            updateMazePath();
        }

        private void updateMazePath()
        {
            this.MazePaths.Clear();
            foreach (var mp in Mazeable.MazePaths)
            {
                this.MazePaths.Add(mp);
                //Debug.Print("updating " + MazePaths.Count); //works as intended
            }
        }

        public ObservableCollection<MazePath> MazePaths
        {
            get;
        } = new ObservableCollection<MazePath>();

        public Maze Mazeable { get; } = new Maze();
    }
}
