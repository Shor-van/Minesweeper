using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Utils;
using Minesweeper.Screens;
using System.Threading;
using System.Diagnostics;
using Minesweeper.GameBoard;

namespace Minesweeper
{
    public enum GameState
    {
        IntroState,
        MenuState,
        GameOptionState,
        GamePlayState,
        GameOverState,
        ScoreState,
        HelpState,
        CustomSettingState,
    }

    class Program
    {
        public static bool isExiting = false; //Weather the game is exiting
        public static bool switchingScreen = false; //Weather the screen is changing
        public static ConsoleColor backgroundColor = ConsoleColor.Black; //The current background color
        public static GameState gameState = GameState.MenuState; //The "state" of the game, used to see witch screen to draw
        public static bool sizeChanged = true; //Weather the window size has changed 
        public static Random rand = new Random(); //Random 
        public static Thread sound; //Sound Thread
        public static float lastLoopTime; //The time that the last game loop took to complete
        public static bool showDebug = false; //Weather or not to draw the debug screen
        public static bool gameWon = false; //Weather the player won the game
        
        //GameTime
        public static Stopwatch gameTime;

        //Screens
        private static MenuScreen menuScreen;
        private static GameOptions gameOptionsScreen;
        private static GameScreen gameScreen;
        private static GameOverScreen gameOverScreen;

        private static int viewWidth = 100, viewHeight = 34;

        private static void Initalize()
        {
            Console.SetWindowSize(viewWidth, viewHeight);
            Console.Title = "Minesweeper V0.53";
            Console.CursorVisible = false;
            Console.BufferWidth = viewWidth;
            Console.BufferHeight = viewHeight;
            gameTime = new Stopwatch();

            menuScreen = new MenuScreen();
            gameOptionsScreen = new GameOptions();
            gameScreen = new GameScreen();
            gameOverScreen = new GameOverScreen();
        }

        public static void ChangeWindowSize(int width, int height)
        {
            viewWidth = width;
            viewHeight = height;
            
            Console.SetWindowSize(viewWidth, viewHeight);
            Console.BufferWidth = viewWidth;
            Console.BufferHeight = viewHeight;

            sizeChanged = true;
        }

        public static int ViewWidth() { return viewWidth; }
        public static int ViewHieght() { return viewHeight; }

        static void Main(string[] args)
        {
            try
            {
                //Setup gamewindow
                Initalize();

                //The game loop will be here, all Draw and Upadate mathods will be called from here
                //in the form of check input then update objects then draw screen
                while (true)
                {
                    GameLoop();
                }
            }
            catch (Exception e)
            {
                CrashReporter.CreateCrashReport(e, new string[] { "This crash heppened in a area that was not monitored." });
            }
        }

        /// <summary>The main game loop, Update -> Draw -> Reset</summary>
        private static void GameLoop()
        {
            gameTime.Restart();
            if (!isExiting)
            {
                //Update
                Update();

                //Draw
                Draw();

                //Reset
                Keyboard.Clear();
                sizeChanged = false;
            }
            else
            {
                //exit -> Should show score screen?
                Environment.Exit(0);
            }
            lastLoopTime = (float)gameTime.Elapsed.TotalMilliseconds;
        }

        /// <summary>The Update stage of the loop, only the current screen is updated witch is determined by the GameState</summary>
        private static void Update()
        {
            DebugUtil.Update();

            //Check keyboard inputs
            if (Console.KeyAvailable == true)
            {
                //Update the keyboard input manage
                Keyboard.Update();
            }

            if (Keyboard.IsKeyPressed(ConsoleKey.F2))
            {
                if (showDebug)
                    showDebug = false;
                else
                    showDebug = true;
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
            else if(gameState == GameState.GameOptionState)
            {
                gameOptionsScreen.Update();
                
                if (gameState != GameState.GameOptionState)
                    switchingScreen = true;
            }
            else if (gameState == GameState.GamePlayState)
            {
                gameScreen.Update();
                
                if (gameState != GameState.GamePlayState)
                    switchingScreen = true;
            }
            else if (gameState == GameState.GameOverState)
            {

            }
            else if (gameState == GameState.ScoreState)
            {

            }
            
        }

        /// <summary>The Draw stage of the loop,  only the current screen is drawn witch is determined by the GameState</summary>
        private static void Draw()
        {
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
                else if (gameState == GameState.GameOptionState)
                {
                    gameOptionsScreen.Draw();
                }
                else if (gameState == GameState.GamePlayState)
                {
                    gameScreen.Draw();
                }
                else if (gameState == GameState.GameOverState)
                {

                }
                else if (gameState == GameState.ScoreState)
                {

                }

                if(showDebug)
                    DebugUtil.Draw();
            }
            else
            {
                Console.Clear();
            }
        }

        /// <summary>Sets up a new game</summary>
        /// <param name="settings">A BoardSettings object defining how to setup the board</param>
        public static void SetUpNewGame(BoardSettings settings)
        {
            gameScreen.SetupGameBoard(settings);
            gameState = GameState.GamePlayState;
            switchingScreen = true;            
        }

        /// <summary> Sets up the game over screen based on weather the player won the game</summary>
        public static void SetupGameOverScreen()
        {
            gameOverScreen.SetupScreen();
            gameState = GameState.GameOverState;
            switchingScreen = true;
        }

        /// <summary>Generates a random number smaller the spessifed max but greater or equal to the spesifed min</summary>
        /// <param name="min">The minimu that the number can be</param>
        /// <param name="max">The max that the number is smaller then</param>
        /// <returns>A intager greater or equal to the min and smaller then the max</returns>
        public static int GenerateRandom(int min, int max)
        {
            return rand.Next(min, max);
        }

        /// <param name="min">The minimu that the number can be</param>
        /// <param name="max">The max that the number is smaller then</param>
        /// <returns>A intager greater or equal to the min and smaller then the max</returns>
        public static double GenerateRandom(float min, float max)
        {
            return min + (rand.NextDouble() * (max - min));
        }
    }
}
