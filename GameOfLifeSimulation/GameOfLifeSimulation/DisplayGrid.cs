using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeSimulation
{
    class GridDisplayer
    {
        // Metódus a rács megjelenítéséhez színek alapján a cella állapotától függően
        public static void DisplayGrid(bool[,] grid, int rows, int cols, bool[,] prevGrid)
        {
            // Iterálunk minden cellán
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Háttérszín beállítása a cella állapotától függően
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
