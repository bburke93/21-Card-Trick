using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Card
    {
        public enum Suit { Hearts,Diamonds,Clubs,Spades };
        public enum Face { Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Jack,King,Queen,Ace}
        private Suit suit;
        private Face face;
        
        public Card(Suit cardSuit, Face cardFace)
        {
            face = cardFace;
            suit = cardSuit;
        }
        /// <summary>
        /// Return the card face as a Face enum
        /// </summary>
        /// <returns>Card.Face</returns>
        public Face GetFace() { return face; }
        /// <summary>
        /// Return the card suit as a Suit enum
        /// </summary>
        /// <returns>Card.Suit</returns>
        public Suit GetSuit() { return suit; }

        /// <summary>
        /// Return the face as an int
        /// </summary>
        /// <returns>int</returns>
        public int GetFaceInt() { return (int)face; }
        /// <summary>
        /// Return the suit as an int
        /// </summary>
        /// <returns>int</returns>
        public int GetSuitInt() { return (int)suit; }

        public String GetCardName()
        {
            String faceStr = face.ToString();
            String suitStr = suit.ToString();
            //Ex:Two of Diamonds
            return (faceStr + " of " + suitStr);
        }
    }
}
