using La_bataille.Models;

namespace La_bataille.Display
{
    internal static class DisplayHelper
    {
        private static int battleCount = 0;
        public static void ResetBattleCount()
        {
            battleCount = 0;
        }

        public static void DisplayDuel(Card card1, Card card2, string name1, string name2)
        {
            string[] leftCard = ToAsciiLinesColored(card1);
            string[] rightCard = ToAsciiLinesColored(card2);

            Console.WriteLine($"\n{name1,-25}{name2,25}");

            for (int i = 0; i < leftCard.Length; i++)
            {
                Console.ForegroundColor = card1.Color.GetConsoleColor();
                Console.Write(leftCard[i]);

                string middle = (i == 1) ? "   VS   " : "        ";
                Console.ResetColor();
                Console.Write(middle);

                Console.ForegroundColor = card2.Color.GetConsoleColor();
                Console.WriteLine(rightCard[i]);
                Console.ResetColor();
            }
        }

        public static void AnnounceGame()
        {
            int width = 40;
            string title = "LANCEMENT DE LA PARTIE";

            Console.WriteLine($"\n╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(title, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
            Console.WriteLine(" Les joueurs placent des cartes face cachée...");
            Thread.Sleep(2000);
        }

        public static void AnnounceBattle()
        {
            battleCount++;
            int width = 40;
            string title = $"* BATAILLE {battleCount} EN COURS *";

            Console.WriteLine($"\n╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(title, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
            Console.WriteLine(" Préparation des cartes de bataille...");
            Thread.Sleep(2000);
        }

        public static void AnnounceBattleResult(string winnerName)
        {
            int width = 40;
            string title = $"{winnerName} remporte la bataille !";

            Console.WriteLine("\n* Résultat de la bataille :");
            Console.WriteLine($"╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(title, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
        }


        public static void AnnounceRound(int roundNumber)
        {
            int width = 40;
            string title = $"* TOUR {roundNumber} *";

            Console.WriteLine($"\n╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(title, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
            Thread.Sleep(500);
        }

        public static void AnnounceRoundWinner(string winnerName)
        {
            int width = 40;
            string title = $"{winnerName} remporte le tour !";

            Console.WriteLine($"\n╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(title, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
            Thread.Sleep(800);
        }


        public static void DisplayPlayerStats(Player player1, Player player2)
        {
            int width = 40;
            string line1 = $"{player1.Name} : {player1.GetCardCount()} cartes";
            string line2 = $"{player2.Name} : {player2.GetCardCount()} cartes";

            Console.WriteLine($"╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(line1, width)}║");
            Console.WriteLine($"║{CenterText(line2, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
        }


        public static void AnnounceEquality()
        {
            int width = 40;
            string title = "Égalité parfaite ! Bataille !";

            Console.WriteLine($"\n╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(title, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
            Thread.Sleep(1000);
        }


        public static void AnnounceVictory(string winnerName)
        {
            int width = 34;
            string title = $"{winnerName} a gagné la partie !";

            Console.WriteLine("\n".PadLeft(20));
            Console.WriteLine($"╔{new string('═', width)}╗");
            Console.WriteLine($"║{CenterText(title, width)}║");
            Console.WriteLine($"╚{new string('═', width)}╝");
        }

        private static string[] ToAsciiLinesColored(Card card)
        {
            string symbol = card.Color.GetShortName();
            string raw = $"{card.Value} {symbol}";
            int width = 17;
            string centered = CenterText(raw, width);

            string top = $"┌{new string('─', width + 2)}┐";
            string middle = $"│ {centered} │";
            string bottom = $"└{new string('─', width + 2)}┘";

            return new[] { top, middle, bottom };
        }

        public static void AnimateHiddenCard(string playerName)
        {
            Console.Write($"\n{playerName} prépare une carte cachée");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(400);
                Console.Write(".");
            }
            Console.WriteLine(" (face cachée)");
        }

        private static string CenterText(string text, int width)
        {
            int padding = (width - text.Length) / 2;
            return text.PadLeft(text.Length + padding).PadRight(width);
        }
    }
}
