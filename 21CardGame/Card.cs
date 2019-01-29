using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Card
    {
        public string suit;
        public string face;
        
        public Card(string cardSuit, string cardFace)
        {
            face = cardFace;
            suit = cardSuit;
        }

        /// <summary>
        /// Return the card face
        /// </summary>
        /// <returns>Card.Face</returns>
        public string GetFace() { return face; }

        /// <summary>
        /// Return the card suit
        /// </summary>
        /// <returns>Card.Suit</returns>
        public string GetSuit() { return suit; }

        public override string ToString()
        {
            return (face + "_of_" + suit + ".png");
        }
    }
}
