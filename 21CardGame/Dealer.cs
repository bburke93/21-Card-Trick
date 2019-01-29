using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Dealer
    {
        /// <summary>
        /// Count of how many times the cards have been dealt out
        /// </summary>
        public int dealNumber = 1;

        /// <summary>
        /// Full 52 card deck
        /// </summary>
        private Deck cardDeck;

        /// <summary>
        /// The random 21 cards taken from the full deck
        /// </summary>
        public List<Card> randomDeck;

        public Dealer()
        {
            cardDeck = new Deck();
            cardDeck.Shuffle();
            cardDeck.Random21();
            randomDeck = cardDeck.deck;
        }

        /// <summary>
        /// Deal out card from top of deck
        /// </summary>
        public Card Deal()
        {
            Card temp = randomDeck[0];
            randomDeck.RemoveAt(0);
            return temp;
        }

        /// <summary>
        /// Add a card to the deck
        /// </summary>
        public void PickupColumn(Column temp)
        {
            randomDeck.AddRange(temp.columnCards);
        }

        /// <summary>
        /// Reveal to the user the secret card they picked
        /// </summary>
        public Card RevealCard()
        {
            return randomDeck[10];
        }
    }
}
