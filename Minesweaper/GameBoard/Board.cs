using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    /// <summary>Preset board sizes, they are square</summary>
    public enum BoardSize
    {
        Small,
        Medium,
        Large,
        Huge
    }
    public class Board
    {
        private Cell[,] cells; //The cells of the board
        private int posX, posY; //The top left location of the board on the screen
        private int selX, selY; //The x and y cell that the player is selecting

        //Gets and sets
        public Cell[,] Cells { get { return cells; } set { cells = value; } }
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }

        /// <summary>Main constructor</summary>
        /// <param name="settings">A BoardSettings object containing information on how to create the board</param>
        public Board(int posX, int posY, BoardSettings settings)
        {
            //Base settings
            this.posX = posX;
            this.posY = posY;
            this.selX = settings.Width / 2;
            this.selY = settings.Height / 2;

            //Cells
            cells = new Cell[settings.Width, settings.Height];
        }

        /// <summary>Overload constructor </summary>
        /// <param name="sizeX">The number of tiles on the x axis</param>
        /// <param name="sizeY">The number of tiles in the y axis</param>
        public Board(int sizeX, int sizeY)
        {

        }

        /// <summary>Gets the x and y location of the cell in the array</summary>
        /// <param name="cell">The cell in belonging to this board</param>
        /// <returns>Array containing the x and y tile location of the cell in the board </returns>
        public int[] GetLocationInArray(Cell cell)
        {
            //Do check if Cell board is this
            //Loop through cells
            //Chech if currrect cell loop is cell
            //return array x y
            return null;
        }

        /// <summary>Updates the board</summary>
        public void Update()
        {

        }

        /// <summary>Checks if the player moved the selection area</summary>
        private void UpdatePlayerInput()
        {

        }

        /// <summary>Draws the game board</summary>
        public void Draw()
        {

        }
    }
}
