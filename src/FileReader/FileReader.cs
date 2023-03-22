﻿using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2_Ckptw.src.FileReader
{
    internal class FileReader
    {
        private string nameFile;
        public FileReader(string nameFile) {
            this.nameFile = nameFile;
        }
        public char[,] getMapMaze()
        {

            string mapBefSplit = "";

            try
            {
                mapBefSplit = File.ReadAllText("../../../test/" + this.nameFile);
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
                    try
                    {
                        result[i, j] = temp[j].ToCharArray()[0];
                    }
                    catch (IndexOutOfRangeException e) { }
                }
            }


            return result;
        }
    }
}
