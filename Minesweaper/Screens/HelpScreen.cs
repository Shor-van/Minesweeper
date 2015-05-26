using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Screens.UI;
using System.Reflection;
using System.IO;
using Minesweeper.Utils;

namespace Minesweeper.Screens
{
    public class HelpScreen
    {
        private TitleText title; //The title "Help Screen"
        private List<List<MultiColoredTextLabel>> textList; //A list containing all the text labels
        private int currentPage; //The current page to show
        private bool switchingPage; //Weather the screen is changeing page

        /// <summary>Base constructor, loads the text from the list and builds the screen</summary>
        public HelpScreen()
        {
            title = new TitleText("HOW TO PLAY", ConsoleColor.Red, 0, 0);
            textList = new List<List<MultiColoredTextLabel>>();

            CreateTextLines(0, 8);
            currentPage = 0;
            switchingPage = false;

            RecalculatePositions();
        }

        /// <summary>Creates the actual help text based on the HelpText.txt file</summary>
        /// <param name="x">The start of each TextLabel</param>
        /// <param name="y">The Y level at witch to start the lines</param>
        private void CreateTextLines(int x, int y)
        {
            //Create text labels from text file
            int sy = y;
            try
            {
                Assembly assembly;
                StreamReader reader;

                //Load file from resource
                assembly = Assembly.GetExecutingAssembly();
                reader = new StreamReader(assembly.GetManifestResourceStream("Minesweeper.Assets.HelpText.txt"));

                //Read texts
                List<string> tmpStrs = new List<string>();
                while (reader.EndOfStream == false)
                    tmpStrs.Add(reader.ReadLine());
                reader.Close();

                textList.Add(new List<MultiColoredTextLabel>());
                int pge = 0;

                //Check if any texts where loaded
                if (tmpStrs.Count > 0)
                {
                    //Create text labels
                    foreach (string line in tmpStrs)
                    {
                        if (line != String.Empty)
                        {
                            if (line.Trim() != "&pge;")
                            {
                                textList[pge].Add(new MultiColoredTextLabel(line, 0, y, ConsoleColor.White));
                                y++;
                            }
                            else
                            {
                                pge++;
                                textList.Add(new List<MultiColoredTextLabel>());
                                y = sy;
                            }
                        }
                        else
                            y++;
                    }
                }
                else
                {
                    //ERROR
                    textList[0].Add(new MultiColoredTextLabel("  &2ERROR:HelpText.txt dose not contain any text!!!!", x, y, ConsoleColor.White));
                    textList[0].Add(new MultiColoredTextLabel("  &2ERROR:Check the helpText.txt file for info.", x, y+1, ConsoleColor.White));
                }
            }
            catch (Exception e)
            {
                Assembly assembly;
                assembly = Assembly.GetExecutingAssembly();

                string[] res = assembly.GetManifestResourceNames();
                List<string> tmp = res.ToList<string>();
                tmp.Insert(0, "Resources:");
                CrashReporter.CreateCrashReport(e, tmp.ToArray<string>());
            }
        }

        public void RecalculatePositions()
        {
            title.PositionX = (Program.ViewWidth() / 2) - (title.MeasureSize()[0] / 2);
            title.PositionY = 2;
        }

        /// <summary>Updates the help screen</summary>
        public void Update()
        {
            if(switchingPage == true)
                Console.Clear();

            if (Program.switchingScreen == true || switchingPage == true)
            {
                RecalculatePositions();
                DrawOnce();
            }

            Program.switchingScreen = false;
            switchingPage = false;

            if (Keyboard.IsKeyPressed(ConsoleKey.D2))
            {
                currentPage = 1;
                switchingPage = true;
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.D1))
            {
                currentPage = 0;
                switchingPage = true;
            }

        }

        /// <summary>Should only be called once</summary>
        public void DrawOnce()
        {
            //Title
            title.Draw();

            //Draw the lines
            foreach (MultiColoredTextLabel line in textList[currentPage])
                line.Draw();
        }

        /// <summary>Draws the screen</summary>
        public void Draw()
        {

        }
    }
}
