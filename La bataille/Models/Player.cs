using La_bataille.Display;

namespace La_bataille.Models
{
    internal class Player
    {
        public string Name { get; set; }
        private Queue<Card> CardsDeck { get; set; }


        public Player(string name)
        {
            Name = name;
            CardsDeck = new Queue<Card>();
        }

        public override string ToString()
        {
            return $"{Name} ({GetCardCount()} cartes)";
        }


        public Card PlayCard()
        {
            if (CardsDeck.Count > 0)
            {
                return CardsDeck.Dequeue();
            }
            else
            {
                throw new InvalidOperationException("Le joueur n'a plus de cartes à jouer.");
            }
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                CardsDeck.Enqueue(card);
            }
        }

        public int GetCardCount()
        {
            return CardsDeck.Count;
        }

        public bool HasCards()
        {
            return CardsDeck.Count > 0;
        }

        public Card? ChooseCardManually()
        {
            if (CardsDeck.Count == 0)
            {
                Console.WriteLine("Vous n'avez plus de cartes !");
                return null;
            }

            List<Card> tempList = CardsDeck.ToList();

            Console.WriteLine("...");
            Console.Write($" Taper sur Entrée ou Q pour quitter : ");

            string? input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "Q")
                return null;

            if (int.TryParse(input, out int index) && index >= 1 && index <= tempList.Count)
            {
                Card chosen = tempList[index - 1];
                DisplayHelper.DisplayDuel(chosen, chosen, this.Name, this.Name);

                CardsDeck = new Queue<Card>(tempList.Where((c, i) => i != index - 1));
                return chosen;
            }
            else
            {
                Card playedCard = CardsDeck.Dequeue();
                return playedCard;
            }
        }

    }
}
