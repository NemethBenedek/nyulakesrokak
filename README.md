#  Projekt
static void Main()
{
    int rows, cols;
    Console.Write("Szép napot! Amennyiben szeretne szimulációt létrehozni adja meg az adatokat! \n");
    while (true)
    {
        Console.Write("Add meg a rács sorainak nagyságát (5 és 11 közötti érték): ");
        if (int.TryParse(Console.ReadLine(), out rows) && rows >= 5 && rows <= 11)
        {
            break;
        }
        else
        {
            Console.WriteLine("Nem megfelelő adat! Kérlek, adj meg egy érvényes számot 5 és 11 között.");
        }
    }

    while (true)
    {
        Console.Write("Add meg a rács oszlopainak nagyságát (5 és 11 közötti érték): ");
        if (int.TryParse(Console.ReadLine(), out cols) && cols >= 5 && cols <= 11)
        {
            break;
        }
        else
        {
            Console.WriteLine("Nem megfelelő adat! Kérlek, adj meg egy érvényes számot 5 és 11 között.");
        }
    }

    // Most 'rows' és 'cols' tartalmazza a helyes értékeket

    bool[,] grid = new bool[rows, cols];
    bool[,] newGrid = new bool[rows, cols];
    bool[,] prevGrid = new bool[rows, cols]; // Előző generációt tároló rács

    // Kezdeti állapot beállítása (például egy véletlenszerű kezdeti minta)
    InitializeGrid(grid, rows, cols);

    int generation = 0;
    int generationsWithoutChange = 0; // Változás nélküli generációk számlálója

    while (generationsWithoutChange < 1) // Példa: a szimuláció akkor áll le, ha 10 generáció óta nem történt változás
    {
        Console.Clear();
        DisplayGrid(grid, rows, cols, prevGrid);
        UpdateGrid(grid, newGrid, prevGrid, rows, cols, generation);

        if (GenerationsEqual(grid, newGrid)) // Ha nincs változás
        {
            generationsWithoutChange++;
        }
        else
        {
            generationsWithoutChange = 0;
        }

        (grid, newGrid) = (newGrid, grid); // Cseréljük a két rácsot
        generation++;
        System.Threading.Thread.Sleep(550); // Várunk egy kicsit
    }

    // Ha már nem történik változás, akkor jelenjen meg a Night függvény
    Night();
}
