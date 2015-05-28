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
        private int gameOverWaitTime = 1000; //The amount of time the game should wait before changeing to the game over screen in ms

        private Board gameBoard; //The gane board contains cells
        private InfoPanel panel; //Info panel showing amount of time passed, and number of mines to find
        private ControlPanel ctrlPanel; //Panel showing the controls
        private MultiColoredTextLabel lblcont; //Text the shows how to move and play

        private float elepsedTime; //The amount of time that has elepsed
        private int second; //The amount of secconds that have passed
        private int minute; //The amount of minutes that have passed

        //Gest and sets
        public int Seconds { get { return second; } }
        public int Minutes { get { return minute; } }
        public Board GameBoard { get { return gameBoard; } }

        /// <summary>Initsalize the screen</summary>
        public GameScreen()
        {
            lblcont = new MultiColoredTextLabel("UP: &3W&r, Dowm: &3S&r, Left: &3A&r, Right: &3D&r       Mark: &3E&r, Open: &3Enter", 0, 0, ConsoleColor.Cyan);
        }

        /// <summary>Sets up the game board based on the board settings passed</summary>
        /// <param name="settings">A BoardSettings object spesifing the board settings</param>
        public void SetupGameBoard(BoardSettings settings)
        {
            gameBoard = new Board((Program.ViewWidth() / 2) -  ((settings.Width * 3) / 2), (Program.ViewHieght() / 2) - (settings.Height / 2), settings);
            panel = new InfoPanel((Program.ViewWidth() / 2) - (35 / 2), 0, 35, 3, ConsoleColor.White, ConsoleColor.DarkBlue);
            minute = 0;
            second = 0;

            RecalculatePostions();
        }

        /// <summary>Recalculates all the positions of the UI objects</summary>
        public void RecalculatePostions()
        {
            lblcont.PositionX = (Program.ViewWidth() / 2) - (lblcont.MeasureSize()[0] / 2);
            lblcont.PositionY = (Program.ViewHieght() - 1);
        }

        /// <summary>Checks if the game board has been setup</summary>
        /// <returns>false if the board is not setup else true</returns>
        private bool IsBoardSetup()
        {
            if (gameBoard != null)
                return true;
            return false;
        }

        /// <summary>Calculates the amount of time passed</summary>
        private void CalculateTime()
        {
            elepsedTime += Program.lastLoopTime;
            if (elepsedTime >= 1000.0f)
            {
                second++;
                if (second >= 60)
                {
                    minute++;

                    if (second > 60)
                        second = second - 60;
                    else
                        second = 0;
                }
                elepsedTime = 0f;
            }
        }

        /// <summary>Updates the game screen</summary>
        public void Update()
        {
            if (Program.switchingScreen)
            {
                RecalculatePostions();
                panel.OneTimeDraw();
                gameBoard.Draw();
                lblcont.Draw();
            }

            Program.switchingScreen = false;
            
            CalculateTime();
            panel.Update(gameBoard, minute, second);
            gameBoard.Update();

            //if lost
            if (gameBoard.MineTriggered == true)
            {
                gameBoard.ShowMines();
                Program.gameWon = false;
                Program.gameState = GameState.GameOverState;
                Program.SetupGameOverScreen(minute, second);
                System.Threading.Thread.Sleep(gameOverWaitTime);
                return;
            }

            //if won
            if (gameBoard.IsClosedCellsMines() == true)
            {
                //Show game over screen -> winn game
                gameBoard.ShowMines();
                Program.gameWon = true;
                Program.gameState = GameState.GameOverState;
                Program.SetupGameOverScreen(minute, second);
                System.Threading.Thread.Sleep(gameOverWaitTime);
                return;
            }
        }

        /// <summary>Draws the game screen</summary>
        public void Draw()
        {
            panel.Draw();
        }
    }
}
