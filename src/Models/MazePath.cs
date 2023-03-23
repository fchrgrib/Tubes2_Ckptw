using System;
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

            Untravelled,
            Travelled,
            Backtracked
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
            PathState = pathState.Untravelled;
            PathSymbol = _pathSymbol;
        }

        public MazePath(char _char)
        {
            PathState = pathState.Untravelled;

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
                    return "Start";
                case pathSymbol.Treasure:
                    return "Treasure";
                case pathSymbol.Pathable:
                    return "";
                case pathSymbol.Unpathable:
                    return "";
                default:
                    return "Undefined";
            }
        }
    }
}
