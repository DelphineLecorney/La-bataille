using La_bataille.Display;

namespace La_bataille.Models
{
    internal class Game
    {
        public static void DistributeCards(List<Card> deck, Player player1, Player player2)
        {
            List<Card> cardsP1 = new();
            List<Card> cardsP2 = new();

            for (int i = 0; i < deck.Count; i++)
            {
                if (i % 2 == 0)
                    cardsP1.Add(deck[i]);
                else
                    cardsP2.Add(deck[i]);
            }

            player1.AddCards(cardsP1);
            player2.AddCards(cardsP2);
        }

        public static bool PlayRound(Player player1, Player player2, bool isManual)
        {
            try
            {
                Card? card1 = isManual ? player1.ChooseCardManually() : player1.PlayCard();
                if (card1 == null) return false;

                Card card2 = player2.PlayCard();

                DisplayHelper.DisplayDuel(card1, card2, player1.Name, player2.Name);

                int value1 = card1.GetCardValue();
                int value2 = card2.GetCardValue();

                if (value1 > value2)
                {
                    DisplayHelper.AnnounceRoundWinner(player1.Name);
                    player1.AddCards([card1, card2]);
                }
                else if (value2 > value1)
                {
                    DisplayHelper.AnnounceRoundWinner(player2.Name);
                    player2.AddCards([card2, card1]);
                }
                else
                {
                    List<Card> pile = [card1, card2];
                    ResolveBattle(player1, player2, pile, isManual);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tour impossible : {ex.Message}");
                return true;
            }
        }

        public static void PlayGame(Player player1, Player player2, bool isManual)
        {
            DisplayHelper.ResetBattleCount();
            DisplayHelper.AnnounceGame();

            int round = 1;

            while (player1.HasCards() && player2.HasCards())
            {
                DisplayHelper.AnnounceRound(round);

                bool continueGame = PlayRound(player1, player2, isManual);
                if (!continueGame)
                {
                    Console.WriteLine("\nRetour au menu principal...");
                    return;
                }

                DisplayHelper.DisplayPlayerStats(player1, player2);
                round++;
            }

            Console.WriteLine("\n--- Fin de la partie ---");
            if (player1.GetCardCount() > player2.GetCardCount())
            {
                DisplayHelper.AnnounceVictory(player1.Name);
            }
            else if (player2.GetCardCount() > player1.GetCardCount())
            {
                DisplayHelper.AnnounceVictory(player2.Name);
            }
            else
            {
                Console.WriteLine("Égalité parfaite !");
            }
        }


        private static void ResolveBattle(Player player1, Player player2, List<Card> pile, bool isManual)
        {
            DisplayHelper.AnnounceBattle();

            if (!player1.HasCards() || !player2.HasCards())
            {
                Console.WriteLine("Plus assez de cartes pour continuer la bataille.");
                return;
            }

            Card hidden1 = player1.PlayCard();
            Card hidden2 = player2.PlayCard();

            DisplayHelper.AnimateHiddenCard(player1.Name);
            DisplayHelper.AnimateHiddenCard(player2.Name);

            if (hidden1 == null)
            {
                Console.WriteLine("\nRetour au menu principal...");
                return;
            }

            pile.Add(hidden1);
            pile.Add(hidden2);


            if (!player1.HasCards() || !player2.HasCards())
            {
                Console.WriteLine("Plus assez de cartes pour terminer la bataille.");
                return;
            }
            Card? card1 = isManual ? player1.ChooseCardManually() : player1.PlayCard();
            Card card2 = player2.PlayCard();

            if (card1 == null)
            {
                Console.WriteLine("\nRetour au menu principal...");
                return;
            }

            DisplayHelper.DisplayDuel(card1, card2, player1.Name, player2.Name);

            pile.Add(card1);
            pile.Add(card2);

            int value1 = card1.GetCardValue();
            int value2 = card2.GetCardValue();

            if (value1 > value2)
            {
                DisplayHelper.AnnounceBattleResult(player1.Name);
                player1.AddCards(pile);
            }
            else if (value2 > value1)
            {
                DisplayHelper.AnnounceBattleResult(player2.Name);
                player2.AddCards(pile);
            }
            else
            {
                DisplayHelper.AnnounceEquality();
                ResolveBattle(player1, player2, pile, isManual);
            }
        }
    }
}
