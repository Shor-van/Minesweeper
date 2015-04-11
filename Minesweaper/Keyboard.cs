using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweaper
{
    //Will handle all the input logic
    public class Keyboard
    {
        ConsoleKeyInfo keyPress;

        public bool Up
        {
            get { return IsKeyPressed(ConsoleKey.UpArrow); }
        }
        public bool Down
        {
            get { return IsKeyPressed(ConsoleKey.DownArrow); }
        }
        public bool Left
        {
            get { return IsKeyPressed(ConsoleKey.LeftArrow); }
        }
        public bool Right
        {
            get { return IsKeyPressed(ConsoleKey.RightArrow); }
        }

        public bool W
        {
            get { return IsKeyPressed(ConsoleKey.W); }
        }
        public bool S
        {
            get { return IsKeyPressed(ConsoleKey.S); }
        }
        public bool A
        {
            get { return IsKeyPressed(ConsoleKey.A); }
        }
        public bool D
        {
            get { return IsKeyPressed(ConsoleKey.D); }
        }

        public bool Enter
        {
            get { return IsKeyPressed(ConsoleKey.Enter); }
        }
        public bool Escape
        {
            get { return IsKeyPressed(ConsoleKey.Escape); }
        }

        public bool Red
        {
            get { return IsKeyPressed(ConsoleKey.R); }
        }
        public bool Lime
        {
            get { return IsKeyPressed(ConsoleKey.L); }
        }
        public bool Yellow
        {
            get { return IsKeyPressed(ConsoleKey.Y); }
        }
        public bool Blue
        {
            get { return IsKeyPressed(ConsoleKey.B); }
        }

        public bool Cyan
        {
            get { return IsKeyPressed(ConsoleKey.C); }
        }
        public bool White
        {
            get { return IsKeyPressed(ConsoleKey.W); }
        }

        public bool Magenta
        {
            get { return IsKeyPressed(ConsoleKey.M); }
        }
        public bool Gray
        {
            get { return IsKeyPressed(ConsoleKey.G); }
        }

        public bool IsKeyPressed(ConsoleKey key)
        {
            return keyPress.Key == key;
        }

        public void Update()
        {
            keyPress = Console.ReadKey(true);
        }
    }
}
