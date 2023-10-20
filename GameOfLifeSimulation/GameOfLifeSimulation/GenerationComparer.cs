using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulation
{
    class GenerationComparer
    {
        public static bool GenerationsEqual(bool[,] grid1, bool[,] grid2)
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
