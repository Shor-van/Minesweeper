using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweaper
{
    //This will handle the text used in the menus 
    public class MenuText
    {
        string text;
        int posX;
        int posY;
        ConsoleColor aColor, sColor, wColor;
        bool active;
        bool enable;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int PosX 
        {
            get { return posX; }
            set { posX = value; }
        }
        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }

        public ConsoleColor WColor
        {
            get { return wColor; }
            set { wColor = value; }
        }
        public ConsoleColor SColor
        {
            get { return sColor; }
            set { sColor = value; }
        }
        public ConsoleColor AColor
        {
            get { return aColor; }
            set { aColor = value; }
        }

        public MenuText(string pText, int pPosX, int pPosY)
        {
            text = pText;
            posX = pPosX;
            posY = pPosY;
            active = false;
            enable = true;
            aColor = wColor = ConsoleColor.White;
            sColor = ConsoleColor.Yellow;
        }

        public void Update()
        {
            if (active && aColor == wColor)
            {
                aColor = sColor;
            }
            else if (!active && aColor == sColor)
            {
                aColor = wColor;
            }
            if (!active)
            {
                if (!enable)
                {
                    aColor = ConsoleColor.DarkGray;
                }
                else
                {
                    aColor = wColor;
                }
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = aColor;
            Console.BackgroundColor = Program.backgroundColor;
            Console.SetCursorPosition(posY, posX);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
