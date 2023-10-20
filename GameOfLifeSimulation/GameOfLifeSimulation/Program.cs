using GameOfLifeSimulation;
namespace GameOfLifeSimulation
{
    class Program
    {
        static void Main()
        {
            // Provide the dimensions of the grid (for example, 10 rows and 20 columns)
            int rows = 10;
            int cols = 10;

            GameOfLifeSimulation game = new GameOfLifeSimulation(rows, cols);
            game.RunSimulation();
        }
    }
}