using La_bataille.Display;
using La_bataille.Models;
using La_bataille.Tests;


while (true)
{
    Console.Clear();
    Console.WriteLine("=== MENU PRINCIPAL ===");
    Console.WriteLine("1. Mode automatique (ordinateur vs ordinateur)");
    Console.WriteLine("2. Mode manuel (vous vs ordinateur)");
    Console.WriteLine("3. Quitter");
    Console.Write("Votre choix : ");

    string? choix = Console.ReadLine();

    if (choix == "1")
    {
        GameModes.RunAutoGame();
        Console.WriteLine("\nAppuyez sur Entrée pour revenir au menu...");
        Console.ReadLine();
    }
    else if (choix == "2")
    {
        GameModes.RunManualGame();
        Console.WriteLine("\nAppuyez sur Entrée pour revenir au menu...");
        Console.ReadLine();
    }
    else if (choix == "3")
    {
        Console.WriteLine("À bientôt !");
        break;
    }
}
