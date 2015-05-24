using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.GameBoard
{
    public class Cell
    {
        //Static members
        private static ConsoleColor openColor = ConsoleColor.DarkCyan; //The backcolor used to draw open cells
        private static ConsoleColor closedColor = ConsoleColor.Cyan; //The backcolor used to draw closed cells

        private bool isOpen; //Weather the cell is opened       
        private bool isMine; //Weather the cell has a mine
        private string text; //What is shown in the cell
        private Board owner;  //The board that the cell is a part of
        private int posX, posY; //The location of the cell on the screen

        //Gets and sets
        public bool IsOpen { get { return isOpen; } set { isOpen = value; } }
        public bool IsMine { get { return isMine; } set { isMine = value; } }
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
            this.posX = posX;
            this.posY = posY;
            this.owner = owner;
            this.isMine = isMine;
            this.text = "_";
        }

        /// <summary>Oppens this cell, if no mine is near connected cells are opened</summary>
        public void OpenCell()
        {

        }

        //Loop
        public void Update() { }

        /// <summary>Draws the cell</summary>
        public void Draw(bool selected = false)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (isOpen)
            {
                if (selected)
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                else
                    Console.BackgroundColor = openColor;

                Console.SetCursorPosition(posX, posY);
                Console.Write("| |");

                if (text != "_" && text != "M" && text != "F" && text != "?")
                    Console.ForegroundColor = ConsoleColor.Green;

                if (text == "M")
                    Console.ForegroundColor = ConsoleColor.Red;

                if (text == "F")
                    Console.ForegroundColor = ConsoleColor.Blue;

                if (text == "?")
                    Console.ForegroundColor = ConsoleColor.Magenta;

                Console.SetCursorPosition(posX + 1, posY);
                Console.Write(text);
            }
            else 
            {
                if (selected)
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                else
                    Console.BackgroundColor = closedColor;
                
                Console.SetCursorPosition(posX, posY);
                Console.Write("| |");

                if (text != "_" && text != "M" && text != "F" && text != "?")
                    Console.ForegroundColor = ConsoleColor.Green;

                if (text == "M")
                    Console.ForegroundColor = ConsoleColor.Red;

                if (text == "F")
                    Console.ForegroundColor = ConsoleColor.Blue;

                if (text == "?")
                    Console.ForegroundColor = ConsoleColor.Magenta;

                Console.SetCursorPosition(posX + 1, posY);
                Console.Write(text);
            }

            Program.backgroundColor = ConsoleColor.Black;
            Console.ResetColor();
        }
    }
}
