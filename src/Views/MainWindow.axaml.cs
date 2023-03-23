using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Diagnostics;
using System.Globalization;
using Tubes2_Ckptw.ViewModels;

namespace Tubes2_Ckptw.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //(DataContext as MazeViewModel).currentScreens = Screens;
        }

        protected override void OnDataContextEndUpdate()
        {
            base.OnDataContextEndUpdate();

            // Feeding Maze View with Current Screens
            (this.FindControl<MazeView>("_MazeView").DataContext as MazeViewModel).currentScreens = Screens;

            // Setting Maze Container to have appropriate size
            this.FindControl<Panel>("_MazeContainer").Width = (Screens.Primary.WorkingArea.Width * 4 / 6.2 - 80) / (Screens.Primary.PixelDensity);
            this.FindControl<Panel>("_MazeContainer").Height = (Screens.Primary.WorkingArea.Height * 7 / 10 - 80) / (Screens.Primary.PixelDensity);


        }
    }
}