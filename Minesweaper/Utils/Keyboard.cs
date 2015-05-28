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
        private static bool ignoreInput = false; //Weather the keyboard will read key presses

        /// <summary>Updates the keyboard handler, Gets the current state of the keys</summary>
        public static void Update()
        {
            if (ignoreInput == false)
            {
                lastKeyInfo = currentKeyInfo;
                currentKeyInfo = Console.ReadKey(true);
            }
            else
                Clear();
        }

        /// <summary>Checks if the spesified key is pressed</summary>
        /// <param name="key">The key to check if it is pressed</param>
        /// <returns>True if the key is pressed</returns>
        public static bool IsKeyPressed(ConsoleKey key)
        {
            return currentKeyInfo.Key == key;
        }

        /// <summary>Checks if that any key is pressed</summary>
        /// <returns>True if a key was pressed else false</returns>
        public static bool IsAnyKeyPressed()
        {
            if (currentKeyInfo.Key != 0)
                return true;
            return false;
        }

        /// <summary>Gets the currently pressed key</summary>
        /// <returns>The currently pressed key</returns>
        public static ConsoleKey GetPressedKey() { return currentKeyInfo.Key; }

        /// <summary>Sets if the keybaord should ignore key presses</summary>
        /// <param name="value">True or false</param>
        public static void SetIgnoreInput(bool value) { ignoreInput = value; }

        /// <summary>Removes all pressed keyys</summary>
        public static void Clear()
        {
            currentKeyInfo = new ConsoleKeyInfo();
        }
    }
}
