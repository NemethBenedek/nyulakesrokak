using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

class GameOfLife
{
    static void Main()
    {
        Console.Write("Add meg a rács Sorainak nagyságát (Legyen a szám 5 és 15 kötötti érték): ");
        int rows = int.Parse(Console.ReadLine());
        if (rows < 5)
        {
            Console.WriteLine("Nem megfelelő adat!");
        }
        else if (rows > 15)
        {
            Console.WriteLine("Nem megfelelő adat!");
        }
        Console.Write("Add meg a rács Oszlopainak nagyságát: ");
        int cols = int.Parse(Console.ReadLine());

        if (rows < 5)
        {
            Console.WriteLine("Nem megfelelő adat!");
        }
        else if (rows > 15)
        {
            Console.WriteLine("Nem megfelelő adat!");
        }
        bool[,] grid = new bool[rows, cols];
        bool[,] newGrid = new bool[rows, cols];
        bool[,] prevGrid = new bool[rows, cols];

        InitializeGrid(grid, rows, cols);

        int generation = 0;
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
            System.Threading.Thread.Sleep(550);
        }

        Night();
    }

    static void InitializeGrid(bool[,] grid, int rows, int cols)
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

    static void DisplayGrid(bool[,] grid, int rows, int cols, bool[,] prevGrid)
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

    static void UpdateGrid(bool[,] grid, bool[,] newGrid, bool[,] prevGrid, int rows, int cols, int generation)
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

    static int CountLivingNeighbors(bool[,] grid, int row, int col, int rows, int cols)
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

    static bool GenerationsEqual(bool[,] grid1, bool[,] grid2)
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

    static void Night()
    {
        Console.Clear();
        var stars = new List<string>();
        stars.AddRange(new String[] {
        "        *       ",
        "              *       ",
        "    *            ",
        "          *          ",
        "  *        ",
        "           *    ",
        "        *      "
    });

        for (int i = 0; i < 200; i++)
        {
            Random s = new Random();
            int index = s.Next(stars.Count);

            if (i % 2 == 0)
                Console.ForegroundColor = ConsoleColor.Gray;
            else if (i % 3 == 0)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else
                Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.Write(stars[index]);
            System.Threading.Thread.Sleep(2);
        }

        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Köszönjük a figyelmet!");
        Console.ResetColor();

        System.Threading.Thread.Sleep(2000);
    }

}
