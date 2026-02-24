using System;
using System.Collections.Generic;
using System.Data;
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
using MySqlConnector;

namespace QuizApp {
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Page {
        public HomePage() {
            InitializeComponent();
        }

        public void start_quiz(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(PlayerName.Text)) {
                if (PlayerName.Text.Length < 51) {

                    CheckIfPlayerInDB(PlayerName.Text);


                    if (Window.GetWindow(this) is MainWindow mainWindow) {
                        mainWindow.NavigateToQuizPage();
                    }
                } else {
                    MessageBox.Show("Votre nom est trop grand !");

                }
            } else {
                MessageBox.Show("Vous n'avez pas entrer de nom !");
            }
        }

        private void CheckIfPlayerInDB(string playerName) {

            string playerNameFromDB = null;

            using MySqlConnection connection = new MySqlConnection("Server=localhost;Port=6033;User ID=root;Password=root;Database=db_quizapp");
            connection.Open();

            using MySqlCommand command = new MySqlCommand("SELECT player_name, meilleur_score FROM t_player WHERE player_name = @val1 LIMIT 1;", connection);
            command.Parameters.AddWithValue("@val1", PlayerName.Text);
            command.Prepare();

            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                playerNameFromDB = reader.GetString("player_name");
            }
            
            connection.Close();

            if (playerNameFromDB == null) {
                connection.Open();

                using MySqlCommand registerCommand = new MySqlCommand("INSERT INTO t_player (player_name, meilleur_score) VALUES (@val1, 0);", connection);
                registerCommand.Parameters.AddWithValue("@val1", PlayerName.Text);
                registerCommand.Prepare();

                registerCommand.ExecuteReader();

                connection.Close();
            }
        }

    }
}
