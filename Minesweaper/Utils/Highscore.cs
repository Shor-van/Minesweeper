using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Utils
{
    public class Highscore
    {
        private string playerName; //the name the player entered 
        private int minutes; //The amounts of minutes that the player took
        private int seconds; //The amount of seconds that the player took

        /// <summary>Base constructor</summary>
        /// <param name="playerName">The name the player entered as their name</param>
        /// <param name="minutes">The amount of miniutes that the player took</param>
        /// <param name="seconds">The amount of seconds that the player took</param>
        public Highscore(string playerName, int minutes, int seconds)
        {
            this.playerName = playerName;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        /// <summary>Orders a array of highscores from shortest time first</summary>
        /// <param name="highscores">A array of highscores to order</param>
        public static Highscore[] OrderHighScores(Highscore[] highscores)
        {
            Highscore[] orderedHighscores = highscores.ToArray<Highscore>();
            return orderedHighscores;
        }
    }
}
