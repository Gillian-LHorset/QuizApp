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

namespace QuizApp {
    /// <summary>
    /// Logique d'interaction pour NameSelectPage.xaml
    /// </summary>
    public partial class NameSelectPage : Page {
        public NameSelectPage() {
            InitializeComponent();
        }

        private void MainButtonClick(object sender, RoutedEventArgs e) {
            MessageBox.Show("Tu as cliqué sur le bouton.\n\nFéclicitation !");
        }

        private void start_quiz(object sender, RoutedEventArgs e) {

            this.Content = new QuizPage();


        }
    }
}
