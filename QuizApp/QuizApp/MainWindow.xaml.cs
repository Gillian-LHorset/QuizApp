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

            //TODO : trouver une alternative à this.Content, car this.Content oblige d'avoir comme parent Window
            Frame newNameSelectPage = new Frame();

            this.Content = newNameSelectPage;

            newNameSelectPage.Content = new NameSelectPage();
        }
        


    }
    
}