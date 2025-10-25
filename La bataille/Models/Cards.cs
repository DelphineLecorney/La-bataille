namespace La_bataille.Models
{
    public class Cards
    {
        public Values Values;
        public Colors Colors;

        public Cards(Values values, Colors colors)
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

        public static bool CompareCards(Cards card1, Cards card2)
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
