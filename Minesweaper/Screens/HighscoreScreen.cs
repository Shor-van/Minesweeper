using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Utils;
using Minesweeper.Screens.UI;

namespace Minesweeper.Screens
{
    public class HighscoreScreen
    {
        private Highscore[] highscores; //The array of the highscores
        private MultiColoredTextLabel[] lblHighscores; //A array of multicolored text label used to show the highscores
        private TitleText title; //The title text "HIGHSCORES"
        private TextLabel lblCont; //TextLabel saying to press any key to cloes the game

        /// <summary>Base constructors</summary>
        public HighscoreScreen()
        {
            highscores = new Highscore[10];
            lblHighscores = new MultiColoredTextLabel[10];

            title = new TitleText("HIGHSCORES", ConsoleColor.Red, 0, 0);
            lblCont = new TextLabel("Press any key to close the game.", 0, 0, ConsoleColor.Cyan);

            RecalculatePositions();
        }

        /// <summary>Recalulates the positions of the UI objects </summary>
        public void RecalculatePositions()
        {
            //Title
            title.PositionX = (Program.ViewWidth() / 2) - (title.MeasureSize()[0] / 2);
            title.PositionY = 2;

            //Labels
            lblCont.PositionX = (Program.ViewWidth() / 2) - (lblCont.MeasureSize()[0] / 2);
            lblCont.PositionY = (Program.ViewHieght() - 3);

            //Highscore List
            for (int i = 0; i < lblHighscores.Length; i++)
            {
                if (lblHighscores[i] != null)
                {
                    lblHighscores[i].PositionX = 3;
                    lblHighscores[i].PositionY = (title.PositionY + (title.MeasureSize()[1])) + 2;
                }
                else
                    break;
            }
        }

        /// <summary>Sets up the screen, builds the highscore list form the array of high scores</summary>
        public void SetupScreen()
        {
            for (int i = 0; i < highscores.Length; i++)
            {
                if (highscores[i] != null)
                {
                    string posColorCode; //Color code that is used for the position number Yellow, White, Red?, gray?
                    switch (i)
                    {
                        case 0:
                            posColorCode = "&5";
                            break;
                        case 1:
                            posColorCode = "&1";
                            break;
                        case 2:
                            posColorCode = "&2";
                            break;
                        default:
                            posColorCode = "&8";
                            break;
                    }

                    lblHighscores[i] = new MultiColoredTextLabel(posColorCode + (i + 1).ToString() + " &7" + highscores[i].PlayerName + "&r " + "TIME: &3" + highscores[i].GetFormatedTime(), 5, 5 + i, ConsoleColor.Cyan);
                }
                else
                    break;
            }
        }

        /// <summary>Adds a new High score to the list</summary>
        /// <param name="playerName">The name that the player entered</param>
        /// <param name="minutes">The amount of minutes that the player took</param>
        /// <param name="seconds">The amoun of seconds that the player took</param>
        public void AddNewHighScore(string playerName, int minutes, int seconds)
        {
            //Add
            for (int i = 0; i < highscores.Length; i++)
            {
                if (highscores[i] == null || i + 1 == highscores.Length)
                {
                    highscores[i] = new Highscore(playerName, minutes, seconds);
                    break;
                }
            }

            //Order
            Highscore.OrderHighScores(highscores);
        }

        /// <summary>Loads highscore data from file if found</summary>
        public void LoadHighscores()
        {

        }

        /// <summary>Saves highscore data to file</summary>
        public void SaveHighscores()
        {

        }

        /// <summary> Draws UI objects that are only met to be drawn once, called only when switchingscreens is true</summary>
        public void DrawOnce()
        {
            title.Draw();
            lblCont.Draw();

            for (int i = 0; i < lblHighscores.Length; i++)
            {
                if (lblHighscores[i] != null)
                    lblHighscores[i].Draw();
                else
                    break;
            }
        }

        /// <summary>Updates the screens</summary>
        public void Update()
        {
            if (Program.switchingScreen)
            {
                SetupScreen();
                RecalculatePositions();
                
                DrawOnce();
            }

            Program.switchingScreen = false;
        }

        /// <summary>Draws the screen, called every loop</summary>
        public void Draw()
        {

        }
    }
}
