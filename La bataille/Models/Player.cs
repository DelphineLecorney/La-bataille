using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_bataille.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> CardsDeck { get; set; }

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
    }


}
