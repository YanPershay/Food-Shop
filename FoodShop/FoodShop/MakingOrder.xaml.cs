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

namespace FoodShop
{
    /// <summary>
    /// Логика взаимодействия для MakingOrder.xaml
    /// </summary>
    public partial class MakingOrder : Window
    {
        public string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FoodShop;Integrated Security=True";

        public MakingOrder()
        {
            InitializeComponent();
        }

        private void Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Выберите дату");
            }
        }

        void FillDishesCombo()
        {
            string dishType;

            if (TypeDish.Text == "Фастфуд")
            {
                dishType = "DRINKS";
            }
            else if (TypeDish.Text == "Напитки")
            {
                dishType = $"SOUPS";
            }
            else if (TypeDish.Text == "Первое")
            {
                dishType = "GARNIERS";
            }
            else if (TypeDish.Text == "Второе")
            {
                dishType = "FASTFOOD";
            }
            else
            {
                dishType = $"DRINKS";
            }

            string sqlExpression = $"SELECT * FROM PRODUCTS WHERE TYPE='{dishType}'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
            SqlDataReader sqlDataReader;

            connection.Open();
            sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                string name = sqlDataReader.GetString(2);
                Dish.Items.Add(name);
            }
        }

        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"TRUNCATE TABLE USER_ORDER";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);

                int number = sqlCommand.ExecuteNonQuery();
            }

            this.Close();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.DefinerMenu)
            {
                UserMenu user = new UserMenu();
                user.Show();
                this.Close();
            }
            else if (!MainWindow.DefinerMenu)
            {
                AdminMenu admin = new AdminMenu();
                admin.Show();
                this.Close();
            }
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"TRUNCATE TABLE USER_ORDER";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);

                int number2 = sqlCommand.ExecuteNonQuery();
            }

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            UserStock userStock = new UserStock();
            userStock.Show();
            this.Close();
        }

        private void TypeDish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dish.Items.Clear();
            FillDishesCombo();
        }

        public int Value { get; set; }
        public int Price { get; set; }
        public int IdProduct { get; set; }
        public int Sum { get; set; }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TypeDish.Text == "")
            {
                MessageBox.Show("Выберите тип блюда!");
            }
            else
            {
                string dishType;

                if (TypeDish.Text == "Фастфуд")
                {
                    dishType = "FASTFOOD";
                }
                else if (TypeDish.Text == "Напитки")
                {
                    dishType = "DRINKS";
                }
                else if (TypeDish.Text == "Первое")
                {
                    dishType = "SOUPS";
                }
                else if (TypeDish.Text == "Второе")
                {
                    dishType = "GARNIERS";
                }
                else
                {
                    dishType = "DRINKS";
                }
                try
                {

                    if (Dish.Text == "")
                    {
                        MessageBox.Show("Выберите блюдо!");
                    }
                    else
                    {
                        string sqlExpression = $"SELECT COUNTS FROM PRODUCTS WHERE NAME = '{Dish.Text}' AND TYPE='{dishType}'";
                        string sqlExpression4 = $"SELECT PRICE FROM PRODUCTS WHERE NAME = '{Dish.Text}' AND TYPE='{dishType}'";
                        string sqlExpression5 = $"SELECT ID FROM PRODUCTS WHERE NAME = '{Dish.Text}' AND TYPE='{dishType}'";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                            SqlCommand sqlCommand4 = new SqlCommand(sqlExpression4, connection);
                            SqlCommand sqlCommand5 = new SqlCommand(sqlExpression5, connection);
                            IdProduct = Convert.ToInt32(sqlCommand5.ExecuteScalar());
                            Value = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            Price = Convert.ToInt32(sqlCommand4.ExecuteScalar());
                        }

                        if (Count.Text == "" || Date.Text == "" || Adress.Text == "" || Company.Text == "" || Number.Text == "")
                        {
                            MessageBox.Show("Заполните пустые поля!");
                        }
                        else if (Convert.ToDateTime(Date.Text) < DateTime.Now)
                        {
                            MessageBox.Show("Неверная дата!");
                        }
                        else
                        {
                            int newValue = Value - Convert.ToInt32(Count.Text);

                            Sum = Price * Convert.ToInt32(Count.Text);

                            if (newValue > 0)
                            {
                                string sqlExpression2 = $"INSERT INTO ORDERS (USER_ID, ID_PRODUCT, NAME_PRODUCT, COUNTS, DATE, ADRESS, COMPANY, NUMBE_ACCOUNT, SUMM)" +
                                       $"VALUES ('{MainWindow.Id}', '{IdProduct}','{Dish.Text}',{Count.Text}, CONVERT(VARCHAR, '{Date.Text}', 2),'{Adress.Text}','{Company.Text}','{Number.Text}', {Sum})";

                                string sqlExpression3 = $"UPDATE PRODUCTS SET COUNTS = {newValue} WHERE NAME='{Dish.Text}' AND TYPE='{dishType}'";

                                string sqlExpression7 = $"INSERT INTO USER_ORDER (NAME, USER_NAME, COUNTS, DATE, ADRESS, COMPANY, NUMBE_ACCOUNT, SUMM)" +
                                $"VALUES ('{Dish.Text}','{MainWindow.User}',{Count.Text}, CONVERT(VARCHAR, '{Date.Text}', 2),'{Adress.Text}','{Company.Text}','{Number.Text}', {Sum})";

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand sqlCommand2 = new SqlCommand(sqlExpression2, connection);
                                    int number = sqlCommand2.ExecuteNonQuery();
                                    SqlCommand sqlCommand3 = new SqlCommand(sqlExpression3, connection);
                                    SqlCommand sqlCommand7 = new SqlCommand(sqlExpression7, connection);
                                    int number7 = sqlCommand7.ExecuteNonQuery();

                                    int number2 = sqlCommand3.ExecuteNonQuery();
                                    MessageBox.Show("Object added.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Вы заказали много. На складе сейчас {Value} единиц");
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Неверные данные.");
                }
            }
        }

        public static int Total { get; set; }
        public static DateTime OrderDate { get; set; }

        private void ShowOrder_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression8 = "SELECT * FROM USER_ORDER";

            string sqlExpression9 = $"SELECT SUM(SUMM) FROM USER_ORDER WHERE USER_NAME='{MainWindow.User}'";
            string sqlExpression10 = $"SELECT DATE FROM USER_ORDER WHERE USER_NAME='{MainWindow.User}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand8 = new SqlCommand(sqlExpression8, connection);
                    SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
                    if (sqlDataReader8.HasRows)
                    {
                        List<Classes.UserOrder> listProducts = new List<Classes.UserOrder>();
                        while (sqlDataReader8.Read())
                        {
                            Classes.UserOrder order = new Classes.UserOrder()
                            {
                                Id = sqlDataReader8.GetValue(0),
                                NameUser = sqlDataReader8.GetValue(1),
                                Name = sqlDataReader8.GetValue(2),
                                Count = sqlDataReader8.GetValue(3),
                                Date = sqlDataReader8.GetValue(4),
                                Adress = sqlDataReader8.GetValue(5),
                                Company = sqlDataReader8.GetValue(6),
                                Number = sqlDataReader8.GetValue(7),
                                Sum = sqlDataReader8.GetValue(8)
                            };
                            listProducts.Add(order);

                        }
                        OrderGrid.ItemsSource = listProducts;
                    }
                    sqlDataReader8.Close();

                    SqlCommand sqlCommand9 = new SqlCommand(sqlExpression9, connection);
                    Total = Convert.ToInt32(sqlCommand9.ExecuteScalar());

                    SqlCommand sqlCommand10 = new SqlCommand(sqlExpression10, connection);
                    OrderDate = Convert.ToDateTime(sqlCommand10.ExecuteScalar());
                }
            }
            catch
            {
                MessageBox.Show("Заказ пуст!");
            }
        }

        private void Number_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить только цифры.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект \n Першай Ян \n 2 курс 8 группа \n Copyright 2019 (c)");
        }

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression8 = "SELECT * FROM USER_ORDER";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand8 = new SqlCommand(sqlExpression8, connection);
                SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
                if (!sqlDataReader8.HasRows)
                {
                    MessageBox.Show("Ваш заказ пуст.");
                }
                else
                {
                    Basket basket = new Basket();
                    basket.Show();
                    this.Close();
                }
            }
        }

    }
}
