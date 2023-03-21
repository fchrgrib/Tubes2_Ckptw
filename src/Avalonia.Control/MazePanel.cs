using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using Tubes2_Ckptw.Models;
using Tubes2_Ckptw.Views;

namespace Tubes2_Ckptw.Utility
{
    public class MazePanel : WrapPanel
    {
        public static readonly StyledProperty<int> WedthProperty =
            AvaloniaProperty.Register<MazePanel, int>(nameof(WedthProperty), 0);
        public int Wedth { get => GetValue(WedthProperty);
            set => SetValue(WedthProperty, value); }

        public static readonly StyledProperty<Maze> MappedMazeProperty =
           AvaloniaProperty.Register<MazePanel, Maze>(nameof(MappedMazeProperty), defaultValue: new Maze());
        public Maze MappedMaze
        {
            get { return GetValue(MappedMazeProperty); }
            set {
                SetValue(MappedMazeProperty, value);
            }
        }

        public MazePanel()
        {
            Debug.Print("Maze Panel created");
        }


        private void updateChildren()
        {
            foreach (var item in this.MappedMaze.MazePaths)
            {
                //Debug.Print("tes!");
                TextBlock textB = new TextBlock();
                textB.Text = item.PathSymbol.ToString();
                this.Children.Add(textB);
            }

            Debug.WriteLine(this.Children.Count);
        }

        protected override Size MeasureOverride(Size constraint)
        {


            

            //int desiredSize = (int)(constraint.Width / this.Wedth);

            //Debug.WriteLine(constraint + " - " + this.MappedMaze.Width + " -- " + this.Wedth + " --- " + desiredSize);
            ////Debug.WriteLine(base.MeasureOverride(constraint));
            
            //for(int i = 0; i < Children.Count; i++)
            //{
            //    Children[i].Measure(new Size(desiredSize, desiredSize));
            //}

            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            //Debug.Print("tesa! ->" + this.MappedMaze.MazePaths.Length + "}");


            ////item.Arrange(new Rect(new Point(50, 50), item.DesiredSize));
            ////}
            //Debug.Write(finalSize);
            //return finalSize;
            Size k = base.ArrangeOverride(finalSize);
            Debug.Write(k);

            return k;
        }
    }
}
