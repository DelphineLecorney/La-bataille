using La_bataille.Models;

// Tests pour vérifier mes méthodes
Cards carte = new Cards(Values.As, Colors.Pique);
Console.WriteLine(carte);
Console.WriteLine($"Valeur de la carte : {carte.GetCardValue()}");

Cards carte2 = new Cards(Values.Roi, Colors.Coeur);
Console.WriteLine(carte2);
Console.WriteLine($"Valeur de la carte : {carte2.GetCardValue()}");

if (Cards.CompareCards(carte, carte2))
{
    Console.WriteLine($"{carte} est plus forte que {carte2}");
}
else
{
    Console.WriteLine($"{carte2} est plus forte que {carte}");
}

