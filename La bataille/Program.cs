using La_bataille.Models;

// Tests pour vérifier mes méthodes
Card carte = new (Value.As, Color.Pique);
Console.WriteLine(carte);
Console.WriteLine($"Valeur de la carte : {carte.GetCardValue()}");

Card carte2 = new (Value.Roi, Color.Coeur);
Console.WriteLine(carte2);
Console.WriteLine($"Valeur de la carte : {carte2.GetCardValue()}");

if (Card.CompareCards(carte, carte2))
{
    Console.WriteLine($"{carte} est plus forte que {carte2}");
}
else
{
    Console.WriteLine($"{carte2} est plus forte que {carte}");
}

// Test pour vérifier les cartes
List<Card> deck = DeckBuilder.GenerateCards();
Console.WriteLine($"Le deck contient {deck.Count} cartes.");
foreach (Card card in deck)
{
    Console.WriteLine(card);
}

Console.WriteLine("--------");

// Test pour vérifier le mélange des cartes
List<Card> shuffledDeck = DeckBuilder.ShuffleDeck(deck);
Console.WriteLine("Deck mélangé :");
foreach (Card card in shuffledDeck)
{
    Console.WriteLine(card);
}

Console.WriteLine("--------");
// Test pour vérifier la distribution des cartes aux joueurs
Player joueur1 = new ("Delphine");
List<Card> cartes = DeckBuilder.GenerateCards().Take(5).ToList();
joueur1.AddCards(cartes);

Console.WriteLine(joueur1);
Console.WriteLine("Carte jouée : " + joueur1.PlayCard());
Console.WriteLine("Cartes restantes : " + joueur1.GetCardCount());
