using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Screens.UI;

namespace Minesweeper.Utils
{
    public static class DebugUtil
    {
        private static TextLabel time = new TextLabel("0000000", 0, 0, ConsoleColor.Cyan); //The time that the loop took
        private static TextLabel lblFps = new TextLabel("FPS", 0, 1, ConsoleColor.Cyan); //The amount of times that the loop is called in a second
        private static TextLabel lblIgnoreInput = new TextLabel("IgnoreInput: ", 0, 1, ConsoleColor.Cyan); //Weather the input is ignored

        private static float elepsedTime;
        private static int fps;
        private static int totalFrames;

        public static void Update()
        {
            elepsedTime += (float)Program.lastLoopTime;
            if (elepsedTime >= 1000.0f)
            {
                lblFps.Text = "FPS:" + totalFrames + " ";
                totalFrames = 0;
                elepsedTime = 0;
            }

            time.Text = "Loop Time:" + Program.lastLoopTime.ToString() + " AvailableKey:" + Console.KeyAvailable + "  ";
            lblIgnoreInput.Text = "IgnoreInput:" + Keyboard.GetIgnoreInput() + " ET:" + Keyboard.GetElepsedTime() + " IT:" + Keyboard.GetIgnoreTime();
            lblIgnoreInput.PositionX = lblFps.MeasureSize()[0];
        }

        public static void Draw()
        {
            totalFrames++;
            lblFps.Draw();
            time.Draw();
            lblIgnoreInput.Draw();
        }
    }
}
