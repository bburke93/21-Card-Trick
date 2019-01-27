using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Column
    {
        private int id;
        Card[] cardArr = new Card[7];

        public void addCard(Card card)
        {
            for (int i = 0; i < 7; i++)
            {
                if (cardArr[i] == null)
                {
                    cardArr[i] = card;
                    break;
                }
            }
        }
    }
}
