namespace La_bataille.Models
{
    internal static class DeckBuilder
    {
        public static List<Card> GenerateCards()
        {
            List<Card> deck = [];

            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    deck.Add(new Card(value, color));
                }
            }
            return deck;
        }

        public static List<Card> ShuffleDeck(List<Card> deck)
        {
            Random rand = new();
            return deck.OrderBy(c => rand.Next()).ToList();
        }

    }
}
