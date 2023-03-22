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
using Tubes2_Ckptw.Views;
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
            this.Mazeable = new Maze(fileReader.getMapMaze());
            this.Mazeable.Print();
            this.MazePaths = new ObservableCollection<MazePath>();
            foreach (var mp in this.Mazeable.MazePaths)
            {
                this.MazePaths.Add(mp);
            }

            this.Filename = fileReader.getNameFile;

        }

        private ObservableCollection<MazePath>? mazePaths;
        public ObservableCollection<MazePath>? MazePaths
        {
            get => mazePaths;
            set => this.RaiseAndSetIfChanged(ref mazePaths, value);
        }

        private string filename;
        public string Filename
        {
            get => filename;
            set => this.RaiseAndSetIfChanged(ref filename, value);
        }

        private Maze? mazeable;
        public Maze? Mazeable {
            get => mazeable;
            set => this.RaiseAndSetIfChanged(ref mazeable, value);
        }

        private bool isSelectingBFS = true;
        public bool IsSelectingBFS
        {
            get => isSelectingBFS;
            set => this.RaiseAndSetIfChanged(ref isSelectingBFS, value);
        }

        public void OnClickCommand()
        {
            fileReader.BrowseFiles();

            updateMazePath();
        }
    }
}
