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
        ScoreState
    }

    class Program
    {
        public static bool isExiting = false;
        public static bool switchingScreen = false;
        public static ConsoleColor backgroundColor = ConsoleColor.Black;
        public static GameState gameState = GameState.MenuState; 

        //Screens
        private static MenuScreen menuScreen;

        private static void Initalize()
        {
            Console.SetWindowSize(100, 34);
            Console.Title = "Minesweeper V0.01";
            Console.CursorVisible = false;
            Console.BufferWidth = 100;
            Console.BufferHeight = 34;

            menuScreen = new MenuScreen();
        }

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
                    Keyboard.Clear();
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
