using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Screens.UI
{
    public class ControlPanel
    {
        private int posX, posY; //The location of the control panel
        private int width, height; //The width and height of the panel
        private ConsoleColor fColor; //The color of the texts
        private ConsoleColor bColor; //The color of the background

        //Gets and sets
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value; } }

        /// <summary>Re calculates the position of all the componets</summary>
        public void RecalculatePositions()
        {
           
        }

        /// <summary>Updates the control panel</summary>
        public void Update()
        {
           
        }

        /// <summary>Draws items that are drawn once</summary>
        public void OneTimeDraw()
        {
            //Draw base background
            for (int i = posX; i < width + posX; i++)
            {
                for (int j = posY; j < height + posY; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.BackgroundColor = bColor;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>Draws the control panel</summary>
        public void Draw()
        {

        }
    }
}
