using System.Diagnostics;

namespace Tubes2_Ckptw.src
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// To customize application configuration such as set high DPI settings or default font,
            //// see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            FileReader fileReader = new FileReader("map1.txt");

            char[,] map = fileReader.getMapMaze();

            Maze maze = new Maze(map);

            maze.Print();


        }
    }
}