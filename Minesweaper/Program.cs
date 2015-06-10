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
        //Game settings
        public static bool isExiting = false; //Weather the game is exiting
        public static bool switchingScreen = true; //Weather the screen is changing
        public static ConsoleColor backgroundColor = ConsoleColor.Black; //The current background color
        public static GameState gameState = GameState.IntroState; //The "state" of the game, used to see witch screen to draw
        public static bool sizeChanged = true; //Weather the window size has changed 
        public static Random rand = new Random(); //Random 
        public static Thread sound; //Sound Thread
        public static float lastLoopTime; //The time that the last game loop took to complete
        public static bool showDebug = false; //Weather or not to draw the debug screen
        public static bool gameWon = false; //Weather the player won the game
        
        //GameTime
        public static Stopwatch gameTime;

        //Screens
        private static IntroScreen introScreen;
        private static MenuScreen menuScreen;
        private static GameOptions gameOptionsScreen;
        private static GameScreen gameScreen;
        private static GameOverScreen gameOverScreen;
        private static HelpScreen helpScreen;
        private static HighscoreScreen highscoreScreen;

        private static int viewWidth = 105, viewHeight = 40; //The width and height of the game window

        /// <summary>Initalizes the game, setsup the screens</summary>
        private static void Initalize()
        {
            Console.SetWindowSize(viewWidth, viewHeight);
            Console.Title = "Minesweeper V0.87";
            Console.CursorVisible = false;
            Console.BufferWidth = viewWidth;
            Console.BufferHeight = viewHeight;
            gameTime = new Stopwatch();

            introScreen = new IntroScreen();
            menuScreen = new MenuScreen();
            gameOptionsScreen = new GameOptions();
            gameScreen = new GameScreen();
            gameOverScreen = new GameOverScreen();
            helpScreen = new HelpScreen();
            highscoreScreen = new HighscoreScreen();
        }

        /// <summary>Changes the size of the window sisze</summary>
        /// <param name="width">The width of the window in tiles</param>
        /// <param name="height">The height of the window in tiles</param>
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

        /// <summary>The main entry point of the game</summary>
        /// <param name="args">Starting args do nothing</param>
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
                System.Threading.Thread.Sleep(0);
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

            //Check keyboard inputs
            if (Console.KeyAvailable == true)
            {
                //Update the keyboard input manage
                Keyboard.Update();
            }

            //Update game objects
            if (gameState == GameState.IntroState)
            {
                introScreen.Update();

                if (gameState != GameState.IntroState)
                    switchingScreen = true;
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
            else if(gameState == GameState.HelpState)
            {
                helpScreen.Update();

                if (gameState != GameState.HelpState)
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
                gameOverScreen.Update();

                if (gameState != GameState.GameOverState)
                    switchingScreen = true;
            }
            else if (gameState == GameState.ScoreState)
            {
                highscoreScreen.Update();

                if (gameState != GameState.ScoreState)
                    switchingScreen = true;
            }

            //Debug Update
            DebugUtil.Update();

            //Debug keys
            if (Keyboard.IsKeyPressed(ConsoleKey.F12))
            {
                if (showDebug)
                    showDebug = false;
                else
                    showDebug = true;

                switchingScreen = true;
            }

            if (showDebug)
            {
                if (Keyboard.IsKeyPressed(ConsoleKey.F1))
                    switchingScreen = true;
                else if (Keyboard.IsKeyPressed(ConsoleKey.F2))
                    SetUpNewGame(BoardSettings.GetPresetData(BoardSize.Huge));
                else if (Keyboard.IsKeyPressed(ConsoleKey.F3) && gameState == GameState.GamePlayState)
                    gameScreen.GameBoard.ShowMines();
                else if (Keyboard.IsKeyPressed(ConsoleKey.F4) && gameState == GameState.GamePlayState)
                { 
                    //Save
                }
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
                    introScreen.Draw();
                }
                else if (gameState == GameState.MenuState)
                {
                    menuScreen.Draw();
                }
                else if (gameState == GameState.GameOptionState)
                {
                    gameOptionsScreen.Draw();
                }
                else if(gameState == GameState.HelpState)
                {
                    helpScreen.Draw();
                }
                else if (gameState == GameState.GamePlayState)
                {
                    gameScreen.Draw();
                }
                else if (gameState == GameState.GameOverState)
                {
                    gameOverScreen.Draw();
                }
                else if (gameState == GameState.ScoreState)
                {
                    highscoreScreen.Draw();
                }

                if (showDebug)
                {
                    DebugUtil.Draw();

                    //Only Mines
                    if (gameScreen.GameBoard != null)
                    {
                        if (gameState == GameState.GamePlayState)
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("Only mines left:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(gameScreen.GameBoard.IsClosedCellsMines().ToString() + "   ");
                        }
                    }
                }
            }
            else
            {
                Console.BackgroundColor = Program.backgroundColor;
                Console.Clear();
            }
        }

        /// <summary>Checks if the time that the player got is a better highscore</summary>
        /// <param name="minutes">The amount of minutes that the player took</param>
        /// <param name="seconds">The amount of seconds that the player took</param>
        /// <returns>True if the time is a new better time</returns>
        public static bool IsNewHighscore(int minutes, int seconds)
        {
            return false;
        }
         
        /// <summary>Adds a new high score to the list of highscores</summary>
        /// <param name="playerName">The name that the playe entered</param>
        /// <param name="minutes">The amount of minutes that the player took</param>
        /// <param name="seconds">The amount of seconds that the player took</param>
        public static void AddNewHighScore(string playerName, int minutes, int seconds)
        {
            highscoreScreen.AddNewHighSore(playerName, minutes, seconds);
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
        /// <param name="mins">The minutes that the game took</param>
        /// <param name="secs">The seconds that the game took</param>
        public static void SetupGameOverScreen(int mins, int secs)
        {
            gameOverScreen.SetupScreen(mins, secs);
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
