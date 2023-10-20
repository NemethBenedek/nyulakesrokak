using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CountLivingNeighbors osztály a szomszédos élő sejtek számának számolására
namespace GameOfLifeSimulation
{
    class CountLivingNeighbors {
        // Metódus a szomszédos élő sejtek számának kiszámításához egy adott cellában
        public static int LivingNeighbors(bool[,] grid, int row, int col, int rows, int cols)
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
    }
}
