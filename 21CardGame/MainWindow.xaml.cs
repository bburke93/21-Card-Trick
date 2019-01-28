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
        double dColumnClicked;
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
                //Visibilities
                btnStartButton.Visibility = Visibility.Hidden;
                canvasCardContainer.Visibility = Visibility.Visible;

                //Dealer shuffles and selects 21 cards 
                showCards();
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
            dColumnClicked = char.GetNumericValue(canvasClicked.Name.Last());
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
                btnPickedCard.Visibility = Visibility.Hidden;
                //indicateColumn();
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
        }

        /// <summary>
        /// Shows the cards on the UI
        /// </summary>
        void showCards()
        {
            //call Dealer.deal()

            //Deal cards to GUI using the info from the column class
            //With a for loop, lay down cards row by row.
            //foreach (var card in )
            //{

            //}
            canvasCardContainer.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The dealers instructions based on the current round;
        /// </summary>
        void dealerInstructions()
        {
            int round = 0; //delete later
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
                    sInstruction = "Your card is the " + "card" + ".";
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
