namespace La_bataille.Models
{
    internal class Game
    {
        public static void DistributeCards(List<Card> deck, Player player1, Player player2)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                if (i % 2 == 0)
                {
                    // player1.AddCards(new List<Card> { deck[i] });
                    // peut être simplifié en :
                    player1.AddCards([deck[i]]);
                }
                else
                {
                    player2.AddCards([deck[i]]);
                }
            }
        }

        public static void PlayRound(Player player1, Player player2)
        {
            try
            {
                Card card1 = player1.PlayCard();
                Card card2 = player2.PlayCard();

                Console.WriteLine($"{player1.Name} joue la carte {card1}");
                Console.WriteLine($"{player2.Name} joue la carte {card2}");

                if (Card.CompareCards(card1, card2))
                {
                    Console.WriteLine($"{player1.Name} remporte le tour !");
                    player1.AddCards([card1, card2]);
                }
                else if (Card.CompareCards(card2, card1))
                {
                    Console.WriteLine($"{player2.Name} remporte le tour !");
                    player2.AddCards([card2, card1]);
                }
                else
                {
                    Console.WriteLine("Egalité");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Tour impossible : {ex.Message}");
            }
        }


    }
}
