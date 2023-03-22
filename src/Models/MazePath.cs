﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes2_Ckptw.ViewModels;

namespace Tubes2_Ckptw.Models
{
    public class MazePath
    {
        public enum pathState
        {
            Undefined,

            untravelled,
            travelled,
            backtracked
        }

        public enum pathSymbol
        {
            Undefined,

            KrustyKrab, // K
            Treasure,   // T
            Pathable,   // R
            Unpathable  // X
        }

        public pathState PathState
        {
            get; set;
        }

        public pathSymbol PathSymbol
        {
            get; set;
        }

        public MazePath(pathSymbol _pathSymbol)
        {
            PathState = pathState.untravelled;
            PathSymbol = _pathSymbol;
        }

        public MazePath(char _char)
        {
            PathState = pathState.untravelled;

            switch (_char)
            {
                case 'K':
                    PathSymbol = pathSymbol.KrustyKrab;
                    break;
                case 'T':
                    PathSymbol = pathSymbol.Treasure;
                    break;
                case 'R':
                    PathSymbol = pathSymbol.Pathable;
                    break;
                case 'X':
                    PathSymbol = pathSymbol.Unpathable;
                    break;
                default:
                    PathSymbol = pathSymbol.Undefined;
                    break;
            }
        }

        public override string ToString()
        {
            switch (PathSymbol)
            {
                case pathSymbol.KrustyKrab:
                    return "K";
                case pathSymbol.Treasure:
                    return "T";
                case pathSymbol.Pathable:
                    return "R";
                case pathSymbol.Unpathable:
                    return "X";
                default:
                    return "Undefined";
            }
        }
    }
}