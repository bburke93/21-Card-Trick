using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Board
    {
        public void AddToColumn(int columnID, Card card)
        {
            Column column = new Column();
            column.addCard(card);
        }
    }
}
