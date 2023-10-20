using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokadikteszt
{
    class GridDisplayer
    {
        public static void DisplayGrid(bool[,] grid, int rows, int cols, bool[,] prevGrid)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    ConsoleColor backgroundColor = grid[row, col] ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write("  ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }

}