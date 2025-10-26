using La_bataille.Models;

namespace La_bataille.Tests
{
    public static class GameTests
    {
        public static void RunAll()
        {
            //TestCardComparison();
            //TestDeckGeneration();
            //TestDeckShuffle();
            //TestPlayerCards();
            TestTwoPlayers();
        }

        public static void TestCardComparison()
        {
            Card carte = new(Value.As, Color.Pique);
            Card carte2 = new(Value.Roi, Color.Coeur);

            Console.WriteLine(carte);
            Console.WriteLine($"Valeur de la carte : {carte.GetCardValue()}");
            Console.WriteLine(carte2);
            Console.WriteLine($"Valeur de la carte : {carte2.GetCardValue()}");

            if (Card.CompareCards(carte, carte2))
                Console.WriteLine($"{carte} est plus forte que {carte2}");
            else
                Console.WriteLine($"{carte2} est plus forte que {carte}");
        }

        public static void TestDeckGeneration()
        {
            List<Card> deck = DeckBuilder.GenerateCards();
            Console.WriteLine($"Le deck contient {deck.Count} cartes.");
            foreach (Card card in deck)
                Console.WriteLine(card);
        }

        public static void TestDeckShuffle()
        {
            List<Card> deck = DeckBuilder.GenerateCards();
            List<Card> shuffledDeck = DeckBuilder.ShuffleDeck(deck);
            Console.WriteLine("Deck mélangé :");
            foreach (Card card in shuffledDeck)
                Console.WriteLine(card);
        }

        public static void TestPlayerCards()
        {
            Player joueur1 = new("Delphine");
            List<Card> cartes = DeckBuilder.GenerateCards().Take(5).ToList();
            joueur1.AddCards(cartes);

            Console.WriteLine(joueur1);
            Console.WriteLine("Carte jouée : " + joueur1.PlayCard());
            Console.WriteLine("Cartes restantes : " + joueur1.GetCardCount());
        }

        public static void TestTwoPlayers()
        {
            List<Card> deck = DeckBuilder.GenerateCards();
            deck = DeckBuilder.ShuffleDeck(deck);

            Player player1 = new("Alice");
            Player player2 = new("Bob");

            Game.DistributeCards(deck, player1, player2);
            Game.PlayRound(player1, player2);
        }
    }
}
