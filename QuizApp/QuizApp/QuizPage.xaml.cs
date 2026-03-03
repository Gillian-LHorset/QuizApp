using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
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
    /// Logique d'interaction pour QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page {

        private SolidColorBrush _greenBackgroundBrush = new SolidColorBrush(Color.FromRgb(123, 252, 106));
        private SolidColorBrush _redBackgroundBrush = new SolidColorBrush(Color.FromRgb(255, 74, 74));

        public QuizPage(string playerName, int playerScore, int playerBestScore) {
            InitializeComponent();

            using MySqlConnection connection = new MySqlConnection("Server=localhost;Port=6033;User ID=root;Password=root;Database=db_quizapp");
            connection.Open();

            using MySqlCommand command = new MySqlCommand("SELECT * FROM t_question ORDER BY RAND() LIMIT 1;", connection);

            using MySqlDataReader reader = command.ExecuteReader();

            int[] randomArray = {1, 2, 3, 4};

            Random random = new Random();


            if (reader.Read()) {


                // theme box
                Border themeBorder = new Border {
                    Width = 300,
                    Height = 50,
                    VerticalAlignment = VerticalAlignment.Top,

                    Background = Brushes.White,

                    Margin = new Thickness(0, 20, 0, 0)
                };

                TextBlock themeText = new TextBlock {
                    Text = "Theme : " + reader.GetString(1),
                    TextAlignment = TextAlignment.Center,

                    VerticalAlignment = VerticalAlignment.Center,
                };



                // enoncé box

                Border enonceBorder = new Border {
                    Width = 300,
                    Height = 50,
                    VerticalAlignment = VerticalAlignment.Top,
                    
                    Background = Brushes.White,

                    Margin = new Thickness(0, 100, 0, 0)
                };

                TextBlock enonceText = new TextBlock {
                    Text = "Question : " + reader.GetString(2),
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Center,


                };

                // name of the player

                TextBlock playerNameText = new TextBlock {
                    Text = "Joueur : " + playerName, 
                    TextAlignment = TextAlignment.Left,
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,

                    Margin = new Thickness(20, 20, 0, 0)
                };



                TextBlock BestScoreBT = new TextBlock {
                    Text = "Meilleur score : " + playerBestScore,
                    TextAlignment = TextAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Foreground = Brushes.White,

                    Margin = new Thickness(0, 20, 50, 0)
                };

                TextBlock ScoreBT = new TextBlock {
                    Text = "Score : " + playerScore,
                    TextAlignment = TextAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Foreground = Brushes.White,

                    Margin = new Thickness(0, 50, 50, 0)
                };



                themeBorder.Child = themeText;
                enonceBorder.Child = enonceText;

                // add the boxes in the view
                MainGrid.Children.Add(themeBorder);
                MainGrid.Children.Add(enonceBorder);
                MainGrid.Children.Add(playerNameText);

                // 
                MainGrid.Children.Add(BestScoreBT);
                MainGrid.Children.Add(ScoreBT);

                // randomise the order of the answerts
                int[] shuffledArray = randomArray.OrderBy(x => random.Next()).ToArray();


                CreateFakeButton(reader.GetString(4), shuffledArray[0]);
                CreateFakeButton(reader.GetString(5), shuffledArray[1]);
                CreateFakeButton(reader.GetString(6), shuffledArray[2]);
                CreateCorrectButton(reader.GetString(3), shuffledArray[3]);


                    
                

            }
        }
        
        public void test_click(object sender, RoutedEventArgs e) {
            return;
        }

        private void CreateFakeButton(String contentText, int buttonLocation) {
            Button fakeButton = new Button {
                Content = new TextBlock {
                    Text = contentText,
                    TextWrapping = TextWrapping.Wrap,
                    FontWeight = FontWeights.Medium,
                },
                Width = 140,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Tag = "false",
                Cursor = Cursors.Hand,

            };

            fakeButton.Click += Button_False;

            SetButtonLocation(fakeButton, buttonLocation);

            MainGrid.Children.Add(fakeButton);
        }

        private void CreateCorrectButton(String contentText, int buttonLocation) {
            Button correctButton = new Button {
                Content = new TextBlock {
                    Text = contentText,
                    TextWrapping = TextWrapping.Wrap,
                    FontWeight = FontWeights.Medium,
                },
                Width = 140,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Tag = "true",
                Cursor = Cursors.Hand,
            };

            correctButton.Click += Button_Correct;

            SetButtonLocation(correctButton, buttonLocation);

            MainGrid.Children.Add(correctButton);

        }

        private Button SetButtonLocation(Button button, int buttonLocation) {
            switch (buttonLocation) {
                // topLeft
                case 1:
                    button.Margin = new Thickness(180, 100, 0, 0);
                    break;
                // topRight
                case 2:
                    button.Margin = new Thickness(0, 100, 180, 0);
                    break;
                // bottomLeft
                case 3:
                    button.Margin = new Thickness(180, 0, 0, 100);
                    break;
                // bottomRight
                case 4:
                    button.Margin = new Thickness(0, 0, 180, 100);
                    break;
            }

            return button;
        }

        private void Button_False(object sender, RoutedEventArgs e) {
            TextBox falseText = new TextBox {
                Text = "Mauvaise réponse !",
                Width = 150,
                Height = 80,

                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,

                Background = _redBackgroundBrush,
            };

            ColorButtons();

            MainGrid.Children.Add(falseText);

            // Restart the game
            Button restartButton = new Button {
                Content = new TextBlock {
                    Text = "Revenir à l'acceuil",
                    FontWeight = FontWeights.Medium,
                },

                Width = 140,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Tag = "true",
                Cursor = Cursors.Hand,
                Margin = new Thickness(0, 0, 0, 100),
            };


            if (Window.GetWindow(this) is MainWindow mainWindow) {
                if (mainWindow.playerScore > mainWindow.playerBestScore) {
                    RegisterPlayerBestScore(mainWindow.playerName, mainWindow.playerScore);
                }
            }

            restartButton.Click += Restart_Button;

            MainGrid.Children.Add(restartButton);
        }

        private void Button_Correct(object sender, RoutedEventArgs e) {
            TextBox correctText = new TextBox {
                Text = "Bonne réponse !",
                Width = 150,
                Height = 80,

                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,

                Background = _greenBackgroundBrush,
            };

            ColorButtons();

            MainGrid.Children.Add(correctText);
            if (Window.GetWindow(this) is MainWindow mainWindow) {
                mainWindow.IncrementPlayerScore();
                mainWindow.NavigateToQuizPage();
            }

        }

        private void Restart_Button(object sender, RoutedEventArgs e) {
            if (Window.GetWindow(this) is MainWindow mainWindow) {
                mainWindow.ResetPlayerScore();
                mainWindow.ReturnToHomePage();
            }
        }

        private void ColorButtons() {
            foreach (Button button in MainGrid.Children.OfType<Button>()) {
                if (button.Tag.Equals("false")) {
                    button.Background = _redBackgroundBrush;
                } else if (button.Tag.Equals("true")) {
                    button.Background = _greenBackgroundBrush;
                }

                button.IsHitTestVisible = false;
            }
        }

        public void RegisterPlayerBestScore(string playerName, int score) {
            using MySqlConnection connection = new MySqlConnection("Server=localhost;Port=6033;User ID=root;Password=root;Database=db_quizapp");
            connection.Open();

            using MySqlCommand registerCommand = new MySqlCommand("UPDATE t_player SET meilleur_score = @val1 WHERE player_name = @val2;", connection);
            registerCommand.Parameters.AddWithValue("@val1", score);
            registerCommand.Parameters.AddWithValue("@val2", playerName);
            registerCommand.Prepare();

            registerCommand.ExecuteReader();

            connection.Close();
        }
    }
}
