using Avalonia;
using Avalonia.Controls;
using System.Diagnostics;
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

        private ListBox listBox;

        public MazeView()
        {
            InitializeComponent();
        }

        protected override void OnDataContextEndUpdate()
        {
            listBox = this.FindControl<ListBox>("ListBox");

            //int desiredViewportSize;
            //if (!double.IsNaN(this.Width))
            //{
            //     desiredViewportSize = this.Width < this.Height ? (int)this.Width : (int)this.Height;
            //} else
            //{
            //    desiredViewportSize = window
            //}
            

            Debug.WriteLine("wr" + Window.wi);

            int maxAxisVal = this.UsedMaze.Width > this.UsedMaze.Height ? this.UsedMaze.Width : this.UsedMaze.Height;

            //foreach(var item in listBox.Styles)
            //{
            //    foreach(var style in item.Children)
            //    {
            //        Debug.WriteLine(style.ToString());
            //    }
            //}
            Debug.Write(desiredViewportSize + "this");
            listBox.Width = listBox.Height = desiredViewportSize;

            base.OnDataContextEndUpdate();
        }
    }
}
