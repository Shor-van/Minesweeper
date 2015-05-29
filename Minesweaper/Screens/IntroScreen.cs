using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Minesweeper.Screens.UI;

namespace Minesweeper.Screens
{
    public class IntroScreen
    {
        private TitleText shadow; //The SHADOW TitleText
        private TitleText games; //The GAMES TitleText

        public IntroScreen()
        {
            shadow = new TitleText("SHADOW GAMES", ConsoleColor.Black, 0, 0);
            games = new TitleText("GAMES", ConsoleColor.White, 0, 0);

            RecalcualtePositions();
        }

        private void RecalcualtePositions()
        {
            shadow.PositionX = (Program.ViewWidth() / 2) - (shadow.MeasureSize()[0] / 2);
            shadow.PositionY = 2;
        }

        public void OneTimeDraw()
        {
            shadow.Draw();
        }

        public void Update()
        {
            if (Program.switchingScreen)
            {
                RecalcualtePositions();
                Program.backgroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = Program.backgroundColor;
                Console.Clear();
                OneTimeDraw();
            }

            Program.switchingScreen = false;
        }

        public void Draw()
        {

        }
    }
}
