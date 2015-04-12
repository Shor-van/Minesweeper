using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweaper.Utils;
using Minesweaper.Screens;

namespace Minesweaper
{
    public enum GameState
    {
        IntroState,
        MenuState,
        GameOptionState,
        GamePlayState,
        GameOverState,
        ScoreState,
        HelpState
    }

    class Program
    {
        public static bool isExiting = false; //Weather the game is exiting
        public static bool switchingScreen = false; //Weather the screen is changing
        public static ConsoleColor backgroundColor = ConsoleColor.Black; //The current background color
        public static GameState gameState = GameState.MenuState; //The "state" of the game, used to see witch screen to draw
        public static bool sizeChanged = true; //Weather the window size has changed 

        //Screens
        private static MenuScreen menuScreen;

        private static int viewWidth = 100, viewHeight = 34;

        private static void Initalize()
        {
            Console.SetWindowSize(viewWidth, viewHeight);
            Console.Title = "Minesweeper V0.02";
            Console.CursorVisible = false;
            Console.BufferWidth = viewWidth;
            Console.BufferHeight = viewHeight;

            menuScreen = new MenuScreen();
        }

        public static void ChangeWindowSize(int width, int height)
        {
            viewWidth = width;
            viewHeight = height;
            sizeChanged = true;
        }

        public static int ViewWidth() { return viewWidth; }
        public static int ViewHieght() { return viewHeight; }

        static void Main(string[] args)
        {
            //Setup gamewindow
            Initalize();

            //The game loop will be here, all Draw and Upadate mathods will be called from here
            //in the form of check input then update objects then draw screen
            while (true)
            {
                if (!isExiting)
                {
                    //Check keyboard inputs
                    if (Console.KeyAvailable == true)
                    {
                        //Update the keyboard input manage
                        Keyboard.Update();
                    }

                    //Update game objects
                    if (gameState == GameState.IntroState)
                    {

                    }
                    else if (gameState == GameState.MenuState)
                    {
                        menuScreen.Update();
                        if (gameState != GameState.MenuState)
                            switchingScreen = true;
                    }
                    else if (gameState == GameState.GamePlayState)
                    {

                    }
                    else if (gameState == GameState.GameOverState)
                    {
                        
                    }
                    else if (gameState == GameState.ScoreState)
                    {
                        
                    }

                    //Check if game swichingScreen
                    if (!switchingScreen)
                    {
                        //Draw game objects
                        if (gameState == GameState.IntroState)
                        {

                        }
                        else if (gameState == GameState.MenuState)
                        {
                            menuScreen.Draw();
                        }
                        else if (gameState == GameState.GamePlayState)
                        {

                        }
                        else if (gameState == GameState.GameOverState)
                        {

                        }
                        else if (gameState == GameState.ScoreState)
                        {

                        }
                    }
                    else
                    {
                        Console.Clear();
                    }
                    System.Threading.Thread.Sleep(16);
                    Keyboard.Clear();
                    sizeChanged = false;
                }
                else
                {
                    //exit -> Should show score screen?
                    Environment.Exit(0);
                }
            }
        }
    }
}
