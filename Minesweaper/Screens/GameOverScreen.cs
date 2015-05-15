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
        public void SetupScreen()
        {
            title = new TitleText("GAME OVER", ConsoleColor.Red, 0, 0);
            time = new TextLabel("Your time was:00:00", 0, 0, ConsoleColor.White);

            if (Program.gameWon == true)
                winLose = new TitleText("YOU WIN", ConsoleColor.Green, 0, 0);
            else
                winLose = new TitleText("YOU LOSE", ConsoleColor.Red, 0, 0);
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
