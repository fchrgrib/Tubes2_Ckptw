using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes2_Ckptw.ViewModels;
using Tubes2_Ckptw.Models;

namespace Tubes2_Ckptw.ViewModels
{
    public class MazeViewModel : ViewModelBase
    {
        private Maze maze;
        public MazeViewModel(Maze _maze) {
            this.maze = _maze;
        }


    }
}
