using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    /// <summary>Preset board sizes</summary>
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
        private int sizeX, sizeY; //The menrer of cells on the x and y axis that the board has
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

            for (int x = 0; x < settings.Width; x++)
            {
                for (int y = 0; y < settings.Height; y++)
                {
                    
                }
            }
        }

        /// <summary>Opens the cell at the x and y location, if cell has no mines near it connected cells are opened</summary>
        /// <param name="x">The x location of the cell in the array</param>
        /// <param name="y">The y location of the cell in the array</param>
        public void OpenCell(int x, int y)
        {
            cells[x, y].IsOpen = true;

            //Ceck if is not mine
            if (cells[x, y].IsMine != true)
            {
                //Get number of mines around
                int mines = GetNumberOfMinesAround(x, y);
                
                //if no mines near open connected cells
                if (mines == 0)
                {
                    cells[x, y].Text = " ";
                    OpenCell(x, y - 1);
                    OpenCell(x - 1, y);
                    OpenCell(x, y + 1);
                    OpenCell(x + 1, y);
                }
                else
                {
                    cells[x, y].Text = mines.ToString();
                }
            }
            else
            {
                //BOOM
                ShowMines();
            }
        }

        /// <summary> Gets the number of mines around the cell</summary>
        /// <param name="x">The X location of the cell in the array</param>
        /// <param name="y">The Y location of thecell in the array</param>
        /// <returns>The number of mines aroun the cell</returns>
        public int GetNumberOfMinesAround(int x, int y)
        {
            int mines = 0;
            if (cells[x - 1, y - 1].IsMine == true)
                mines++;
            if (cells[x, y - 1].IsMine == true)
                mines++;
            if (cells[x + 1, y - 1].IsMine == true)
                mines++;
            if (cells[x + 1, y].IsMine == true)
                mines++;
            if (cells[x + 1, y + 1].IsMine == true)
                mines++;
            if (cells[x, y + 1].IsMine == true)
                mines++;
            if (cells[x - 1, y + 1].IsMine == true)
                mines++;
            if (cells[x - 1, y].IsMine == true)
                mines++;
            return mines;
        }

        /// <summary>Gets the number of mines on the board</summary>
        /// <returns>The number of mines on the board</returns>
        public int GetNumberOfMines()
        {
            int mines = 0;
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (cells[x, y].IsMine == true)
                        mines++;
                }
            }
            return mines;
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

        /// <summary>Shows all the cells that are mines</summary>
        public void ShowMines()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (cells[x, y].IsMine == true)
                        cells[x, y].Text = "M";
                }
            }
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
