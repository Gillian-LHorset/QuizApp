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
        public MainWindow() {
            InitializeComponent();
        }
        

        private void MainButtonClick(object sender, RoutedEventArgs e) {
            MessageBox.Show("Tu as cliqué sur le bouton.\n\nFéclicitation !");
            //this.Content = new Page1();
        }
        private void CharlieButtonClick(object sender, RoutedEventArgs e) {
            Window1 charlie = new Window1();
            charlie.Show();
        }

    }
    
}