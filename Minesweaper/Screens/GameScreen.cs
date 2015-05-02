using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.GameBoard;
using Minesweeper.Screens.UI;

namespace Minesweeper.Screens
{
    public class GameScreen
    {
        private Board gameBoard; //The gane board contains cells
        private InfoPenel penel; //Info penel showing amount of time passed, and number of mines to find

        /// <summary>Initsalize the menu</summary>
        public GameScreen()
        {

        }

        /// <summary>Sets up the game board based on the board settings passed</summary>
        /// <param name="settings">A BoardSettings object spesifing the board settings</param>
        public void SetupGameBoard(BoardSettings settings)
        {
            gameBoard = new Board(0, 3, settings);
            penel = new InfoPenel((Program.ViewWidth() / 2) - (35 / 2), 0, 35, 3, ConsoleColor.White, ConsoleColor.DarkBlue);
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
            if (Program.switchingScreen)
            {
                penel.OneTimeDraw();
                gameBoard.Draw();
            }

            Program.switchingScreen = false;
            penel.Update(gameBoard);
            gameBoard.Update();
        }

        /// <summary>Draws the game board</summary>
        public void Draw()
        {
            penel.Draw();
        }
    }
}
