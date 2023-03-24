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
        public string getNameFile => 
            string.Compare(nameFile, string.Empty) != 0 ?  
                Path.GetFullPath(nameFile) 
                : 
                nameFile;

        private string testFolderPath;

        public FileReader()
        {
            nameFile = "";


            if (Directory.Exists("../../../test/")){
                testFolderPath = Path.GetFullPath("../../../test/");
            } else
            {
                testFolderPath = Path.GetFullPath("./");
            }

        }
        public FileReader(string nameFile)
        {
            this.nameFile = nameFile;

            if (Directory.Exists("../../../test/")){
                testFolderPath = Path.GetFullPath("../../../test/");
            }
            else
            {
                testFolderPath = Path.GetFullPath("./");
            }
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
                mapBefSplit = File.ReadAllText(Path.Combine(testFolderPath, this.nameFile));
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine(e.Message);
            }

            string[] splitFirst = mapBefSplit.Split('\n');
            char[,] result = new char[splitFirst.Length, splitFirst[0].Split(" ").Length];

            for (int j = 0; j < splitFirst.Length; j++)
            {
                string[] temp = splitFirst[j].Split(" ");
                for (int i = 0; i < temp.Length; i++)
                {
                    try
                    {
                        result[j, i] = temp[i].ToCharArray()[0];
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
            fileDialog.Directory = testFolderPath;
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
            this.testFolderPath = string.Compare(res, string.Empty) != 0 ? Path.GetDirectoryName(res) : this.testFolderPath;

            return true;
        }
    }
}
