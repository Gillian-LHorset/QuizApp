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
using MySqlConnector;

namespace QuizApp {
    /// <summary>
    /// Logique d'interaction pour QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page {
        public QuizPage() {
            InitializeComponent();

            using MySqlConnection connection = new MySqlConnection("Server=localhost;Port=6033;User ID=root;Password=root;Database=db_quizapp");
            connection.Open();

            using MySqlCommand command = new MySqlCommand("SELECT * FROM t_question ORDER BY RAND() LIMIT 1;", connection);

            using MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read()) {
                Button monBoutonVrais = new Button {
                    Content = new TextBlock {
                        Text = reader.GetString(3),
                        TextWrapping = TextWrapping.Wrap
                    },

                    Width = 140,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };

                Button monBoutonFaux1 = new Button {
                    Content = new TextBlock {
                        Text = reader.GetString(4),
                        TextWrapping = TextWrapping.Wrap
                    },

                    Width = 140,                    
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top
                };

                Button monBoutonFaux2 = new Button {
                    Content = new TextBlock {
                        Text = reader.GetString(5),
                        TextWrapping = TextWrapping.Wrap
                    },
                    Width = 140,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom
                };

                Button monBoutonFaux3 = new Button {
                    Content = new TextBlock {
                        Text = reader.GetString(6),
                        TextWrapping = TextWrapping.Wrap
                    },
                    Width = 140,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom
                };

                MainGrid.Children.Add(monBoutonVrais);
                MainGrid.Children.Add(monBoutonFaux1);
                MainGrid.Children.Add(monBoutonFaux2);
                MainGrid.Children.Add(monBoutonFaux3);
            }
        }
        
        public void test_click(object sender, RoutedEventArgs e) {
            return;
        }

        public void CreateButton(String contentButton) {
            Button monBouton = new Button {
                Content = contentButton,
                Width = 120,
                Height = 40,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };


            MainGrid.Children.Add(monBouton);
        }
    }
}
