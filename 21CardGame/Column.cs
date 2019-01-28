using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Column
    {
        public int id;
        public List<Card> columnCards;

        public Column() {
            columnCards = new List<Card>();
        }

        public void addCard(Card tempCard)
        {
            
            columnCards.Add(tempCard);
        }
    }
}
