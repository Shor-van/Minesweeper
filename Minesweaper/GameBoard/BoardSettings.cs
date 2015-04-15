﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    public class BoardSettings
    {
        private int width; //The max nuber of cells on the x line
        private int height; //The max number of cells on the y line
        private int maxMines; //The max amount of mines the board can have
        private int minMines; //The minimu amount of mines the board can have

        //gets and sets
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int MaxMines { get { return maxMines; } }
        public int MinMines { get { return minMines; } }

        /// <summary>Creates a object that is used to create a new board</summary>
        /// <param name="width">The number of tiles on the x axis</param>
        /// <param name="height">The number of tiles on the Y axis</param>
        /// <param name="minMines">The minimu number of mines that the board can have</param>
        /// <param name="maxMines">The maximu nubber of mine that the board can have</param>
        public BoardSettings(int width , int height, int minMines, int maxMines)
        {
            this.width = width;
            this.height = height;
            this.minMines = minMines;
            this.maxMines = maxMines;
        }

        /// <summary>
        /// Creats board settings based on the spesified size
        /// </summary>
        /// <param name="size">The pre-defined size of the board</param>
        /// <returns>A BoardSettings object based on the pre-defined size of the board</returns>
        public static BoardSettings GetPresetData(BoardSize size)
        {
            switch (size)
            {
                case BoardSize.Small:
                    break;
                case BoardSize.Medium:
                    break;
                case BoardSize.Large:
                    break;
                case BoardSize.Huge:
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}