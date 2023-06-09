using Avalonia;
using Avalonia.Controls;
using System.Diagnostics;
using Avalonia.Layout;

using Tubes2_Ckptw.Models;
using Avalonia.Media;
using System;
using System.ComponentModel;
using Tubes2_Ckptw.ViewModels;
using Avalonia.Data;
using Avalonia.Data.Converters;
using System.Globalization;
using System.Collections.Generic;

namespace Tubes2_Ckptw.Views
{
    public partial class MazeView : UserControl
    {
        public static readonly StyledProperty<MazeProp> MazePropProperty =
            AvaloniaProperty.Register<MazeView, MazeProp>(nameof(MazePropProperty), defaultValue: new MazeProp());
        public MazeProp MazeProp
        {
            get => GetValue(MazePropProperty);
            set
            {
                SetValue(MazePropProperty, value);
                InitializeMazeGrid();
            }
        }

        public MazeView()
        {
            InitializeComponent();            
        }

        protected override void OnDataContextEndUpdate()
        {
            InitializeMazeGrid();
            base.OnDataContextEndUpdate();

            (DataContext as MazeViewModel).mazeView = this as MazeView;
        }
        
        public void InitializeMazeGrid()
        {
            Grid mazeGrid = this.FindControl<Grid>("MazeGrid");

            mazeGrid.Children.Clear();
            mazeGrid.RowDefinitions.Clear();
            mazeGrid.ColumnDefinitions.Clear();

            double  maxVertical = 630,
                    maxHorizontal = 1150;

            if((DataContext as MazeViewModel).currentScreens != null)
            {
                maxVertical   = ((DataContext as MazeViewModel).currentScreens.Primary.WorkingArea.Height * 7 / 10 - 80) /
                                (DataContext as MazeViewModel).currentScreens.Primary.PixelDensity;
                maxHorizontal = ((DataContext as MazeViewModel).currentScreens.Primary.WorkingArea.Width * 4 / 6.2 - 80)/
                                (DataContext as MazeViewModel).currentScreens.Primary.PixelDensity;
            }

            double  desiredGridHeight = maxVertical / this.MazeProp.Maze.Height,
                    desiredGridWidth = maxHorizontal / this.MazeProp.Maze.Width;

            double desiredGridSize = desiredGridHeight < desiredGridWidth ? 
                desiredGridHeight 
                : 
                desiredGridWidth;

            mazeGrid.Width = desiredGridSize * this.MazeProp.Maze.Width;
            mazeGrid.Height = desiredGridSize * this.MazeProp.Maze.Height;


            mazeGrid.HorizontalAlignment = HorizontalAlignment.Center;
            mazeGrid.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < this.MazeProp.Maze.Height; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(desiredGridSize, GridUnitType.Pixel);

                mazeGrid.RowDefinitions.Add(row);
            }

            for (int j = 0; j < this.MazeProp.Maze.Width; j++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(desiredGridSize, GridUnitType.Pixel);

                mazeGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < this.MazeProp.Maze.Height; i++)
            {
                for (int j = 0; j < this.MazeProp.Maze.Width; j++)
                {
                    int idx = i * MazeProp.Maze.Width + j;

                    // content definition
                    Button tb = new Button();
                    tb.Content = this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j];

                    tb.Background = this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].PathState == MazePath.pathState.Searched
                        || this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].PathState == MazePath.pathState.beingSearched ?
                        this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].PathState == MazePath.pathState.Searched ?
                            new SolidColorBrush(Color.Parse("#8E895C"))
                            :
                            new SolidColorBrush(Color.Parse("#393859"))
                        :
                        this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].PathState == MazePath.pathState.Travelled ?
                            new SolidColorBrush(Color.Parse("#4F734C"))
                            :
                            this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].PathState == MazePath.pathState.Backtracked ?
                                new SolidColorBrush(Color.Parse("#3B5938"))
                                :
                                ( 
                                    this.MazeProp.Maze.MazePaths[i * this.MazeProp.Maze.Width + j].PathSymbol != MazePath.pathSymbol.Unpathable ? 
                                    new SolidColorBrush(Color.Parse("#AEAEAE"))
                                    : 
                                    new SolidColorBrush(Color.Parse("#202020")
                                )
                            )
                        ;
                    tb.Foreground = Brushes.Black;

                    tb.Width = mazeGrid.Width / MazeProp.Maze.Width;
                    tb.Height = mazeGrid.Height / MazeProp.Maze.Height;

                    tb.HorizontalContentAlignment = HorizontalAlignment.Center;
                    tb.VerticalContentAlignment = VerticalAlignment.Center;

                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;

                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, j);

                    mazeGrid.Children.Add(tb);
                }
            }
        }
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
        }
    }

    public class IsSelectingBFSConverter : IValueConverter
    {
        public static readonly IsSelectingBFSConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isBFS && targetType.IsAssignableTo(typeof(string)))
            {
                if (isBFS)
                {
                    return "BFS";
                }
                else
                {
                    return "DFS";
                }
            }

            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // may be implemented later
            throw new NotSupportedException();
        }
    }

    public class SelectedFileNameConverter : IValueConverter
    {
        public static readonly SelectedFileNameConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string filename && targetType.IsAssignableTo(typeof(string)))
            {
                if (string.Compare(filename, string.Empty) == 0)
                {
                    return "No Maze File currently Read.";
                }
                else
                {
                    return filename;
                }
            }

            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // may be implemented later
            throw new NotSupportedException();
        }
    }

    public class TSPConverter : IValueConverter
    {
        public static readonly TSPConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isTSP && targetType.IsAssignableTo(typeof(string)))
            {
                if (isTSP)
                {
                    return "ON";
                }

                return "OFF";
            }

            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // may be implemented later
            throw new NotSupportedException();
        }
    }

    public class PathTraceConverter : IValueConverter
    {
        public static readonly PathTraceConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string result = string.Empty;

            if (value is List<char> dirPaths && targetType.IsAssignableTo(typeof(string)))
            {
                if (dirPaths.Count == 0)
                {
                    result = "Not Yet Solved.";
                }
                else
                {
                    foreach(var path in dirPaths)
                    {
                        result += path + " ";
                    }
                }
            }

            return result;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // may be implemented later
            throw new NotSupportedException();
        }
    }

    public class StepDelayConverter : IValueConverter
    {
        public static readonly StepDelayConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {

            if (value is double stepDelayIn100 && targetType.IsAssignableTo(typeof(string)))
            {
                return ((stepDelayIn100 / 100).ToString("F2") + " s");
            }

            return "NaN";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // may be implemented later
            throw new NotSupportedException();
        }
    }
}
