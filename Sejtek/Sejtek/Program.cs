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

        

        int generation = 0;
        int generationsWithoutChange = 0; 

        while (generationsWithoutChange < 1) 
        {
            Console.Clear();
            DisplayGrid(grid, rows, cols, prevGrid);
          
            (grid, newGrid) = (newGrid, grid); 
            generation++;
            System.Threading.Thread.Sleep(550); 
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

    
}


