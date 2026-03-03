using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Page _homePage;
        public string playerName;
        public int playerScore = 0;
        public int playerBestScore = 0;

        public MainWindow() {
            InitializeComponent();

            _homePage = new HomePage();
            MainFrame.Content = _homePage;
        }

        /// <summary>
        /// Use for transmet the player name in the views
        /// </summary>
        /// <param name="playerName">The name of the current player</param>
        public void SetPlayerName(string playerName) {
            this.playerName = playerName;
        }

        /// <summary>
        /// Increment the score of the player after a good answert
        /// </summary>
        public void IncrementPlayerScore() {
            playerScore++;
        }

        /// <summary>
        /// Set the best score of the player to the variable for be use in the views
        /// </summary>
        /// <param name="bestScore"></param>
        public void SetPlayerBestScore(int bestScore) {
            playerBestScore = bestScore;
        }

        public void ResetPlayerScore() {
            playerScore = 0;
        }


        public void NavigateToQuizPage() {
            MainFrame.Content = new QuizPage(playerName, playerScore, playerBestScore);
        }

        public void ReturnToHomePage() {
            MainFrame.Content = _homePage;
        }

    }
    
}