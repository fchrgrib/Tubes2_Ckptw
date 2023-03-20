using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes2_Ckptw.ViewModels;
using Tubes2_Ckptw.Models;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace Tubes2_Ckptw.ViewModels
{
    public class MazeViewModel : ViewModelBase
    {
        private Maze maze;
        public MazeViewModel(Maze _maze) {
            this.maze = _maze;

            updateMazePath();
        }

        private void updateMazePath()
        {
            foreach (var mp in maze.MazePaths)
            {
                this.MazePaths.Add(mp);
            }
        }

        public ObservableCollection<MazePath> MazePaths
        {
            get;
        } = new ObservableCollection<MazePath>();

    }
}
