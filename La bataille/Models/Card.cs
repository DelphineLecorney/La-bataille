namespace La_bataille.Models
{
    internal class Card
    {
        public Value Value { get; }
        public Color Color { get; }

        public Card(Value value, Color color)
        {
            Value = value;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Value} de {Color}";
        }

        public int GetCardValue()
        {
            return (int)Value;
        }

        public static bool CompareCards(Card card1, Card card2)
        {
            return card1.GetCardValue() > card2.GetCardValue();
        }
    }
}
