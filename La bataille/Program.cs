using La_bataille.Models;

// Tests pour vérifier mes méthodes
Cards carte = new (Values.As, Colors.Pique);
Console.WriteLine(carte);
Console.WriteLine($"Valeur de la carte : {carte.GetCardValue()}");

Cards carte2 = new (Values.Roi, Colors.Coeur);
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

// Test pour vérifier les cartes
List<Cards> deck = DeckBuilder.GenerateCards();
Console.WriteLine($"Le deck contient {deck.Count} cartes.");
foreach (Cards card in deck)
{
    Console.WriteLine(card);
}
