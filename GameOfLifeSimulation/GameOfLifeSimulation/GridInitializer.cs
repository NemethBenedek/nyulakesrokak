using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulation
{
    class GridInitializer
    {
        public static void InitializeGrid(bool[,] grid, int rows, int cols)
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
    }

}
