using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Screens.UI;

namespace Minesweeper.Utils
{
    public static class DebugUtil
    {
        private static TextLabel time = new TextLabel("0000000", 0, 0, ConsoleColor.Cyan); //Test
        private static TextLabel lblFps = new TextLabel("FPS", 0, 1, ConsoleColor.DarkCyan);

        private static float elepsedTime;
        private static int fps;
        private static int totalFrames;

        public static void Update()
        {
            elepsedTime += (float)Program.lastLoopTime;
            if (elepsedTime >= 1000.0f)
            {
                lblFps.Text = "FPS:" + totalFrames;
                totalFrames = 0;
                elepsedTime = 0;
            }

            time.Text = "Loop Time:" + Program.lastLoopTime.ToString();
        }

        public static void Draw()
        {
            totalFrames++;
            lblFps.Draw();
            time.Draw();
        }
    }
}
