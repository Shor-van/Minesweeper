using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Utils;

namespace Minesweeper.Screens
{
    public class HighscoreScreen
    {
        private Highscore[] highscores; //The array of the highscores

        /// <summary>Base constructors</summary>
        public HighscoreScreen()
        {
            highscores = new Highscore[10];
        }

        /// <summary>Recalulates the positions of the UI objects </summary>
        public void RecalculatePositions()
        {

        }

        /// <summary>Sets up the screen, builds the highscore list for the array of high scores</summary>
        public void SetupScreen()
        {

        }

        /// <summary>Adds a new High score to the list</summary>
        /// <param name="playerName">The name that the player entered</param>
        /// <param name="minutes">The amount of minutes that the player took</param>
        /// <param name="seconds">The amoun of seconds that the player took</param>
        public void AddNewHighSore(string playerName, int minutes, int seconds)
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

        /// <summary> Draws UI objects that are only met to be drawn once, called only when switchingscreens is true</summary>
        public void DrawOnce()
        {

        }

        /// <summary>Updates the screens</summary>
        public void Update()
        {

        }

        /// <summary>Draws the screen, called every loop</summary>
        public void Draw()
        {

        }
    }
}
