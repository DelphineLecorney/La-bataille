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

        public string ToVisualString()
        {
            return $"{Value} {Color.GetShortName()}";
        }


        public int GetCardValue()
        {
            return (int)Value;
        }

    }
}
