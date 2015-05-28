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
        private List<List<MultiColoredTextLabel>> pages; //A list containing all the pages, ATM pages are just lists of MultiColoredTextLabels
        private int currentPage; //The current page to show
        private bool switchingPage; //Weather the screen is changeing page
        private int menuSel; //The selected option between next page and prev page (1,0)
        private MenuText[] options; //The Next Page and prev page options

        /// <summary>Base constructor, loads the text from the list and builds the screen</summary>
        public HelpScreen()
        {
            title = new TitleText("HOW TO PLAY", ConsoleColor.Red, 0, 0);
            pages = new List<List<MultiColoredTextLabel>>();
            options = new MenuText[2];
            menuSel = 0;

            options[0] = new MenuText("<-Prev Page", 0, 0);
            options[1] = new MenuText("Next Page->", 0, 0);

            //Register Events
            options[0].Selected += new MenuText.BaseEventHandler(OnPrevPageSelected);
            options[1].Selected += new MenuText.BaseEventHandler(OnNextPageSelected);

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

                pages.Add(new List<MultiColoredTextLabel>());
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
                                pages[pge].Add(new MultiColoredTextLabel(line, 0, y, ConsoleColor.White));
                                y++;
                            }
                            else
                            {
                                pge++;
                                pages.Add(new List<MultiColoredTextLabel>());
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
                    pages[0].Add(new MultiColoredTextLabel("  &2ERROR:HelpText.txt dose not contain any text!!!!", x, y, ConsoleColor.White));
                    pages[0].Add(new MultiColoredTextLabel("  &2ERROR:Check the helpText.txt file for info.", x, y+1, ConsoleColor.White));
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

        /// <summary>Recalculates all the positions for the UI objects</summary>
        public void RecalculatePositions()
        {
            title.PositionX = (Program.ViewWidth() / 2) - (title.MeasureSize()[0] / 2);
            title.PositionY = 2;

            options[0].PositionX = 5;
            options[0].PositionY = (Program.ViewHieght() - 2);

            options[1].PositionX = (Program.ViewWidth() - (options[1].MeasureSize()[0])) - 5;
            options[1].PositionY = (Program.ViewHieght() - 2);
        }

        //Event Handlers
        private void OnPrevPageSelected(object sender, EventArgs e)
        {
            currentPage--;
            switchingPage = true;
        }
        private void OnNextPageSelected(object sender, EventArgs e)
        {
            currentPage++;
            switchingPage = true;
        }

        //Loop
        /// <summary>Updates the help screen</summary>
        public void Update()
        {
            if(switchingPage == true)
                Console.Clear();

            if (Program.switchingScreen == true)
            {
                menuSel = 1;
                currentPage = 0;
            }

            if (Program.switchingScreen == true || switchingPage == true)
            {
                RecalculatePositions();
                DrawOnce();
            }

            Program.switchingScreen = false;
            switchingPage = false;

            //Page switching
            if (Keyboard.IsKeyPressed(ConsoleKey.A))
            {
                if (menuSel <= 0)
                {
                    if (options[0].Enable)
                        menuSel = 0;
                }
                else
                {
                    if(options[menuSel - 1].Enable)
                        menuSel--;
                }
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.D))
            {
                if (menuSel >= 1)
                {
                    if (options[1].Enable)
                        menuSel = 1;
                }
                else
                {
                    if (options[menuSel + 1].Enable)
                        menuSel++;
                }
            }

            //Back to menu
            else if (Keyboard.IsKeyPressed(ConsoleKey.Escape))
            {
                Program.gameState = GameState.MenuState;
                return;
            }

            //Enable disable
            if (currentPage > 0)
                options[0].Enable = true;
            else
                options[0].Enable = false;

            if (currentPage < pages.Count - 1)
                options[1].Enable = true;
            else
                options[1].Enable = false;

            //Update core menu
            for (int i = 0; i < options.Length; i++)
            {
                if (i == menuSel)
                    options[menuSel].Active = true;
                else
                    options[i].Active = false;

                options[i].Update();
            }
        }

        /// <summary>Draws objects that should only be drawn once. Should only be called once</summary>
        public void DrawOnce()
        {
            //Title
            title.Draw();

            //Draw the lines
            foreach (MultiColoredTextLabel line in pages[currentPage])
                line.Draw();
        }

        /// <summary>Draws the screen, this is called every loop</summary>
        public void Draw()
        {
            for (int i = 0; i < options.Length; i++)
                options[i].Draw();
        }
    }
}
