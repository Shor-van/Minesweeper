using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Screens.UI
{
    //Handles the selection arrow
    public class Arrow
    {
        ConsoleColor color; //The color of the arrow
        int posX, posY; //The location on the screen
        bool invert; //Weather the arrow is inverted

        //Gets and sets
        public ConsoleColor Color { get { return color; } set { color = value; } }
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }

        public Arrow(ConsoleColor pColor, int pPosX, int pPosY,bool pInvert)
        {
            color = pColor;
            posX = pPosX;
            posY = pPosY;
            invert = pInvert;
        }

        public void Update(int newPosX,int newPosY)
        {
            Console.MoveBufferArea(posX, posY, 2, 1, newPosX, newPosY);
            posX = newPosX;
            posY = newPosY;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = Program.backgroundColor;
            Console.SetCursorPosition(posX,posY);
            
            if (invert)
                Console.Write("<-");           
            else           
                Console.Write("->");

            Console.ResetColor();
        }
    }
}
