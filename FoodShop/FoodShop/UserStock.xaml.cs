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
    /// Логика взаимодействия для UserStock.xaml
    /// </summary>
    public partial class UserStock : Window
    {
        public UserStock()
        {
            InitializeComponent();
        }

        public string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FoodShop;Integrated Security=True";

        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            UserStock userStock = new UserStock();
            userStock.Show();
            this.Close();
        }

        private void ToOrder_Click(object sender, RoutedEventArgs e)
        {
            MakingOrder makingOrder = new MakingOrder();
            makingOrder.Show();
            this.Close();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект \n Першай Ян \n 2 курс 8 группа \n Copyright 2019 (c)");
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            if (Combo2.Text == "")
            {
                MessageBox.Show("Выберите тип блюда!");
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

    }
}
