using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Screens.UI;
using Minesweeper.Utils;

namespace Minesweeper.Screens
{
	public class MenuScreen
	{
        private List<MenuText> options; //The options in the menu
        private Arrow selectionArrow; //Arrow showing current selection
        private int selection; //The currectly selected option in the list 
        private TitleText tile; //The tile of the menu
        private SplashText splashText; //The splash text under the tile

        //Labels
        private TextLabel version; //The version of the game
        private TextLabel controls; //Shows how to use the menu
        private TextLabel shorvan; //Me

        /// <summary>Initsalize the menu</summary>
        public MenuScreen()
        {
            //Tile
            tile = new TitleText("MINESWEEPER",ConsoleColor.Red,0,2);
            splashText = new SplashText(0, 0, ConsoleColor.Cyan);

            //Options
            options = new List<MenuText>();
            options.Add(new MenuText("Play Game", 10,7));
            options.Add(new MenuText("How To Play", 10, 8));
            options.Add(new MenuText("Quit Game", 10, 9));

            //Labels
            version = new TextLabel(Console.Title,0,0,ConsoleColor.Cyan);
            controls = new TextLabel("W: move up, S: move down, Enter: select", 0, 0, ConsoleColor.Gray);
            shorvan = new TextLabel("By Shor_van", 0, 0, ConsoleColor.Cyan);

            //Register event handlers
            options[0].Selected += new MenuText.BaseEventHandler(OnPlayGameSelected);
            options[1].Selected += new MenuText.BaseEventHandler(OnHelpSelected);
            options[2].Selected += new MenuText.BaseEventHandler(OnQuitSelected);

            selectionArrow = new Arrow(ConsoleColor.Yellow, 0, 0, false);

            selection = 0;
        }

        /// <summary>In the future things that are drawn once like the tile and the labels will bee drawn here</summary>
        public void SetupScreen()
        {

        }

        //event handlers
        private void OnPlayGameSelected(object sender, EventArgs e)
        {
            Program.gameState = GameState.GameOptionState;
            return;
        }

        private void OnHelpSelected(object sender, EventArgs e)
        {
            Program.gameState = GameState.HelpState;
            return;
        }

        private void OnQuitSelected(object sender, EventArgs e)
        {
            Program.isExiting = true;
        }

        /// <summary>Updates the menu, updates currently selected opytion</summary>
        public void Update()
        {
            if (Program.switchingScreen)
            {
                selection = 0;
                splashText.GenerateNewSplashText();
            }

            Program.switchingScreen = false;

            if (Program.sizeChanged)
            {
                //Recalulate positions
                options[0].PositionX = (Program.ViewWidth() / 2) - (options[0].MeasureSize()[0] / 2);
                options[1].PositionX = (Program.ViewWidth() / 2) - (options[1].MeasureSize()[0] / 2);
                options[2].PositionX = (Program.ViewWidth() / 2) - (options[2].MeasureSize()[0] / 2);

                options[0].PositionY = (Program.ViewHieght() / 2) -  3;
                options[1].PositionY = (Program.ViewHieght() / 2) - 2;
                options[2].PositionY = (Program.ViewHieght() / 2) - 1;

                //Tile
                tile.PositionX = (Program.ViewWidth() / 2 - (tile.MeasureSize())[0] / 2);
                tile.PositionY = 2;

                //Splash
                splashText.PositionX = Program.ViewWidth() / 2;
                splashText.PositionY = tile.PositionY + (tile.MeasureSize()[1]);

                //Labels
                version.PositionX = 1;
                version.PositionY = Program.ViewHieght() - 1;

                controls.PositionX = (Program.ViewWidth() / 2) - (controls.MeasureSize()[0] / 2);
                controls.PositionY = Program.ViewHieght() - 1;

                shorvan.PositionX = ((Program.ViewWidth()-1) - shorvan.MeasureSize()[0]);
                shorvan.PositionY = Program.ViewHieght() - 1;
            }

            splashText.Update();

            //Update selection
            if (Keyboard.IsKeyPressed(ConsoleKey.W))
            {
                if (selection == 0)
                    selection = options.Count - 1;
                else
                    selection--;
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.S))
            {
                if (selection == options.Count - 1)
                    selection = 0;
                else
                    selection++;
            }

            //Update core menu
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selection)
                    options[selection].Active = true;
                else
                    options[i].Active = false;

                options[i].Update();
            }

            //Update arrow
            selectionArrow.Update(options[selection].PositionX-3, options[selection].PositionY);
        }

        /// <summary>Draws the menu, option list, title</summary>
        public void Draw()
        {
            //Tile
            tile.Draw();
            splashText.Draw();

            //Menu
            selectionArrow.Draw();
            foreach (MenuText option in options)
                option.Draw();

            //Labels
            version.Draw();
            controls.Draw();
            shorvan.Draw();
        }
	}
}
