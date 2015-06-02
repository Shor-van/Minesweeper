using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Screens.UI;
using Minesweeper.Utils;
using Minesweeper.GameBoard;

namespace Minesweeper.Screens
{
    public class GameOptions
    {
        private List<MenuText> options; //Small, medium, large, and custom options
        private Arrow arrow; //The arrow used in the menu
        private TitleText tile; //The tile of the screen "Play Game"
        private int selection; //The currently selected option

        //Labels
        private TextLabel lblSelect; //Label saying that the player should choose a option
        private TextLabel controls; //Label that show how to use the menu

        /// <summary>Initsalize the menu</summary>
        public GameOptions()
        {
            //Tile
            tile = new TitleText("PLAY GAME",ConsoleColor.Red,0,0);

            //Option
            options = new List<MenuText>();
            options.Add(new MenuText("Small Board", 0, 0));
            options.Add(new MenuText("Medium Board", 0, 0));
            options.Add(new MenuText("Large Board", 0, 0));
            options.Add(new MenuText("Custom Board", 0, 0));

            //Labels
            lblSelect = new TextLabel("Choose a board size...", 0, 0, ConsoleColor.Cyan);
            controls = new TextLabel("Enter: select, W: move up, S: move down, ESC: back", 0, 0, ConsoleColor.White);

            //Register event handlers
            options[0].Selected += new MenuText.BaseEventHandler(OnSmallSelected);
            options[1].Selected += new MenuText.BaseEventHandler(OnMediumSelected);
            options[2].Selected += new MenuText.BaseEventHandler(OnLargeSelected);
            options[3].Selected += new MenuText.BaseEventHandler(OnCustomSelected);

            options[3].Enable = false;

            arrow = new Arrow(ConsoleColor.Yellow, 0, 0, false);

            selection = 0;

            RecculatePositions();
        }

        /// <summary>Recalculates all the positions of the UI objects</summary>
        public void RecculatePositions()
        {
            //Recalulate positions
            options[0].PositionX = (Program.ViewWidth() / 2) - (options[0].MeasureSize()[0] / 2);
            options[1].PositionX = (Program.ViewWidth() / 2) - (options[1].MeasureSize()[0] / 2);
            options[2].PositionX = (Program.ViewWidth() / 2) - (options[2].MeasureSize()[0] / 2);
            options[3].PositionX = (Program.ViewWidth() / 2) - (options[3].MeasureSize()[0] / 2);

            options[0].PositionY = (Program.ViewHieght() / 2) - 3;
            options[1].PositionY = (Program.ViewHieght() / 2) - 2;
            options[2].PositionY = (Program.ViewHieght() / 2) - 1;
            options[3].PositionY = (Program.ViewHieght() / 2);

            //Tile
            tile.PositionX = (Program.ViewWidth() / 2 - (tile.MeasureSize())[0] / 2);
            tile.PositionY = 2;

            //labels
            lblSelect.PositionX = (Program.ViewWidth() / 2) - (lblSelect.MeasureSize()[0] / 2);
            lblSelect.PositionY = ((tile.PositionY + tile.MeasureSize()[1]) + 3);
            controls.PositionX = (Program.ViewWidth() / 2) - (controls.MeasureSize()[0] / 2);
            controls.PositionY = Program.ViewHieght() - 1;
        }

        /// <summary>Draws objects that should only be drawn when the games switchs to this screen</summary>
        public void DrawOnce()
        {

        }

        //Venet Handlers
        private void OnSmallSelected(object sender, EventArgs e)//Setup board with small settkings
        {
            Program.SetUpNewGame(BoardSettings.GetPresetData(BoardSize.Small));
            return;
        }

        private void OnMediumSelected(object sender, EventArgs e)//Setupo board with medium settings
        {
            Program.SetUpNewGame(BoardSettings.GetPresetData(BoardSize.Medium));
            return;
        }

        private void OnLargeSelected(object sender, EventArgs e)//Setup board with large settings
        {
            Program.SetUpNewGame(BoardSettings.GetPresetData(BoardSize.Large));
            return;
        }

        private void OnCustomSelected(object sender, EventArgs e)//Switch to custom settings screen
        {
            Program.gameState = GameState.CustomSettingState;
            return;
        }

        /// <summary>Updates the menu, updates currently selected opytion</summary>
        public void Update()
        {
            if (Program.switchingScreen)
            {
                selection = 0;
            }

            if (Program.sizeChanged || Program.switchingScreen == true)
            {
                Program.backgroundColor = ConsoleColor.Black;

                RecculatePositions();
                DrawOnce();
            }

            Program.switchingScreen = false;

            //Keyboard imput
            if (Keyboard.IsKeyPressed(ConsoleKey.W))
            {
                if (selection == 0)
                    selection = options.Count - 1;
                else
                    selection--;

                //if not enabled
                if (options[selection].Enable != true)
                {
                    if (selection == 0)
                        selection = options.Count - 1;
                    else if (selection == options.Count - 1)
                        selection = 0;
                    else
                        selection--;
                }
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.S))
            {
                if (selection == options.Count - 1)
                    selection = 0;
                else
                    selection++;

                //if not enabled
                if (options[selection].Enable != true)
                {
                    if (selection == 0)
                        selection = options.Count - 1;
                    else if (selection == options.Count - 1)
                        selection = 0;
                    else
                        selection++;
                }
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.Escape))
            {
                Program.gameState = GameState.MenuState;
                return;
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
            arrow.Update(options[selection].PositionX - 3, options[selection].PositionY);
        }

        /// <summary>Draws the menu, option list, title</summary>
        public void Draw()
        {
            //Tile
            tile.Draw();

            //Menu
            arrow.Draw();
            foreach (MenuText option in options)
                option.Draw();

            //Labels
            lblSelect.Draw();
            controls.Draw();
        }
    }
}
