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
        private DFS dfs;

        public MazeView mazeView;
        public Screens currentScreens;

        private bool hadSolved = false;
        private bool lastSolveBFS = false;

        public MazeViewModel() {
            fileReader = new FileReader();

            this.MazeableProp = new MazeProp();
            this.SolutionStepDelay = 10;

            updateMazePath();
        }

        private void updateMazePath()
        {
            this.Mazeable = new Maze(fileReader.getMapMaze());
            this.bfs = new BFS(fileReader.getMapMaze());
            this.dfs = new DFS(fileReader.getMapMaze());


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


        // used as binding variable
        private bool isSelectingBFS = true;
        public bool IsSelectingBFS
        {
            get => isSelectingBFS;
            set => this.RaiseAndSetIfChanged(ref isSelectingBFS, value);
        }

        private bool isUsingTSP = false;
        public bool IsUsingTSP
        {
            get => isUsingTSP;
            set => this.RaiseAndSetIfChanged(ref isUsingTSP, value);
        }

        private List<char> solutionPath;
        public List<char> SolutionPath
        {
            get => solutionPath;
            set => this.RaiseAndSetIfChanged(ref solutionPath, value);
        }

        private int solutionSteps;
        public int SolutionSteps
        {
            get => solutionSteps;
            set => this.RaiseAndSetIfChanged(ref solutionSteps, value);
        }

        private int solutionNode;
        public int SolutionNode
        {
            get => solutionNode;
            set => this.RaiseAndSetIfChanged(ref solutionNode, value);
        }

        private string solutionTimeExec;
        public string SolutionTimeExec
        {
            get => solutionTimeExec;
            set => this.RaiseAndSetIfChanged(ref solutionTimeExec, value);
        }

        private double solutionStepDelay;
        public double SolutionStepDelay
        {
            get => solutionStepDelay;
            set => this.RaiseAndSetIfChanged(ref solutionStepDelay, value);
        }

        public async void OnClickCommand()
        {
            if(this.Mazeable != null)
                this.Mazeable.ResetSolutionState();

            await fileReader.BrowseFiles();

            updateMazePath();

            this.hadSolved = false;
        }

        public void UpdateMazePathState()
        {
            if (this.Mazeable == null || this.Mazeable.Width == 0 || this.Mazeable.Height == 0)
                return;

            if (this.hadSolved && this.lastSolveBFS != this.IsSelectingBFS)
                this.hadSolved = false;

            if (!hadSolved)
            {
                if (isUsingTSP)
                {
                    if (isSelectingBFS)
                    {
                        //this.SolutionPath = this.bfs.sol
                    }
                    else
                    {
                        this.SolutionPath = this.dfs.getMovementTSP();
                    }
                }
                else
                {
                    if (isSelectingBFS)
                    {
                        this.SolutionPath = this.bfs.solve();
                    }
                    else
                    {
                        this.SolutionPath = this.dfs.getMovementTreasure();
                        this.SolutionSteps = this.dfs.getStep();
                        this.SolutionNode =  this.dfs.getNode();
                        this.SolutionTimeExec = this.dfs.getTimeExec();
                    }
                }
            }
            

            this.Mazeable.ResetSolutionState();
            this.Mazeable.UpdateSolutionState(this.SolutionPath);

            if (mazeView != null)
                mazeView.InitializeMazeGrid();

            this.hadSolved = true;
        }
    }
}
