using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Board
    {
        Column column1 = new Column();
        Column column2 = new Column();
        Column column3 = new Column();

        public Board()
        {
            column1.id = 1;
            column2.id = 2;
            column3.id = 3;
        }

        public void AddToColumn(int columnID, Card card)
        {
            switch (columnID)
            {
                case 1:
                    column1.addCard(card);
                    break;               
                case 2:
                    column2.addCard(card);
                    break;
                case 3:
                    column3.addCard(card);
                    break;

            }

        }
    }
}
