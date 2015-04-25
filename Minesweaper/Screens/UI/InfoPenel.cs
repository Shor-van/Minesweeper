using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.GameBoard;

namespace Minesweeper.Screens.UI
{
    //Info penel
    public class InfoPenel
    {
        private int posX, posY; //Location of the info penel
        private int width, height; //The widthn and height of the indo penel
        private ConsoleColor fColor; //The Color used in the texts
        private ConsoleColor bColor; //The Color used to draw the background

        private TextLabel time; //Text label showing them amounmt of tme that has passed
        private TextLabel mines; //The number of mines on the board 

        //Gets and sets
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value; } }

        /// <summary>Base constructor</summary>
        /// <param name="posX">The X location on the screen</param>
        /// <param name="posY">The y location on the screen</param>
        /// <param name="width">The width of the info penel</param>
        /// <param name="height">The height of the info penel</param>
        /// <param name="fColor">The color of the text to used</param>
        /// <param name="bColor">The color of the background color</param>
        public InfoPenel(int posX, int posY, int width, int height, ConsoleColor fColor, ConsoleColor bColor)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;

            this.fColor = fColor;
            this.bColor = bColor;

            time = new TextLabel("TIME:00:00", 0, 0, fColor);
            mines = new TextLabel("MINES:00", 0, 0, fColor);

            RecalculatePositions();
        }

        public void RecalculatePositions()
        {
            time.PositionX = (posX + ((width / 2) - time.MeasureSize()[0] - 3));
            time.PositionY = (posY + (height / 2));

            mines.PositionX = (posX + ((width / 2) + 5));
            mines.PositionY = (posY + (height / 2));
        }

        /// <summary>Updates info penel, calculates time</summary>
        public void Update(Board board)
        {
            if (Program.sizeChanged)
            {
                RecalculatePositions();
            }
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

        /// <summary>Draws the info penel</summary>
        public void Draw()
        {
            Program.backgroundColor = bColor;

            //Labels
            time.Draw();
            mines.Draw();

            Program.backgroundColor = ConsoleColor.Black;
        }
    }
}
