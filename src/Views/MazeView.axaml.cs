using Avalonia;
using Avalonia.Controls;
using System.Diagnostics;
using Avalonia.Layout;

using Tubes2_Ckptw.Models;
using Avalonia.Media;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tubes2_Ckptw.Views
{
    public partial class MazeView : UserControl
    {
        //public static readonly StyledProperty<Maze> UsedMazeProperty =
        //  AvaloniaProperty.Register<MazeView, Maze>(nameof(UsedMazeProperty), defaultValue: new Maze());
        //public Maze UsedMaze
        //{
        //    get { return GetValue(UsedMazeProperty); }
        //    set
        //    {
        //        Debug.WriteLine("binding set!");
        //        SetValue(UsedMazeProperty, value);
        //        OnPropertyChanged();
        //    }
        //}

        public static readonly StyledProperty<MazeProp> MazePropProperty =
            AvaloniaProperty.Register<MazeView, MazeProp>(nameof(MazePropProperty), defaultValue: new MazeProp());
        public MazeProp MazeProp
        {
            get => GetValue(MazePropProperty);
            set
            {
                SetValue(MazePropProperty, value);
                UpdateMazeGrid();
            }
        }

        public MazeView()
        {
            InitializeComponent();
        }

        protected override void OnDataContextEndUpdate()
        {
            UpdateMazeGrid();
            base.OnDataContextEndUpdate();
        }
        
        public void UpdateMazeGrid()
        {
            Debug.Print("Updating!");
            Grid mazeGrid = this.FindControl<Grid>("MazeGrid");
            mazeGrid.Children.Clear();
            
            double maxVertical = 630;
            mazeGrid.Width = mazeGrid.Height = maxVertical;
            //mazeGrid.ShowGridLines = true;

            mazeGrid.HorizontalAlignment = HorizontalAlignment.Center;
            mazeGrid.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < this.MazeProp.Maze.Height; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);

                mazeGrid.RowDefinitions.Add(row);
            }

            for (int j = 0; j < this.MazeProp.Maze.Width; j++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(1, GridUnitType.Star);

                mazeGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < this.MazeProp.Maze.Height; i++)
            {
                for (int j = 0; j < this.MazeProp.Maze.Width; j++)
                {
                    // content definition
                    Button tb = new Button();
                    tb.Content = this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].ToString();

                    tb.Background = this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].PathSymbol != MazePath.pathSymbol.Unpathable ? Brushes.White : Brushes.Black;
                    tb.Foreground = Brushes.Black;

                    tb.Width = mazeGrid.Width / MazeProp.Maze.Width;
                    tb.Height = mazeGrid.Height / MazeProp.Maze.Height;
                    //Debug.WriteLine(i * this.UsedMaze.Width + j + tb.Text);

                    tb.HorizontalContentAlignment = HorizontalAlignment.Center;
                    tb.VerticalContentAlignment = VerticalAlignment.Center;

                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;

                    // not sure why this one is flipped
                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, j);

                    mazeGrid.Children.Add(tb);
                }
            }
        }

        //protected override void OnDataContextEndUpdate()
        //{
            
        //    base.OnDataContextEndUpdate();
        //}
    }

    public class MazeProp: INotifyPropertyChanged
    {
        private Maze maze;
        public Maze Maze
        {
            get => maze;
            set { 
                if(this.maze != value)
                {
                    this.maze = value;
                    this.NotifyPropertyChanged("Maze");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            Debug.WriteLine("ganti si!");
        }
    }
}
