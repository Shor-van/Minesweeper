using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Minesweeper.Utils;

namespace Minesweeper.Screens.UI
{
    public class SplashText //Could have used the TextLabel Obj but meh
    {
        private static string[] splashTexts; //Array of the splash texts loaded from the file

        private int posX, posY; //The top left location of the splash text on the screen
        private string text; //The splash text to draw
        private ConsoleColor color; //The color used to draw the text

        //Gets and sets
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }
        public ConsoleColor Color { get { return color; } set { color = value; } }

        public SplashText(int posX, int posY, ConsoleColor color)
        {
            //Check if splash texts have been loaded
            if (splashTexts == null)
                LoadSplashTexts();

            this.color = color;
            this.posY = posY;
            this.posX = posX;

            GenerateNewSplashText();
        }

        private static void LoadSplashTexts()
        {
            try
            {
                Assembly assembly;
                StreamReader reader;

                //Load file from resource
                assembly = Assembly.GetExecutingAssembly();
                reader = new StreamReader(assembly.GetManifestResourceStream("Minesweeper.Assets.SplashTexts.txt"));
                
                //Read texts
                List<string> tmpStrs = new List<string>();
                while (reader.EndOfStream == false)
                    tmpStrs.Add(reader.ReadLine());
                reader.Close();

                //Store strings in static array
                if (tmpStrs.Count > 0)
                    splashTexts = tmpStrs.ToArray<string>();
                else
                    splashTexts = new string[] { "Slash texts failed to load/Not found." };
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

        public void GenerateNewSplashText()
        {
            int idx = Program.GenerateRandom(0, splashTexts.Length);
            text = splashTexts[idx];

            //Check if would fit
            if (text.Length >= Program.ViewWidth() - posX)
            {
                int change = text.Length - (Program.ViewWidth() - posX);
                posX -= change;
            }
            else
            {
                posX = Program.ViewWidth() / 2;
            }
        }

        /// <summary>If the splash text contains '*' then they get replace with a random character else does nothing</summary>
        public void Update()
        {
            if (text.Contains("*"))
            {
                //Do the char swap thingy
            }
        }

        /// <summary>Draws the splash text at the set location and color</summary>
        public void Draw()
        {
            try
            {
                Console.ForegroundColor = color;
                Console.BackgroundColor = Program.backgroundColor;
                Console.SetCursorPosition(posX, posY);

                Console.Write(text);

                Console.ResetColor();
            }
            catch(Exception e)
            {
                CrashReporter.CreateCrashReport(e, new string[] { "Text:" + text, "PosX:" + posX + " PosY:" + posY });
            }
        }
    }
}
