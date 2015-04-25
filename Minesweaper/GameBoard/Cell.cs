using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    public class Cell
    {
        private bool isOpen; //Weather the cell is opened       
        private bool isMine; //Weather the cell has a mine
        private string text; //What is shown in the cell
        private Board owner;  //The board that the cell is a part of
        private int posX, posY; //The location of the cell on the screen

        //Gets and sets
        public bool IsOpen { get { return isOpen; } set { isOpen = value; } }
        public bool IsMine { get { return isMine; } }
        public string Text { get { return text; } set { text = value; } }
        public Board Owner { get { return owner; } }
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }

        /// <summary>Base constructor</summary>
        /// <param name="posX">The x location on the screen of the cell</param>
        /// <param name="posY">The y location on the screen of the cell</param>
        /// <param name="owner">The board that the cell is a part i</param>
        /// <param name="isMine">Weather the cell contains a mine</param>
        public Cell(int posX, int posY, Board owner, bool isMine)
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {
            if (isOpen)
            {

            }
        }
    }
}
