using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Sound
{
    public static class SoundThread
    {
        public static void Beep(int hz, int ms)
        {
            Console.Beep(hz, ms);
        }
    }
}
