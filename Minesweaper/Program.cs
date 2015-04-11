using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweaper
{
    public enum GameState
    {
        IntroState,
        MenuState,
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

        static void Main(string[] args)
        {
            //Setup gamewindow

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
                    }

                    //Update game objects
                    if (gameState == GameState.IntroState)
                    {
                    }
                    else if (gameState == GameState.MenuState)
                    {
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
