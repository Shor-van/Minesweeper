using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastermind.Screens
{
    //Handles the selection arrow
    public class Arrow
    {
        ConsoleColor color;
        int posX;
        int posY;
        bool invert;

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
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

        public Arrow(ConsoleColor pColor, int pPosX, int pPosY,bool pInvert)
        {
            color = pColor;
            posX = pPosX;
            posY = pPosY;
            invert = pInvert;
        }

        public void Update(int newPosX,int newPosY)
        {
            Console.MoveBufferArea(posY, posX, 2, 1, newPosY, newPosX);
            posX = newPosX;
            posY = newPosY;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = Program.backgroundColor;
            Console.SetCursorPosition(posY,posX);
            if (invert)
            {
                Console.Write("<-");
            }
            else
            {
                Console.Write("->");
            }
            Console.ResetColor();
        }
    }
}
