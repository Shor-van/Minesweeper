using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweaper.Screens.UI
{
    //This will handle the text used in the menus 
    public class MenuText
    {
        string text; //The text to show
        int posX, posY; //The top left location on the screen
        ConsoleColor aColor, sColor, wColor; //All the colors to use
        bool active; //Weather the player has this option selected
        bool enable; //Weather the player can select this option

        //Gets and sets
        public string Text { get { return text; } set { text = value; } }
        public int PosX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }

        public bool Active { get { return active; } set { active = value; } }
        public bool Enable { get { return enable; } set { enable = value; } }

        public ConsoleColor WColor { get { return wColor; } set { wColor = value; }}
        public ConsoleColor SColor { get { return sColor; } set { sColor = value; } }
        public ConsoleColor AColor { get { return aColor; } set { aColor = value; } }

        /// <summary>The base constructor</summary>
        /// <param name="pText">The text to show</param>
        /// <param name="pPosX">The left most location of the text on the screen</param>
        /// <param name="pPosY">The top most location of the text on the screen</param>
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

        //Event handlers

        /// <summary>Updates the MenuText</summary>
        public void Update()
        {
            if (active && aColor == wColor) 
                aColor = sColor;
            else if (!active && aColor == sColor)
                aColor = wColor;
            if (!active)
            {
                if (!enable)
                    aColor = ConsoleColor.DarkGray;
                else
                    aColor = wColor;
            }
        }

        /// <summary>Draws the MenuText</summary>
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
