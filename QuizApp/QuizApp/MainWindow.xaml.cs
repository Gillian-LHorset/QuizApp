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

        private Page _homePage;

        public MainWindow() {
            InitializeComponent();

            _homePage = new HomePage();
            MainFrame.Content = _homePage;
        }

        public void NavigateToQuizPage() {

            MainFrame.Content = new QuizPage();

        }

        public void ReturnToHomePage() {
            MainFrame.Content = _homePage;
        }

    }
    
}