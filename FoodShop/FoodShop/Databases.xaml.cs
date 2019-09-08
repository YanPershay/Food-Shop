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
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace FoodShop
{
    /// <summary>
    /// Логика взаимодействия для Databases.xaml
    /// </summary>
    public partial class Databases : Window
    {
        
        public Databases()
        {
            InitializeComponent();
        }

        public string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FoodShop;Integrated Security=True";

        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Box_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Выберите дату!");
            }
        }

        private void OnMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
            this.Close();
        }

        private void ToOrder_Click(object sender, RoutedEventArgs e)
        {
            MakingOrder makingOrder = new MakingOrder();
            makingOrder.Show();
            this.Close();
        }

        private void Story_Click(object sender, RoutedEventArgs e)
        {
            Databases databases = new Databases();
            databases.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект \n Першай Ян \n 2 курс 8 группа \n Copyright 2019 (c)");
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            
            
                string sqlExpression;

                if (DateFrom.Text == "" && DateTo.Text == "")
                {
                    sqlExpression = $"SELECT * FROM ORDERS";
                }
                else if (DateFrom.Text != "" && DateTo.Text == "")
                {
                    sqlExpression = $"SELECT * FROM ORDERS WHERE DATE > '{DateFrom.Text}'";
                }
                else if (DateFrom.Text == "" && DateTo.Text != "")
                {
                    sqlExpression = $"SELECT * FROM ORDERS WHERE DATE < '{DateTo.Text}'";
                }
                else if (Convert.ToDateTime(DateFrom.Text) > Convert.ToDateTime(DateTo.Text))
                {
                    MessageBox.Show("Неправильный диапазон дат.");
                    sqlExpression = $"SELECT * FROM ORDERS";
                }
                else 
                {
                    sqlExpression = $"SELECT * FROM ORDERS WHERE DATE < '{DateTo.Text}' and DATE > '{DateFrom.Text}'";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        List<Classes.Order> listProducts = new List<Classes.Order>();
                        while (sqlDataReader.Read())
                        {
                            Classes.Order order = new Classes.Order()
                            {
                                Id = sqlDataReader.GetValue(0),
                                NameUser = sqlDataReader.GetValue(1),
                                IdProduct = sqlDataReader.GetValue(2),
                                Name = sqlDataReader.GetValue(3),
                                Count = sqlDataReader.GetValue(4),
                                Date = sqlDataReader.GetValue(5),
                                Adress = sqlDataReader.GetValue(6),
                                Company = sqlDataReader.GetValue(7),
                                Number = sqlDataReader.GetValue(8),
                                Sum = sqlDataReader.GetValue(9)
                            };
                            listProducts.Add(order);

                        }
                        DateGrid.ItemsSource = listProducts;
                    }
                    else
                    {
                        MessageBox.Show("Заказов не было.");
                    }
                    sqlDataReader.Close();
                }
        }
    }
}
