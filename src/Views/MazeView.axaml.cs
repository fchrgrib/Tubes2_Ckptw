using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Diagnostics;
using Tubes2_Ckptw.Models;
using Tubes2_Ckptw.Utility;

namespace Tubes2_Ckptw.Views
{
    public partial class MazeView : TemplatedControl
    {
        public static readonly StyledProperty<Maze> UsedMazeProperty =
           AvaloniaProperty.Register<MazeView, Maze>(nameof(UsedMazeProperty), defaultValue: new Maze());
        public Maze UsedMaze
        {
            get { return GetValue(UsedMazeProperty); }
            set { SetValue(UsedMazeProperty, value); }
        }

        //public MazeView()
        //{
        //    Debug.Print("mazeview created");
        //    UsedMaze.Print();
        //}
    }
}
