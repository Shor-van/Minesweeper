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

        //Gest and sets
        public string PlayerName { get { return playerName; } }
        public int Minutes { get { return minutes; } }
        public int Seconds { get { return seconds; } }

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

        /// <summary>Gets a formated string of the time taken in the format MM:SS</summary>
        /// <returns>>Returms a formated string of the time taken in the format MM:SS</returns>
        public string GetFormatedTime()
        {
            string strM = "00";
            string strS = "00";
            if (minutes < 10)
                strM = "0" + minutes;
            else
                strM = minutes.ToString();

            if (seconds < 10)
                strS = "0" + seconds;
            else
                strS = seconds.ToString();

            return strM + ":" + strS;
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
