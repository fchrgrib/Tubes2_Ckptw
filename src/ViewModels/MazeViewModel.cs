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
        public MazeViewModel() {
            FileReader fileReader = new FileReader("map1.txt");
            this.Mazeable = new Maze(fileReader.getMapMaze());
            
            //this.Mazeable.Print();
          
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
