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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Windows.Threading;

namespace FoodShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public static bool DefinerMenu;
        public static string User { get; set; }
        public static string Id { get; set; }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FoodShop;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM REGISTRATION WHERE LOGIN = '{LoginBox.Text}' AND PASSWORD = '{PassBox.Password}'", connection);
            DataTable data = new DataTable();
            sda.Fill(data);

            if (LoginBox.Text == "admin777" && PassBox.Password == "admin777")
            {
                AdminMenu admin = new AdminMenu();
                DefinerMenu = false;
                User = "Admin";
                Id = "77";
                admin.Show();
                this.Close();
            }
            else
            {
                string sqlExpression = $"SELECT NAME FROM REGISTRATION WHERE LOGIN='{LoginBox.Text}'";
                string sqlExpression2 = $"SELECT ID FROM REGISTRATION WHERE LOGIN='{LoginBox.Text}'";

                using (connection)
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    User = Convert.ToString(sqlCommand.ExecuteScalar());
                    SqlCommand sqlCommand2 = new SqlCommand(sqlExpression2, connection);
                    Id = Convert.ToString(sqlCommand2.ExecuteScalar());
                }

                if (data.Rows.Count == 1)
                {
                    UserMenu user = new UserMenu();
                    DefinerMenu = true;
                    user.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект \n Першай Ян \n 2 курс 8 группа \n Copyright 2019 (c)");
        }
    }
}
