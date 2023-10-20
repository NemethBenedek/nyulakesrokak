using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulation
{
    class GameOfLifeSimulation
    {
        // Tagváltozók a rács, újRács, előzőRács, sorok, oszlopok és generáció számához
        private int rows;
        private int cols;
        private bool[,] grid;
        private bool[,] newGrid;
        private bool[,] prevGrid;
        private int generation;
        // Konstruktor a szimuláció inicializálásához rács méreteivel
        public GameOfLifeSimulation(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.grid = new bool[rows, cols];
            this.newGrid = new bool[rows, cols];
            this.prevGrid = new bool[rows, cols];
        }
        // Metódus a szimuláció futtatásához
        public void RunSimulation()
        {
            // A játékszimuláció vezérlése itt történik
            InitializeGrid(grid, rows, cols);

            int generationsWithoutChange = 0;
            while (generationsWithoutChange < 1)
            {
                Console.Clear();
                DisplayGrid(grid, rows, cols, prevGrid);
                UpdateGrid(grid, newGrid, prevGrid, rows, cols, generation);

                if (GenerationsEqual(grid, newGrid))
                {
                    generationsWithoutChange++;
                }
                else
                {
                    generationsWithoutChange = 0;
                }

                (grid, newGrid) = (newGrid, grid);
                generation++;
                Thread.Sleep(550);
            }
        }
        // Segédfüggvény a rács inicializálásához véletlenszerű élő/halott cellákkal
        private void InitializeGrid(bool[,] grid, int rows, int cols)
        {
            Random rand = new Random();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = rand.Next(2) == 0; // Véletlenszerűen élő vagy halott sejt
                }
            }
        }
        // Metódus a rács megjelenítéséhez színek alapján a cella állapotától függően
        private void DisplayGrid(bool[,] grid, int rows, int cols, bool[,] prevGrid)
        {
            // Iterálunk minden cellán
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Háttérszín beállítása a cella állapotától függően
                    ConsoleColor backgroundColor = grid[row, col] ? ConsoleColor.Green : ConsoleColor.Red;
                    // Ha a cella állapota nem változott az előző generációban, más színt állítunk be
                    if (grid[row, col] == prevGrid[row, col])
                    {
                        backgroundColor = ConsoleColor.DarkYellow; // Ha a mező nem változik 2 körön belül, akkor narancssárga
                    }
                    // Beállítjuk a konzol színét és megjelenítjük a cellát
                    Console.BackgroundColor = backgroundColor;
                    Console.Write("  ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private void UpdateGrid(bool[,] grid, bool[,] newGrid, bool[,] prevGrid, int rows, int cols, int generation)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int neighbors = CountLivingNeighbors(grid, row, col, rows, cols);

                    if (grid[row, col])
                    {
                        if (neighbors < 2 || neighbors > 3)
                        {
                            newGrid[row, col] = false; // Az élő sejt meghal
                        }
                        else
                        {
                            newGrid[row, col] = true; // Az élő sejt életben marad
                        }
                    }
                    else
                    {
                        if (neighbors == 3)
                        {
                            newGrid[row, col] = true; // A halott sejt újjászületik
                        }
                        else
                        {
                            newGrid[row, col] = false; // A halott sejt halott marad
                        }
                    }
                }
            }

            if (generation > 1)
            {
                Array.Copy(grid, prevGrid, grid.Length); // Az előző generáció rácsának másolása
            }
        }
        // Metódus a szomszédos élő sejtek számának kiszámításához egy adott cellában
        private int CountLivingNeighbors(bool[,] grid, int row, int col, int rows, int cols)
        {
            int count = 0;
            // Iterálás a szomszédos cellákon
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // Kihagyjuk a jelenlegi cellát
                    if (i == 0 && j == 0)
                        continue;
                    // Számoljuk a szomszéd koordinátáit
                    int neighborRow = row + i;
                    int neighborCol = col + j;
                    // Ellenőrizzük, hogy a szomszéd a rács határain belül van-e
                    if (neighborRow >= 0 && neighborRow < rows && neighborCol >= 0 && neighborCol < cols)
                    {
                        // Ha a szomszéd él, növeljük a számot
                        if (grid[neighborRow, neighborCol])
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private bool GenerationsEqual(bool[,] grid1, bool[,] grid2)
        {
            for (int row = 0; row < grid1.GetLength(0); row++)
            {
                for (int col = 0; col < grid1.GetLength(1); col++)
                {
                    if (grid1[row, col] != grid2[row, col])
                    {
                        return false; // Változás történt
                    }
                }
            }
            return true; // Nincs változás
        }
    }
}