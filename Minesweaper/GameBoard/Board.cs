using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    /// <summary>Preset board sizes, they are square</summary>
    public enum BoardSize
    {
        Small = 10,
        Medium = 20,
        Large = 25,
        Huge = 30
    }
    public class Board
    {
        private Cell[,] cells; //The cells of the board
        private int posX, posY; //The top left location of the board on the screen

        //Gets and sets
        public Cell[,] Cells { get { return cells; } set { cells = value; } }
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }

        public Board(BoardSize size)
        {

        }

        public Board(int sizeX, int sizeY)
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
