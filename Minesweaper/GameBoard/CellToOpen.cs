using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    /// <summary>Object that holds information about a cell that is scheduled to be opened</summary>
    public class CellToOpen
    {
        private Cell cell; //The cell to open
        private int tileX, tileY; //The x and y location of the cell in the array

        //Gets and sets
        public int TileX { get { return tileX; } }
        public int TileY { get { return tileY; } }

        /// <summary>Base constructor</summary>
        /// <param name="cell">The cell that is to be opened</param>
        /// <param name="tileX">The cells x location in the array</param>
        /// <param name="tileY">The cells y location in the array</param>
        public CellToOpen(Cell cell, int tileX, int tileY)
        {
            this.cell = cell;
            this.tileX = tileX;
            this.tileY = tileY;
        }

        /// <summary>Checks if the cell is this cell</summary>
        /// <param name="x">The x location of the cell in the array</param>
        /// <param name="y">The y location of the cell in the array</param>
        /// <returns>True if the cell is this cell else false</returns>
        public bool IsCell(int x, int y)
        {
            if (tileX == x && tileY == y)
                return true;
            return false;
        }

        /// <summary>Checks if the cell is this cell</summary>
        /// <param name="cell">The cell to check</param>
        /// <returns>True if the cell is this cell, else false</returns>
        public bool IsCell(Cell cell)
        {
            if (this.cell.Equals(cell))
                return true;
            return false;
        }
    }
}
