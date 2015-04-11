using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweaper.Screens.UI
{
    //Will handle all the drawing and update of the Title Texts
    public class TitleText
    {
        string text; //The text to display
        ConsoleColor color; //The color at witch to draw the text
        int posX, posY; //The top left location at witch to draw the text

        //Gets and set
        public string Text { get { return text; } set { text = value; } }
        public ConsoleColor Color { get { return color; } set { color = value; } }
        public int PositionX { get { return posX; }set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }
        
        /// <summary>Base construcor</summary>
        /// <param name="pText">The text to draw</param>
        /// <param name="pColor">The color atith to draw the text</param>
        /// <param name="pPosX">The left mst location oe screen at witch to draw</param>
        /// <param name="pPosY">The top most location on the screen at witch to draw</param>
        public TitleText(string pText, ConsoleColor pColor, int pPosX, int pPosY)
        {
            text = pText;
            color = pColor;
            posX = pPosX;
            posY = pPosY;
        }

        /// <summary>Updates the text, Does noting</summary>
        public void Update() { }

        /// <summary>Draws the text on the screen</summary>
        public void Draw()
        {
            char[] letter = new char[text.Length];
            letter = text.ToCharArray(0, text.Length);
            Console.ForegroundColor = color;
            Console.BackgroundColor = Program.backgroundColor;
            int left = posY;
            int top = posX;
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    switch (letter[i])
                    {
                        //UpperCase
                        case 'A':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███ ");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'B':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 6;
                            break;
                        case 'C':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ████");
                            left = left + 6;
                            break;
                        case 'D':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 6;
                            break;
                        case 'E':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case 'F':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█");
                            left = left + 5;
                            break;
                        case 'G':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█  ██");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ████");
                            left = left + 6;
                            break;
                        case 'H':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'I':
                            Console.SetCursorPosition(left, top);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("███");
                            left = left + 4;
                            break;
                        case 'J':
                            Console.SetCursorPosition(left, top);
                            Console.Write("  ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ██");
                            left = left + 6;
                            break;
                        case 'K':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█ █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("██");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█ █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█  █");
                            left = left + 5;
                            break;
                        case 'L':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case 'M':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("██ ██");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'N':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("██  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  ██");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'O':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███ ");
                            left = left + 6;
                            break;
                        case 'P':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█");
                            left = left + 6;
                            break;
                        case 'Q':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ██");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ████");
                            left = left + 6;
                            break;
                        case 'R':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'S':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("    █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 6;
                            break;
                        case 'T':
                            Console.SetCursorPosition(left, top);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" █");
                            left = left + 4;
                            break;
                        case 'U':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███");
                            left = left + 6;
                            break;
                        case 'V':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("  █");
                            left = left + 6;
                            break;
                        case 'W':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("██ ██");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'X':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'Y':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("  █");
                            left = left + 6;
                            break;
                        case 'Z':
                            Console.SetCursorPosition(left, top);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("███");
                            left = left + 4;
                            break;
                        //Numbers
                        case '0':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  ██");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("██  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███");
                            left = left + 6;
                            break;
                        case '1':
                            Console.SetCursorPosition(left, top);
                            Console.Write("██");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("███");
                            left = left + 4;
                            break;
                        case '2':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '3':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '4':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("   █");
                            left = left + 5;
                            break;
                        case '5':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   ");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '6':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '7':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("   █");
                            left = left + 5;
                            break;
                        case '8':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███");
                            left = left + 6;
                            break;
                        case '9':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        //Special Chars
                        case ' ':
                            left = left + 3;
                            break;
                        case '\'':
                            Console.SetCursorPosition(left, top - 1);
                            Console.Write(" ██");
                            Console.SetCursorPosition(left, top);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █");
                            left = left + 4;
                            break;
                        case ':':
                            Console.SetCursorPosition(left,top+1);
                            Console.Write("██");
                            Console.SetCursorPosition(left, top+3);
                            Console.Write("██");
                            left = left + 3;
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Holy Cr*p on a stick, somethings wrong!");
                    Console.WriteLine();
                    Console.WriteLine("Error:ArgumentOutOfRangeException was thrown while drawing text:" + text);
                    Console.WriteLine();
                    Console.WriteLine("Variable information");
                    Console.WriteLine("=====================");
                    Console.WriteLine("left:" + left + " top:" + top + " letter dawing:" + letter[i]);
                    Console.WriteLine();
                    Console.WriteLine("*End of report*");
                    Console.WriteLine("Press any key to close.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            }
            Console.ResetColor();
        }
    }
}
