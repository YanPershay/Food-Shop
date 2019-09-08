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
    /// Логика взаимодействия для Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        public Stock()
        {
            InitializeComponent();
        }

        public string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FoodShop;Integrated Security=True";

        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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

        public int Count { get; set; }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Combo.Text == "")
            {
                MessageBox.Show("Выберите тип блюда!");
            }
            else if (NameBox.Text == "" || CountBox.Text == "" || PriceBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                string typeDish;

                if (Combo.Text == "Первое")
                {
                    typeDish = "SOUPS";
                }
                else if (Combo.Text == "Второе")
                {
                    typeDish = "GARNIERS";
                }
                else if (Combo.Text == "Фастфуд")
                {
                    typeDish = "FASTFOOD";
                }
                else
                {
                    typeDish = "DRINKS";
                }

                string sqlExpression = $"SELECT NAME FROM PRODUCTS WHERE TYPE='{typeDish}' AND NAME='{NameBox.Text}'";

                string sqlExpression2 = $"INSERT INTO PRODUCTS (TYPE, NAME, COUNTS, PRICE) VALUES ('{typeDish}','{NameBox.Text}', {CountBox.Text}, {PriceBox.Text})";

                string sqlExpression3 = $"SELECT COUNTS FROM PRODUCTS WHERE TYPE='{typeDish}' AND NAME='{NameBox.Text}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    try
                    {
                        if (sqlDataReader.HasRows)
                        {
                            sqlDataReader.Close();
                            SqlCommand sqlCommand3 = new SqlCommand(sqlExpression3, connection);
                            Count = Convert.ToInt32(sqlCommand3.ExecuteScalar());

                            int newCount = Count + Convert.ToInt32(CountBox.Text);

                            string sqlExpression4 = $"UPDATE PRODUCTS SET COUNTS = {newCount}, PRICE={PriceBox.Text} WHERE TYPE='{typeDish}' AND NAME='{NameBox.Text}'";

                            SqlCommand sqlCommand4 = new SqlCommand(sqlExpression4, connection);
                            int number2 = sqlCommand4.ExecuteNonQuery();
                            MessageBox.Show("Object updated!");
                        }
                        else
                        {
                            sqlDataReader.Close();
                            SqlCommand sqlCommand2 = new SqlCommand(sqlExpression2, connection);
                            int number = sqlCommand2.ExecuteNonQuery();
                            MessageBox.Show("Object added.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Нет данных.");
                    }
                }
            }
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            if(Combo2.Text == "")
            {
                MessageBox.Show("Выберите что вам показать.");
            }
            else if (Combo2.Text == "Все")
            {
                string sqlExpression = $"SELECT * FROM PRODUCTS";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        List<Classes.StockCharacteristics> listProducts = new List<Classes.StockCharacteristics>();
                        while (sqlDataReader.Read())
                        {
                            Classes.StockCharacteristics product = new Classes.StockCharacteristics()
                            {
                                Id = sqlDataReader.GetValue(0),
                                Type = sqlDataReader.GetValue(1),
                                Name = sqlDataReader.GetValue(2),
                                Count = sqlDataReader.GetValue(3),
                                Price = sqlDataReader.GetValue(4)
                            };
                            listProducts.Add(product);

                        }
                        stockGrid.ItemsSource = listProducts;
                    }
                    else
                    {
                        MessageBox.Show("No strings!");
                    }
                }
            }
            else
            {

                string typeDish;

                if (Combo2.Text == "Первое")
                {
                    typeDish = "SOUPS";
                }
                else if (Combo2.Text == "Второе")
                {
                    typeDish = "GARNIERS";
                }
                else if (Combo2.Text == "Фастфуд")
                {
                    typeDish = "FASTFOOD";
                }
                else
                {
                    typeDish = "DRINKS";
                }

                string sqlExpression = $"SELECT * FROM PRODUCTS WHERE TYPE='{typeDish}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        List<Classes.StockCharacteristics> listProducts = new List<Classes.StockCharacteristics>();
                        while (sqlDataReader.Read())
                        {
                            Classes.StockCharacteristics product = new Classes.StockCharacteristics()
                            {
                                Id = sqlDataReader.GetValue(0),
                                Type = sqlDataReader.GetValue(1),
                                Name = sqlDataReader.GetValue(2),
                                Count = sqlDataReader.GetValue(3),
                                Price = sqlDataReader.GetValue(4)
                            };
                            listProducts.Add(product);

                        }
                        stockGrid.ItemsSource = listProducts;
                    }
                    else
                    {
                        MessageBox.Show("No strings!");
                    }
                }
            }
        }

        private void Box_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить только цифры.");
            }
        }

        private void NameBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
