using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Game gameLogic = new Game(); 

        private void PlayerClickSpace(object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
            space.Content = gameLogic.CurrentPlayer;


            var coodinates = space.Tag.ToString().Split(',');  
            var xValue = int.Parse(coodinates[0]);
            var yValue = int.Parse(coodinates[1]);

            var buttonPosition = new Position() 
            { 
                x = xValue, 
                y = yValue 
            };
            gameLogic.UpdateBoard(buttonPosition, gameLogic.CurrentPlayer);

            if (gameLogic.PlayerWin())
            {
                WinScreen.Text = $"{gameLogic.CurrentPlayer} WINS!!!";
                WinScreen.Visibility = Visibility.Visible;
            }
            
            gameLogic.SetNextPlayer();
        }
        private void buttonNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach(var control in gridBoard.Children)
            {
                if(control is Button)
                {
                    ((Button)control).Content = String.Empty;   
                }
            }
            gameLogic = new Game();
            WinScreen.Visibility = Visibility.Collapsed; 
        }
    }
}
