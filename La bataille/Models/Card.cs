namespace La_bataille.Models
{
    public class Card
    {
        public Value Values;
        public Color Colors;

        public Card(Value values, Color colors)
        {
            Values = values;
            Colors = colors;
        }

        public override string ToString()
        {
            return $"{Values} de {Colors}";
        }

        public int GetCardValue()
        {
            return (int)Values;
        }

        public static bool CompareCards(Card card1, Card card2)
        {
            if (card1.GetCardValue() > card2.GetCardValue())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
