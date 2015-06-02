using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Minesweeper.Screens.UI;

namespace Minesweeper.Screens
{
    public class IntroScreen
    {
        private TitleText shadow; //The SHADOW GAMES TitleText
        private TitleText shorvan; //The Shor_van TitleText
        private LogoAnimation shadowAnim; //The intro animation of the shadow logo
        
        /// <summary>Initsalize the intro</summary>
        public IntroScreen()
        {
            shadow = new TitleText("SHADOW GAMES", ConsoleColor.Black, 0, 0);
            shorvan = new TitleText("SHOR VAN", ConsoleColor.White, 0, 0);
            shadowAnim = new LogoAnimation(0,0,12);

            RecalcualtePositions();
        }

        /// <summary>Recalculates all the positions</summary>
        private void RecalcualtePositions()
        {
            shadow.PositionX = (Program.ViewWidth() / 2) - (shadow.MeasureSize()[0] / 2);
            shadow.PositionY = 2;

            shorvan.PositionX = (Program.ViewWidth() / 2) - (shorvan.MeasureSize()[0] / 2);
            shorvan.PositionY = (Program.ViewHieght() - shorvan.MeasureSize()[1]) - 3;
        }

        /// <summary>Draws objects that should only be drawn when the games switchs to this screen</summary>
        public void OneTimeDraw()
        {
            shadow.Draw();
            shorvan.Draw();
        }

        /// <summary>Updates the screen will mostly be the animation</summary>
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
            shadowAnim.Update();
        }

        /// <summary>Draws the screen, is called every loop</summary>
        public void Draw()
        {
            shadowAnim.RanderLogoAnim(13);
        }
    }
}
