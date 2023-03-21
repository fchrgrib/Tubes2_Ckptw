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
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using ReactiveUI;

namespace Tubes2_Ckptw.ViewModels
{
    public class MazeViewModel : ReactiveObject
    {
        private FileReader fileReader;
        public MazeViewModel() {
            fileReader = new FileReader("map1.txt");
            
            updateMazePath();
        }

        private void updateMazePath()
        {
            this.mazeable = new Maze(fileReader.getMapMaze());

            this.mazePaths = new ObservableCollection<MazePath>();
            foreach (var mp in this.mazeable.MazePaths)
            {
                this.mazePaths.Add(mp);
            }
        }

        private ObservableCollection<MazePath>? mazePaths;
        public ObservableCollection<MazePath>? MazePaths
        {
            get => mazePaths;
            set => this.RaiseAndSetIfChanged(ref mazePaths, value);
        }

        private Maze? mazeable;
        public Maze? Mazeable {
            get => mazeable;
            set => this.RaiseAndSetIfChanged(ref mazeable, value);
        }

        public void OnClickCommand()
        {
            fileReader.BrowseFiles();

            updateMazePath();
        }
    }
}
