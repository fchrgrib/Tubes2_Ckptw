using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_Ckptw.Utility
{
    internal class FileReader
    {
        private string nameFile;
        public FileReader()
        {
            nameFile = "";
        }
        public FileReader(string nameFile)
        {
            this.nameFile = nameFile;
        }

        public char[,] getMapMaze()
        {
            Debug.Write(nameFile + "<");
            string mapBefSplit = "";

            try
            {
                // TODO: make this empty
                mapBefSplit = File.ReadAllText( "../../../test/" + this.nameFile);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine(e.Message);
            }

            string[] splitFirst = mapBefSplit.Split('\n');
            char[,] result = new char[splitFirst.Length, splitFirst[0].Split(" ").Length];

            for (int i = 0; i < splitFirst.Length; i++)
            {
                string[] temp = splitFirst[i].Split(" ");
                for (int j = 0; j < temp.Length; j++)
                {
                    result[i, j] = temp[j].ToCharArray()[0];
                }
            }


            return result;
        }

        private async Task<string> _getPath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.AllowMultiple = false;
            fileDialog.Title = "Buka Maze";
            fileDialog.Directory = Path.GetFullPath("../../../test");
            fileDialog.Filters.Add(new FileDialogFilter() { Extensions = { "txt" } });

            string[]? result = await fileDialog.ShowAsync(new Window());

            //while(result == null)
            //{
            //    //result = await fileDialog.ShowAsync(window);
            //}

            return string.Join(" ", result);
        }

        public async void BrowseFiles()
        {
            Task<string> result = _getPath();
            this.nameFile = Path.GetFileName(await result);

        }
    }
}
