using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Card
    {
        public enum Suit { hearts,diamonds,clubs,spades};
        public enum Face {two=2,three,four,five,six,seven,eight,nine,ten,jack,king,queen,ace}
        public Suit suit;
        public Face face;
        
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

        public override string ToString()
        {
            String faceStr;
            if (face == Face.jack || face == Face.king || face == Face.queen || face == Face.ace)
            {
                faceStr = face.ToString();
            }
            else
            {
                faceStr = ((int)face).ToString();
            }

            String suitStr = suit.ToString();
            //Ex:Two of Diamonds
            return (faceStr + "_of_" + suitStr + ".png");
        }
    }
}
