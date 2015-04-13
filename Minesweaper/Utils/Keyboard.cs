using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Utils
{
    //Will handle all the input logic
    public static class Keyboard
    {
        private static ConsoleKeyInfo currentKeyInfo; //The current key info
        private static ConsoleKeyInfo lastKeyInfo; //The last loops key info

        /// <summary>Checks if the spesified key is pressed</summary>
        /// <param name="key">The key to check if it is pressed</param>
        /// <returns>True if the key is pressed</returns>
        public static bool IsKeyPressed(ConsoleKey key)
        {
            return currentKeyInfo.Key == key;
        }

        /// <summary>Updates the keyboard handler, Gets the current state of the keys</summary>
        public static void Update()
        {
            lastKeyInfo = currentKeyInfo;
            currentKeyInfo= Console.ReadKey(true);
        }

        public static void Clear()
        {
            currentKeyInfo = new ConsoleKeyInfo();
        }
    }
}
