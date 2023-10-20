using GameOfLifeSimulation;
namespace GameOfLifeSimulation
{
    class Program
    {
        static void Main()
        {
            // A rács adatai I LOVE KARI
            int rows = 10;
            int cols = 10;

            GameOfLifeSimulation game = new GameOfLifeSimulation(rows, cols);
            game.RunSimulation();
        }
    }
}