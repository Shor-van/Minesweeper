using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Screens.UI
{
    public class LogoAnimation
    {
        private float timeBetweenFrames; //The amount of time that needs to pass between frames
        private int currentFrame; //The current frame
        private int animStage; //The Stage of the animations
        private int centerleft; //The left center of the animation
        private int centerTop; //The top center of the animation
        private bool animComplete; //Weather the animation is complete
        private float elepsedTime; //The time that has elepsed

        //Gets amd sets
        public bool AnimComplete { get { return animComplete; } }

        /// <summary>Base constructor, Creates a new logo animation object that will draw the intro animation</summary>
        /// <param name="centerLeft">The left center of the animation</param>
        /// <param name="centerTop">The top center of the animation</param>
        /// <param name="timeBetweenFrames">The time to wait between frames, in ms</param>
        public LogoAnimation(int centerLeft, int centerTop, float timeBetweenFrames)
        {
            this.centerleft = centerleft;
            this.centerTop = centerTop;
            this.timeBetweenFrames = timeBetweenFrames;
        }

        /// <summary>Moves the animation one frame foward based on the time between frames</summary>
        public void Update()
        {
            if (currentFrame < 35)
                animStage = 1;
            else if (currentFrame < 60)
                animStage = 2;
            else if (currentFrame < 64)
                animStage = 3;
            else
                animComplete = true;

            if (animComplete == false)
            {
                elepsedTime += Program.lastLoopTime;
                if (elepsedTime >= timeBetweenFrames)
                {
                    currentFrame++;
                    elepsedTime = 0;
                }
            }
        }

        /// <summary>Draws the current frame of the animation</summary>
        public void Draw()
        {

        }

        /// <summary>Anim Test</summary>
        /// <param name="top"></param>
        public void RanderLogoAnim(int top)
        {
            if (animStage == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0 + currentFrame, top + i);
                    Console.Write("█");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(99 - currentFrame, top + 8 + i);
                    Console.Write("█");
                    Console.BackgroundColor = Program.backgroundColor;
                }
            }
            if (animStage == 2)
            {                
                System.Threading.Thread.Sleep((int)timeBetweenFrames); //This needs to sleep the same time between frames?????
                Console.MoveBufferArea(0 + (currentFrame - 35), top, 36, 4, (currentFrame - 35) + 1, top);
                Console.MoveBufferArea(64 - (currentFrame - 35), top + 8, 36, 4, (64 - (currentFrame - 35)) - 1, top + 8);
            }
            if (animStage == 3)
            {
                Console.BackgroundColor = Program.backgroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(26 + (currentFrame - 61), top);
                Console.Write(" ");
                Console.SetCursorPosition(26 + (currentFrame - 61), top + 1);
                Console.Write(" ");
                Console.SetCursorPosition(26 + (currentFrame - 61), top + 2);
                Console.Write(" ");
                Console.SetCursorPosition(26 + (currentFrame - 61), top + 3);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(54, top + 4 + (currentFrame - 61));
                Console.Write("████████");
                Console.BackgroundColor = Program.backgroundColor;
                Console.ForegroundColor = Program.backgroundColor;
                Console.SetCursorPosition(73 - (currentFrame - 61), top + 8);
                Console.Write(" ");
                Console.SetCursorPosition(73 - (currentFrame - 61), top + 8 + 1);
                Console.Write(" ");
                Console.SetCursorPosition(73 - (currentFrame - 61), top + 8 + 2);
                Console.Write(" ");
                Console.SetCursorPosition(73 - (currentFrame - 61), top + 8 + 3);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(38, top + 7 - (currentFrame - 61));
                Console.Write("████████");
            }
            Console.BackgroundColor = Program.backgroundColor;
        }
    }
}
