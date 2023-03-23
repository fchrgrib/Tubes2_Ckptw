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
        public string getNameFile => nameFile;
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
            string mapBefSplit = "";

            if(string.Compare(this.nameFile, string.Empty) == 0)
            {
                return new char[0,0];
            }

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
            char[,] result = new char[splitFirst[0].Split(" ").Length, splitFirst.Length];

            for (int j = 0; j < splitFirst.Length; j++)
            {
                string[] temp = splitFirst[j].Split(" ");
                for (int i = 0; i < temp.Length; i++)
                {
                    try
                    {
                        result[i, j] = temp[i].ToCharArray()[0];
                    }
                    catch (IndexOutOfRangeException e) { }
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

            if(result == null)
            {
                return string.Empty;
            }

            return string.Join(" ", result);
        }

        public async Task<bool> BrowseFiles()
        {
            Task<string> result = _getPath();
            string res = await result;

            this.nameFile = string.Compare(res, string.Empty) != 0 ? Path.GetFileName(res) : this.nameFile;

            return true;
        }
    }
}
