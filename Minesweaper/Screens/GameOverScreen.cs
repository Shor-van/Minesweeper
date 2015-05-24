using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Screens.UI;

namespace Minesweeper.Screens
{
    public class GameOverScreen
    {
        private TitleText title; //GAME OVER title text
        private TitleText winLose; //The you win/you lose text
        private TextLabel time; //The amount of time that the round lasted
        private TextLabel lblCont; //Lable that says to press enter to continue

        /// <summary>Inisalize the screen</summary>
        public GameOverScreen()
        {
            
        }

        /// <summary>Setsup the screen based on weathre them player won the round</summary>
        /// <param name="mins">The minutes that the game took</param>
        /// <param name="secs">The seconds that the game took</param>
        public void SetupScreen(int mins, int secs)
        {
            title = new TitleText("GAME OVER", ConsoleColor.Red, 0, 0);

            //Time formating
            string strMin = "00";
            string strSec = "00";

            if (mins < 10)
                strMin = "0" + mins;
            else if (mins > 0)
                strMin = mins.ToString();

            if (secs < 10)
                strSec = "0" + secs;
            else if (secs > 0)
                strSec = secs.ToString();

            time = new TextLabel("Your time was:" + strMin + ":" + strSec, 0, 0, ConsoleColor.White);

            if (Program.gameWon == true)
                winLose = new TitleText("YOU WIN", ConsoleColor.Green, 0, 0);
            else
                winLose = new TitleText("YOU LOSE", ConsoleColor.Red, 0, 0);

            RecalculatePositions();
        }
        
        /// <summary>Re calculates all the positions of the UI</summary>
        public void RecalculatePositions()
        {
            //Title
            title.PositionX = (Program.ViewWidth() / 2) - (title.MeasureSize()[0] / 2);
            title.PositionY = 2;

            //Win Lose tag
            winLose.PositionX = (Program.ViewWidth() / 2) - (winLose.MeasureSize()[0] / 2);
            winLose.PositionY = (title.PositionY + title.MeasureSize()[1]) + 3;

            //Time
            time.PositionX = (Program.ViewWidth() / 2) - (time.MeasureSize()[0] / 2);
            time.PositionY = (winLose.PositionY + winLose.MeasureSize()[1]) + 2;
        }

        /// <summary>This is called when the game changes screen</summary>
        public void DrawOnce()
        {
            title.Draw();
            winLose.Draw();
            time.Draw();
        }

        /// <summary>Updates the screen</summary>
        public void Update()
        {
            if (Program.switchingScreen)
            {
                DrawOnce();
            }

            Program.switchingScreen = false;            
        }

        /// <summary>Draws the objcets thet should be drawn every</summary>
        public void Draw()
        {

        }
    }
}
