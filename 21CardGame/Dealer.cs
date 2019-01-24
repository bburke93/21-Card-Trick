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
        private int dealNumber = 0;

        /// <summary>
        /// Full 52 card deck
        /// </summary>
        private Deck cardDeck;

        /// <summary>
        /// The random 21 cards taken from the full deck
        /// </summary>
        private List<Card> randomDeck;

        public Dealer()
        {
            cardDeck = new Deck();
            //randomDeck = cardDeck.Random21();
        }

        /// <summary>
        /// Deal the 21 cards out
        /// </summary>
        public void Deal()
        {

        }

        /// <summary>
        /// Add cards back to the list in specific order
        /// </summary>
        public void PickupCards()
        {

        }

        /// <summary>
        /// Reveal to the user the secret card they picked
        /// </summary>
        public void RevealCard()
        {

        }
    }
}
