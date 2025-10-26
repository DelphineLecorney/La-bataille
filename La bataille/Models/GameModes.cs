

namespace La_bataille.Models
{
    public static class GameModes
    {
        public static void RunAutoGame()
        {
            List<Card> deck = DeckBuilder.GenerateCards();
            deck = DeckBuilder.ShuffleDeck(deck);

            Player player1 = new("Del");
            Player player2 = new("Alf");

            Game.DistributeCards(deck, player1, player2);
            Game.PlayGame(player1, player2, false);

        }

        public static void RunManualGame()
        {
            List<Card> deck = DeckBuilder.GenerateCards();
            deck = DeckBuilder.ShuffleDeck(deck);

            Console.Write("Entrez votre prénom : ");
            string? prenom = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(prenom))
            {
                prenom = char.ToUpper(prenom[0]) + prenom.Substring(1).ToLower();

            }
            Player humain = new(prenom);
            Player ordi = new("Ordinateur");

            Game.DistributeCards(deck, humain, ordi);
            Game.PlayGame(humain, ordi, true);

        }
    }
}
