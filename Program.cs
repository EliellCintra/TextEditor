Menu();

static void Menu()
{
    Console.Clear();

    Console.WriteLine("\n\tWELCOME!\n");
    Console.WriteLine("0 - Exit");
    Console.WriteLine("1 - Open file");
    Console.WriteLine("2 - Create new file");
    Console.WriteLine("-----------------------");
    Console.WriteLine("Select an option:");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: Console.Clear(); Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Edit(); break;
        default:
            {
                Console.Clear();
                Console.WriteLine("Select a valid option: 0,1 or 2 ...");
                Thread.Sleep(2000);
                Console.Clear();
                Menu();
            }; break;
    }
}

static void Open()
{
    Console.Clear();
    Console.WriteLine("Enter the path file:");
    var path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void Edit()
{
    Console.Clear();
    Console.WriteLine("Enter your text below (press ESC to exit)");
    Console.WriteLine("-----------------------");
    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Save(text);
}

static void Save(string text)
{
    Console.Clear();
    Console.WriteLine("Enter the path to save this file:");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }
    Console.WriteLine($"File {path} saved successfully!");
    Thread.Sleep(2000);
    Menu();

}
