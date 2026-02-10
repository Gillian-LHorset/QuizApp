using System;
using System.Collections.Generic;
using System.Linq;
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

        public QuizPage() {
            InitializeComponent();

            using MySqlConnection connection = new MySqlConnection("Server=localhost;Port=6033;User ID=root;Password=root;Database=db_quizapp");
            connection.Open();

            using MySqlCommand command = new MySqlCommand("SELECT * FROM t_question ORDER BY RAND() LIMIT 1;", connection);

            using MySqlDataReader reader = command.ExecuteReader();

            int[] randomArray = {1, 2, 3, 4};

            Random random = new Random();




            if (reader.Read()) {

                TextBox themeText = new TextBox {
                    Text = "Theme : " + reader.GetString(1),
                    Width = 300,
                    Height = 50,
                    TextAlignment = TextAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,

                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,

                    Cursor = Cursors.Arrow,
                    Margin = new Thickness(0, 20, 0, 0)
                };

                TextBox enonceText = new TextBox {
                    Text = "Question : " + reader.GetString(2),
                    Width = 300,
                    Height = 50,
                    TextAlignment = TextAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,

                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,

                    Cursor = Cursors.Arrow,
                    Margin = new Thickness(0, 100, 0, 0)
                };

                MainGrid.Children.Add(themeText);
                MainGrid.Children.Add(enonceText);

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

            Frame newQuizPage = new Frame();

            this.Content = newQuizPage;

            newQuizPage.Content = new QuizPage();
        }

        private void Restart_Button(object sender, RoutedEventArgs e) {
            Frame newNameSelectPage = new Frame();

            this.Content = newNameSelectPage;

            newNameSelectPage.Content = new NameSelectPage();
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
    }
}
