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
    public partial class MainWindow
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void start_quiz(object sender, RoutedEventArgs e) {

            Frame newQuizPage = new Frame();

            this.Content = newQuizPage;


            newQuizPage.Content = new QuizPage();

        }

    }
    
}