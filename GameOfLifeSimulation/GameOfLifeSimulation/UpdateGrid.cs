using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulation
{
    class GridUpdater
    {
        public static void UpdateGrid(bool[,] grid, bool[,] newGrid, bool[,] prevGrid, int rows, int cols, int generation)
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

        private static int CountLivingNeighbors(bool[,] grid, int row, int col, int rows, int cols)
        {
            throw new NotImplementedException();
        }
    }

}
