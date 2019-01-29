using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame
{
    class Board
    {
        public Dealer dealer = new Dealer();
        public Column column1 = new Column();
        public Column column2 = new Column();
        public Column column3 = new Column();

        public Board()
        {
            column1.id = 1;
            column2.id = 2;
            column3.id = 3;
            
            
        }

        public void pickupColumns(int columnIdChosen)
        {
            switch (columnIdChosen)
            {
                case 1:
                    dealer.PickupColumn(column2);
                    column2.columnCards.Clear();

                    dealer.PickupColumn(column1);
                    column1.columnCards.Clear();

                    dealer.PickupColumn(column3);
                    column3.columnCards.Clear();
                    break;
                case 2:
                    dealer.PickupColumn(column1);
                    column1.columnCards.Clear();

                    dealer.PickupColumn(column2);
                    column2.columnCards.Clear();

                    dealer.PickupColumn(column3);
                    column3.columnCards.Clear();
                    break;
                case 3:
                    dealer.PickupColumn(column1);
                    column1.columnCards.Clear();

                    dealer.PickupColumn(column3);
                    column3.columnCards.Clear();

                    dealer.PickupColumn(column2);
                    column2.columnCards.Clear();
                    break;
                default:
                    break;

            }
                //next round
                dealer.dealNumber++;
        }

        public void dealToColumns()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    AddToColumn(j, dealer.Deal());
                }
            }
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
