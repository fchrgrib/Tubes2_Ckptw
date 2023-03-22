﻿using System;
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
using Tubes2_Ckptw.Algorithm;
using ReactiveUI;


namespace Tubes2_Ckptw.ViewModels
{
    public class MazeViewModel : ReactiveObject
    {
        private FileReader fileReader;
        private BFS bfs;

        public MazeView mazeView;

        public MazeViewModel() {
            fileReader = new FileReader("map1.txt");
            this.MazeableProp = new MazeProp();
            //bfs = new BFS();

            //bfs.solve();
            
            updateMazePath();
        }

        private void updateMazePath()
        {
            this.Mazeable = new Maze(fileReader.getMapMaze());
            //this.Mazeable.Print();

            this.MazeableProp.Maze = this.Mazeable;

            this.MazePaths = new ObservableCollection<MazePath>();
            foreach (var mp in this.Mazeable.MazePaths)
            {
                this.MazePaths.Add(mp);
            }

            this.Filename = fileReader.getNameFile;

            if(mazeView != null)
                mazeView.InitializeMazeGrid();

            //Debug.WriteLine(this.Mazeable.Width + " x " + this.Mazeable.Height);
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

        private MazeProp? mazeableProp;
        public MazeProp? MazeableProp
        {
            get => mazeableProp;
            set => this.RaiseAndSetIfChanged(ref mazeableProp, value);
        }

        private bool isSelectingBFS = true;
        public bool IsSelectingBFS
        {
            get => isSelectingBFS;
            set => this.RaiseAndSetIfChanged(ref isSelectingBFS, value);
        }

        public async void OnClickCommand()
        {
            await fileReader.BrowseFiles();

            updateMazePath();
        }
    }
}
