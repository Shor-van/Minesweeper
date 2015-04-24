using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.GameBoard;

namespace Minesweeper.Screens
{
    public class GameScreen
    {
        private Board gameBoard; //The gane board contains cells

        /// <summary>Initsalize the menu</summary>
        public GameScreen()
        {

        }

        /// <summary>Sets up the game board based on the board settings passed</summary>
        /// <param name="settings">A BoardSettings object spesifing the board settings</param>
        public void SetupGameBoard(BoardSettings settings)
        {
            gameBoard = new Board(settings);
        }

        /// <summary>Checks if the game board has been setup</summary>
        /// <returns>false if the board is not setup else true</returns>
        private bool IsBoardSetup()
        {
            if (gameBoard != null)
                return true;
            return false;
        }

        /// <summary>Updates the game board</summary>
        public void Update()
        {

        }

        /// <summary>Draws the game board</summary>
        public void Draw()
        {

        }
    }
}
