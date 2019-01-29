using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _21CardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region GLOBAL VARIABLES
        int dColumnClicked;
        Board oBoard;
        #endregion


        #region METHODS
        public MainWindow()
        {
            InitializeComponent();
            oBoard = new Board();
            
        }

        /// <summary>
        /// Starts the 21 Card Trick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Dealer shuffles and selects 21 cards 
                oBoard.dealToColumns();

                //UI hides start button, then shows cards
                hideCards();
                showCards();

                //UI shows instructions
                dealerInstructions(oBoard.dealer.dealNumber);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Selects and Highlights the column of cards Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasCardContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Clicked a column
                btnPickedCard.Visibility = Visibility.Visible;

            //gets the canvas that was clicked
            Canvas canvasClicked = (Canvas)LogicalTreeHelper.GetParent(e.OriginalSource as DependencyObject);

            //only one column gets highlighted at a time
            dColumnClicked = (int)char.GetNumericValue(canvasClicked.Name.Last());
            switch (dColumnClicked)
            {
                case 1:
                    borderColumn1.BorderThickness = new Thickness(10);
                    borderColumn2.BorderThickness = new Thickness(0);
                    borderColumn3.BorderThickness = new Thickness(0);
                    break;
                case 2:
                    borderColumn2.BorderThickness = new Thickness(10);
                    borderColumn1.BorderThickness = new Thickness(0);
                    borderColumn3.BorderThickness = new Thickness(0);
                    break;
                case 3:
                    borderColumn3.BorderThickness = new Thickness(10);
                    borderColumn2.BorderThickness = new Thickness(0);
                    borderColumn1.BorderThickness = new Thickness(0);
                    break;
            }
        }

        /// <summary>
        /// what happens when the picked card button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickedCardClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //clear boarders
                borderColumn1.BorderThickness = new Thickness(0);
                borderColumn2.BorderThickness = new Thickness(0);
                borderColumn3.BorderThickness = new Thickness(0);

                //if its not after the third round
                if (oBoard.dealer.dealNumber != 4)
                {
                    //pickup the cards, hide the button
                    canvasCardContainer.Visibility = Visibility.Hidden;
                    btnPickedCard.Visibility = Visibility.Hidden;

                    //Collect the columns
                    oBoard.pickupColumns(dColumnClicked);
                    //deal the columns
                    oBoard.dealToColumns();
                    //show in the UI
                    showCards();
                    //display instructions for round
                    dealerInstructions(oBoard.dealer.dealNumber);
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion


        #region SUPPORT FUNCTIONS
        /// <summary>
        /// Hides the cards on the UI
        /// </summary>
        void hideCards()
        {
            canvasCardContainer.Visibility = Visibility.Hidden;
            btnStartButton.Visibility = Visibility.Hidden;
            btnPickedCard.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Shows the cards on the UI
        /// </summary>
        void showCards()
        {
            //show the cards
            canvasCardContainer.Visibility = Visibility.Visible;

            //With a for loop, lay down the cards
            int count = 0;
            foreach (Image imgCard in canColumn1.Children)
                {
                imgCard.Source = new BitmapImage(new Uri(@"Images/Cards/"+ oBoard.column1.columnCards[count], UriKind.RelativeOrAbsolute));
                count++;
                }
            count = 0;
            foreach (Image imgCard in canColumn2.Children)
            {
                imgCard.Source = new BitmapImage(new Uri(@"Images/Cards/" + oBoard.column2.columnCards[count], UriKind.RelativeOrAbsolute));
                count++;
            }
            count = 0;
            foreach (Image imgCard in canColumn3.Children)
            {
                imgCard.Source = new BitmapImage(new Uri(@"Images/Cards/" + oBoard.column3.columnCards[count], UriKind.RelativeOrAbsolute));
                count++;
            }


        }

        /// <summary>
        /// The dealers instructions based on the current round;
        /// </summary>
        void dealerInstructions(int round)
        {
            string sInstruction;
            switch (round)
            {
                case 1:
                    sInstruction = "Pick a card by Selecting the Column that it's in. \nMemorize that card.";
                    break;
                case 2:
                    sInstruction = "Click on the Column that your card is in.";
                    break;
                case 3:
                    sInstruction = "All right last time, click the Column your card is in.";
                    break;
                default:
                    //sInstruction = "Your card is the " + oBoard.dealer.RevealCard() + ".";
                    sInstruction = "Your card is the " + oBoard.column2.columnCards[3] + ".";
                    break;
            }
            txtBlkDealer.Text = sInstruction;
        }
        #endregion


        #region ERROR HANDLING
        /// <summary>
        /// handles errors
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion
    }
}
