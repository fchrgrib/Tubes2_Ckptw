using Avalonia;
using Avalonia.Controls;
using System.Diagnostics;
using Avalonia.Layout;

using Tubes2_Ckptw.Models;

namespace Tubes2_Ckptw.Views
{
    public partial class MazeView : UserControl
    {
        public static readonly StyledProperty<Maze> UsedMazeProperty =
          AvaloniaProperty.Register<MazeView, Maze>(nameof(UsedMazeProperty), defaultValue: new Maze());
        public Maze UsedMaze
        {
            get { return GetValue(UsedMazeProperty); }
            set { SetValue(UsedMazeProperty, value); }
        }

        public MazeView()
        {
            InitializeComponent();
        }

        protected override void OnDataContextEndUpdate()
        {
            Grid mazeGrid = this.FindControl<Grid>("MazeGrid");

            mazeGrid.Width = mazeGrid.Height = 900;
            //mazeGrid.ShowGridLines = true;

            mazeGrid.HorizontalAlignment = HorizontalAlignment.Center;
            mazeGrid.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < this.UsedMaze.Height; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);

                mazeGrid.RowDefinitions.Add(row);
            }

            for (int j = 0; j < this.UsedMaze.Width; j++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(1, GridUnitType.Star);

                mazeGrid.ColumnDefinitions.Add(col);
            }

            for(int i = 0; i < this.UsedMaze.Height; i++)
            {
                for(int j=0; j <this.UsedMaze.Width; j++)
                {
                    // content definition
                    Button tb = new Button();
                    tb.Content = this.UsedMaze.MazePaths[i * this.UsedMaze.Width + j].ToString();
                    tb.Width = mazeGrid.Width / UsedMaze.Width;
                    tb.Height = mazeGrid.Height / UsedMaze.Height;
                    //Debug.WriteLine(i * this.UsedMaze.Width + j + tb.Text);

                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;

                    // not sure why this one is flipped
                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, j);

                    mazeGrid.Children.Add(tb);
                }
            }

            base.OnDataContextEndUpdate();
        }
    }
}
