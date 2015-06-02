using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Utils;

namespace Minesweeper.GameBoard
{
    /// <summary>Preset board sizes</summary>
    public enum BoardSize
    {
        Small,
        Medium,
        Large,
        Huge
    }
    public class Board
    {
        private Cell[,] cells; //The cells of the board
        private int sizeX, sizeY; //The menrer of cells on the x and y axis that the board has
        private int posX, posY; //The top left location of the board on the screen
        private int selX, selY; //The x and y cell that the player is selecting
        private List<CellToOpen> cellsToOpen; //A list of cells to be open in the next loop
        private bool mineTriggered = false; //Weather the player hit a mine

        //Gets and sets
        public Cell[,] Cells { get { return cells; } set { cells = value; } }
        public int PositionX { get { return posX; } set { posX = value; } }
        public int PositionY { get { return posY; } set { posY = value; } }
        public bool MineTriggered { get { return mineTriggered; } }

        /// <summary>Main constructor</summary>
        /// <param name="posX">The top location on the screen at witch to draw the gameboard</param>
        /// <param name="posY">The left location on the screen at witch to draw the gameboard</param>
        /// <param name="settings">A BoardSettings object containing information on how to create the board</param>
        public Board(int posX, int posY, BoardSettings settings)
        {
            //Base settings
            this.posX = posX;
            this.posY = posY;
            this.selX = settings.Width / 2;
            this.selY = settings.Height / 2;
            this.sizeX = settings.Width;
            this.sizeY = settings.Height;
            cellsToOpen = new List<CellToOpen>();

            //Cells
            cells = new Cell[settings.Width, settings.Height];

            //Create cells
            int xShift = 0, yShift = 0;
            for (int x = 0; x < settings.Width; x++)
            {
                for (int y = 0; y < settings.Height; y++)
                {
                    cells[x, y] = new Cell(posX + xShift, posY + yShift, this, false);
                    yShift += 1;
                }
                xShift += 3;
                yShift = 0;
            }

            //Add mimes
            int mines = Program.GenerateRandom(settings.MinMines, settings.MaxMines);
            for (int i = 0; i < mines; i++)
            {
                int x = Program.GenerateRandom(0, settings.Width);
                int y = Program.GenerateRandom(0, settings.Height);

                while (cells[x, y].IsMine)
                {
                    x = Program.GenerateRandom(0, settings.Width);
                    y = Program.GenerateRandom(0, settings.Height);
                }

                cells[x, y].IsMine = true;
            }
        }

        /// <summary>Overload constructor</summary>
        /// <param name="posX">The top location on the screen at witch to draw the gameboard</param>
        /// <param name="posY">The left location on the screen at witch to draw the gameboard</param>
        /// <param name="sizeX">The size of the cell grid on the X axis</param>
        /// <param name="sizeY">The size of the cell grid on the Y axis</param>
        /// <param name="maxMines">The max number of mines that the grid can have</param>
        /// <param name="minMines">The min number of mines that the grid can have</param>
        public Board(int posX, int posY, int sizeX, int sizeY, int minMines, int maxMines)
        {
            //Base settings
            this.posX = posX;
            this.posY = posY;
            this.selX = sizeX / 2;
            this.selY = sizeY / 2;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            cellsToOpen = new List<CellToOpen>();

            //Cells
            cells = new Cell[sizeX, sizeY];

            //Create cells
            int xShift = 0, yShift = 0;
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    cells[x, y] = new Cell(posX + xShift, posY + yShift, this, false);
                    yShift += 1;
                }
                xShift += 3;
                yShift = 0;
            }

            //Add mimes
            int mines = Program.GenerateRandom(minMines, maxMines);
            for (int i = 0; i < mines; i++)
            {
                int x = Program.GenerateRandom(0, sizeX);
                int y = Program.GenerateRandom(0, sizeY);

                while (cells[x, y].IsMine)
                {
                    x = Program.GenerateRandom(0, sizeX);
                    y = Program.GenerateRandom(0, sizeY);
                }

                cells[x, y].IsMine = true;
            }
        }

        /// <summary>Checks if the only cellls that are not open are mines</summary>
        /// <returns>True if the only cells that are not open are mines</returns>
        public bool IsClosedCellsMines()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (cells[x, y].IsMine == false && cells[x, y].IsOpen == false)
                        return false;
                    else if (cells[x, y].IsMine == true && cells[x, y].IsOpen == true)
                        return false;
                }
            }
            return true;
        }

        /// <summary>Opens the cell at the x and y location, if cell has no mines near it connected cells are opened</summary>
        /// <param name="x">The x location of the cell in the array</param>
        /// <param name="y">The y location of the cell in the array</param>
        public void OpenCell(int x, int y)
        {
            if (IsInBounds(x, y))
            {
                cells[x, y].IsOpen = true;

                //Ceck if is not mine
                if (cells[x, y].IsMine != true)
                {
                    //Get number of mines around
                    int mines = GetNumberOfMinesAround(x, y);

                    //if no mines near open connected cells
                    if (mines == 0)
                    {
                        cells[x, y].Text = " ";
                        if (IsInBounds(x, y - 1) && cells[x, y - 1].IsOpen == false)
                        {
                            if(!IsCellScheduledToBeOpened(cells[x, y - 1]))
                                cellsToOpen.Add(new CellToOpen(cells[x, y - 1], x, y - 1));
                        }
                        if (IsInBounds(x + 1, y) && cells[x + 1, y].IsOpen == false)
                        {
                            if (!IsCellScheduledToBeOpened(cells[x + 1, y]))
                                cellsToOpen.Add(new CellToOpen(cells[x + 1, y], x + 1, y));
                        }
                        if (IsInBounds(x, y + 1) && cells[x, y + 1].IsOpen == false)
                        {
                            if (!IsCellScheduledToBeOpened(cells[x, y + 1]))
                                cellsToOpen.Add(new CellToOpen(cells[x, y + 1], x, y + 1));
                        }
                        if (IsInBounds(x - 1, y) && cells[x - 1, y].IsOpen == false)
                        {
                            if (!IsCellScheduledToBeOpened(cells[x - 1, y]))
                                cellsToOpen.Add(new CellToOpen(cells[x - 1, y], x - 1, y));
                        }
                    }
                    else
                    {
                        cells[x, y].Text = mines.ToString();
                    }
                }
                else
                {
                    //BOOM
                    mineTriggered = true;
                    return;
                }

                //Re-Draw
                if (selX == x && selY == y)
                    cells[x, y].Draw(true);
                else
                    cells[x, y].Draw(false);
            }
        }

        /// <summary>Calls OpenCell(int x, int y) for the cells in the list cellsToOpen</summary>
        private void OpenScheduledCells()
        {
            //Copy over list into a working list
            List<CellToOpen> tmpList = cellsToOpen.ToList();
            cellsToOpen.Clear(); //Clear list

            foreach (CellToOpen cell in tmpList)
            {
                OpenCell(cell.TileX, cell.TileY);
            }
        }

        /// <summary>Checks if the spesifed cell is in the list cellsToOpen</summary>
        /// <param name="cell">The cell to check</param>
        /// <returns>True if the cell is in the list else false</returns>
        public bool IsCellScheduledToBeOpened(Cell cell)
        {
            foreach (CellToOpen celltoOpen in cellsToOpen)
            {
                if (celltoOpen.IsCell(cell))
                    return true;
            }
            return false;
        }

        /// <summary> Gets the number of mines around the cell</summary>
        /// <param name="x">The X location of the cell in the array</param>
        /// <param name="y">The Y location of thecell in the array</param>
        /// <returns>The number of mines aroun the cell</returns>
        public int GetNumberOfMinesAround(int x, int y)
        {
            int mines = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (IsInBounds(i, j) == true)
                    {
                        if (i == x && j == y)
                            continue;

                        if (cells[i, j].IsMine == true)
                            mines++;
                    }
                }
            }
            return mines;
        }

        /// <summary>Gets the number of mines on the board</summary>
        /// <returns>The number of mines on the board</returns>
        public int GetNumberOfMines()
        {
            int mines = 0;
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (cells[x, y].IsMine == true)
                        mines++;
                }
            }
            return mines;
        }

        /// <summary>Gets the x and y location of the cell in the array</summary>
        /// <param name="cell">The cell in belonging to this board</param>
        /// <returns>Array containing the x and y tile location of the cell in the board </returns>
        public int[] GetLocationInArray(Cell cell)
        {
            //Do check if Cell board is this
            //Loop through cells
            //Chech if currrect cell loop is cell
            //return array x y
            return null;
        }

        /// <summary>Shows all the cells that are mines</summary>
        public void ShowMines()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (cells[x, y].IsMine == true)
                        cells[x, y].Text = "M";

                    cells[x, y].Draw();
                }
            }
        }

        /// <summary>Checks if the spesified X and Y location is in the bounds of the cell grid</summary>
        /// <param name="x">The X location</param>
        /// <param name="y">The Y location</param>
        /// <returns>True if the location is in the cell grid else false</returns>
        public bool IsInBounds(int x, int y)
        {
            if (x >= 0 && x < sizeX && y >= 0 && y < sizeY)
                return true;
            return false;
        }

        /// <summary>Updates the board</summary>
        public void Update()
        {
            OpenScheduledCells();
            UpdatePlayerInput();
        }

        /// <summary>Checks if the player moved the selection area</summary>
        private void UpdatePlayerInput()
        {
            //WASD - movment 
            if (Keyboard.IsKeyPressed(ConsoleKey.W))
            {
                if (selY - 1 >= 0)
                    selY--;

                //Re-Draw cells
                cells[selX, selY + 1].Draw(false);
                cells[selX, selY].Draw(true);
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.S))
            {
                if (selY + 1 < sizeY)
                    selY++;

                //Re-Draw cells
                cells[selX, selY - 1].Draw(false);
                cells[selX, selY].Draw(true);
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.A))
            {
                if (selX - 1 >= 0)
                    selX--;

                //Re-Draw cells
                cells[selX + 1, selY].Draw(false);
                cells[selX, selY].Draw(true);
            }
            else if (Keyboard.IsKeyPressed(ConsoleKey.D))
            {
                if (selX + 1 < sizeX)
                    selX++;

                //Re-Draw cells
                cells[selX - 1, selY].Draw(false);
                cells[selX, selY].Draw(true);
            }

            //Open cell
            else if (Keyboard.IsKeyPressed(ConsoleKey.Enter))
            {
                if(cells[selX, selY].Text != "F" && cells[selX, selY].Text != "?")
                    OpenCell(selX, selY);
            }

            //Mark cell
            else if (Keyboard.IsKeyPressed(ConsoleKey.E))
            {
                if (cells[selX, selY].IsOpen == false)
                {
                    if (cells[selX, selY].Text == "_")
                        cells[selX, selY].Text = "F";
                    else if (cells[selX, selY].Text == "F")
                        cells[selX, selY].Text = "?";
                    else if (cells[selX, selY].Text == "?")
                        cells[selX, selY].Text = "_";

                    cells[selX, selY].Draw(true);
                }
            }
        }

        /// <summary>Draws the game board</summary>
        public void Draw()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (selX == x && selY == y)
                        cells[x, y].Draw(true);
                    else
                        cells[x, y].Draw();
                }
            }
        }
    }
}
