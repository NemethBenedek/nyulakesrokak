using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulation
{
    class GameOfLifeSimulation
    {
        private int rows;
        private int cols;
        private bool[,] grid;
        private bool[,] newGrid;
        private bool[,] prevGrid;
        private int generation;

        public GameOfLifeSimulation(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.grid = new bool[rows, cols];
            this.newGrid = new bool[rows, cols];
            this.prevGrid = new bool[rows, cols];
        }

        public void RunSimulation()
        {
            InitializeGrid(grid, rows, cols);

            int generationsWithoutChange = 0;
            while (generationsWithoutChange < 1)
            {
                Console.Clear();
                DisplayGrid(grid, rows, cols, prevGrid);
               

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

        private void InitializeGrid(bool[,] grid, int rows, int cols)
        {
            Random rand = new Random();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = rand.Next(2) == 0;
                }
            }
        }

        private void DisplayGrid(bool[,] grid, int rows, int cols, bool[,] prevGrid)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    ConsoleColor backgroundColor = grid[row, col] ? ConsoleColor.Green : ConsoleColor.Red;

                    if (grid[row, col] == prevGrid[row, col])
                    {
                        backgroundColor = ConsoleColor.DarkYellow;
                    }

                    Console.BackgroundColor = backgroundColor;
                    Console.Write("  ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        private bool GenerationsEqual(bool[,] grid1, bool[,] grid2)
        {
            for (int row = 0; row < grid1.GetLength(0); row++)
            {
                for (int col = 0; col < grid1.GetLength(1); col++)
                {
                    if (grid1[row, col] != grid2[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}