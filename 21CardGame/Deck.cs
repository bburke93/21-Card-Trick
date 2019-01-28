using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Deck
    {
        public List<Card> deck;

        /// <summary>
        /// Deck constructor generate list of 52 cards
        /// </summary>
        public Deck() {

            deck = new List<Card>();

            //4 suits
            for (int i = 0;i<4; i++)
            {
                //13 Faces
                for(int j = 0;j<13; j++)
                {
                    Card card = new Card((Card.Suit)i, (Card.Face)j);
                    deck.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            //number of swaps between 300-400
            int numSwaps = rng.Next(300, 400);
            int card1;
            Card temp;
            int card2;
            

            for(int i = 0; i < numSwaps; i++)
            {
                //pick two cards at random
                card1 = rng.Next(deck.Count);
                card2 = rng.Next(deck.Count);

                //swap them
                temp = deck[card2];
                deck[card2] = deck[card1];
                deck[card1] = temp;
            }
        }

        public void Random21()
        {
            Random rng = new Random();
            //remove cards until there are 21 cards in the deck
            while (deck.Count >= 21)
            {
                deck.Remove(deck[rng.Next(deck.Count)]);
            }
        }
    }
}
