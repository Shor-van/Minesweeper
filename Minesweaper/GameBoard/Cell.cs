using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    public enum CellType
    {
        Closed,
        Empty,
        Mine,
        Flag,
        Question,
        Number,
    }
    public class Cell
    {
        private CellType type; //The type that the cell is
        private Board owner;  //The board that the cell is a part of
        private int posX, posY; //The location of the cell on the screen

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
