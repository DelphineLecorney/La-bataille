namespace La_bataille.Models
{
    internal class DeckBuilder
    {
        public static List<Cards> GenerateCards()
        {
            List<Cards> deck = new List<Cards>();

            foreach (Colors color in Enum.GetValues(typeof(Colors)))
            {
                foreach (Values value in Enum.GetValues(typeof(Values)))
                {
                    deck.Add(new Cards(value, color));
                }
            }
            return deck;
        }
    }
}
