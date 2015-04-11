using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweaper.Screens.UI;
using Minesweaper.Utils;

namespace Minesweaper.Screens
{
	public class MenuScreen
	{
        private List<MenuText> options; //The options in the menu
        private Arrow selectionArrow; //Arrow showing current selection
        private int selection; //The currectly selected option in the list 
        private TitleText tile; //The tile of the menu

        /// <summary>Initsalize the menu</summary>
        public MenuScreen()
        {
            tile = new TitleText("MINESWEEPER",ConsoleColor.Red,0,0);

            options = new List<MenuText>();
            options.Add(new MenuText("Play Game", 7, 10));
            options.Add(new MenuText("How To Play", 8, 10));
            options.Add(new MenuText("Quit Game", 9, 10));

            //Register event handlers
            options[0].Selected += new MenuText.BaseEventHandler(OnPlayGameSelected);
            options[1].Selected += new MenuText.BaseEventHandler(OnHelpSelected);
            options[2].Selected += new MenuText.BaseEventHandler(OnQuitSelected);

            selectionArrow = new Arrow(ConsoleColor.Yellow, 0, 0, false);

            selection = 0;
        }

        //event handlers
        private void OnPlayGameSelected(object sender, EventArgs e)
        {

        }

        private void OnHelpSelected(object sender, EventArgs e)
        {

        }

        private void OnQuitSelected(object sender, EventArgs e)
        {
            Program.isExiting = true;
        }

        /// <summary>Updates the menu, updates currently selected opytion</summary>
        public void Update()
        {
            Program.switchingScreen = false;

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
            selectionArrow.Update(options[selection].PositionX, options[selection].PositionY - 2);
        }

        /// <summary>Draws the menu, option list, title</summary>
        public void Draw()
        {
            tile.Draw();
            selectionArrow.Draw();

            foreach (MenuText option in options)
                option.Draw();
        }
	}
}
