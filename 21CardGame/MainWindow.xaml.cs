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
        /// <summary>
        /// indicates whether the player has selected a card
        /// </summary>
        private bool hasSelectedCard = false;
        #endregion


        #region METHODS
        public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Selects and Highlights the column of cards Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasCardContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //gets the canvas that was clicked
            Canvas canvasClicked = (Canvas)LogicalTreeHelper.GetParent(e.OriginalSource as DependencyObject);

            //only one column gets highlighted at a time
            dColumnClicked = char.GetNumericValue(canvasClicked.Name.Last());
            switch (dColumnClicked)
            {
                case 1:
                    hideCards();
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
        /// What happens when the Start Button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Start_Button.Visibility = Visibility.Hidden;

                //Dealer shuffles and selects 21 cards 

                deal();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// deals the cards
        /// </summary>
        private void deal()
        {
            try
            {
                //call Dealer.deal()

                //Deal cards to GUI using the info from the column class

                //check if player has picked a card
                if (hasSelectedCard)
                    indicateColumn();
                else
                    pickCard();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Makes it so the player can indicate that they have selected a card
        /// </summary>
        private void pickCard()
        {
            try
            {
                pickedCardButton.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// what happens when the picked card button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pickedCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pickedCardButton.Visibility = Visibility.Hidden;
                hasSelectedCard = true;
                indicateColumn();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// makes it so the player can choose a column
        /// </summary>
        private void indicateColumn()
        {
            try
            {
                buttoncolumn1.Visibility = Visibility.Visible;
                buttoncolumn2.Visibility = Visibility.Visible;
                buttoncolumn3.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// what happens when a column is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttoncolumn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttoncolumn1.Visibility = Visibility.Hidden;
                buttoncolumn2.Visibility = Visibility.Hidden;
                buttoncolumn3.Visibility = Visibility.Hidden;

                Button column = (Button)sender;

                pickupCards();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// picks up the cards
        /// </summary>
        private void pickupCards()
        {
            try
            {
                //call Dealer.pickupCards() & pass in column.Tag //tags: 0, 1, 2

                //GUI picks up cards

                deal();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
            canvasCardContainer.Visibility = Visibility.Visible;
        }


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
