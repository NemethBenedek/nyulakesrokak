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
                            newGrid[row, col] = false;
                        }
                        else
                        {
                            newGrid[row, col] = true;
                        }
                    }
                    else
                    {
                        if (neighbors == 3)
                        {
                            newGrid[row, col] = true;
                        }
                        else
                        {
                            newGrid[row, col] = false;
                        }
                    }
                }
            }

            if (generation > 1)
            {
                Array.Copy(grid, prevGrid, grid.Length);
            }
        }
        private int CountLivingNeighbors(bool[,] grid, int row, int col, int rows, int cols)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborRow = row + i;
                    int neighborCol = col + j;

                    if (neighborRow >= 0 && neighborRow < rows && neighborCol >= 0 && neighborCol < cols)
                    {
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
                        return false;
                    }
                }
            }
            return true;
        }
    }
}