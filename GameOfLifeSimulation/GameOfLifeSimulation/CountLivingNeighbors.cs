using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulation
{
    class CountLivingNeighbors { 
    public static int LivingNeighbors(bool[,] grid, int row, int col, int rows, int cols)
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
    }
}
