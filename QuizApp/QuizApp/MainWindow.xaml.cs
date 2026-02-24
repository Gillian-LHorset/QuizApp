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
        private string _playerName;
        private int _playerScore = 0;
        private int _playerBestScore;

        public MainWindow() {
            InitializeComponent();

            _homePage = new HomePage();
            MainFrame.Content = _homePage;
        }

        public void SetPlayerName(string playerName) {
            _playerName = playerName;
        }

        public void IncrementPlayerScore() {
            _playerScore++;
        }

        public void SetPlayerBestScore(int bestScore) {
            _playerBestScore = bestScore;
        }

        public void NavigateToQuizPage() {

            MainFrame.Content = new QuizPage(_playerName, _playerScore, _playerBestScore);

        }

        public void ReturnToHomePage() {
            MainFrame.Content = _homePage;
        }

    }
    
}