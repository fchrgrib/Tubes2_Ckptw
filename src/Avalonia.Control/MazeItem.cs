using Avalonia.Controls;
using Tubes2_Ckptw.Models;

namespace Tubes2_Ckptw.Utility
{
    public class MazeItem : ListBox
    {
        int width, height;
        public MazeItem(Maze maze)
        {
            this.Items = maze.MazePaths;

            this.width = maze.Width;
            this.height = maze.Height;
        }
    }
}
