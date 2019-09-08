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
using System.Net.Mail;
using System.Net;

namespace FoodShop
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public Basket()
        {
            InitializeComponent();

            UserDate.Content = MakingOrder.OrderDate.ToShortDateString();
            UserName.Content = MainWindow.User.ToString();
            TotalPrice.Content = MakingOrder.Total.ToString();
        }
        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FoodShop;Integrated Security=True";

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"TRUNCATE TABLE USER_ORDER";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);

                int number2 = sqlCommand.ExecuteNonQuery();
            }
            this.Close();
        }

        private void ToOrder_Click(object sender, RoutedEventArgs e)
        {
            MakingOrder mainWindow = new MakingOrder();
            mainWindow.Show();
            this.Close();
        }

        private void OnMain_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"TRUNCATE TABLE USER_ORDER";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);

                int number2 = sqlCommand.ExecuteNonQuery();
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект \n Першай Ян \n 2 курс 8 группа \n Copyright 2019 (c)");
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            if (MailBox.Text != "")
            {
                try
                {
                    MailAddress from = new MailAddress("yanpershay@gmail.com", "Food shop");

                    MailAddress to = new MailAddress($"{MailBox.Text}");

                    MailMessage m = new MailMessage(from, to);

                    m.Subject = "Заказ еды";

                    m.Body = $"<h2>Здравствуйте, {MainWindow.User}. Ваш заказ доставят {MakingOrder.OrderDate}. Сумма заказа {MakingOrder.Total}. Спасибо за покупку! </h2>";

                    m.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                    smtp.Credentials = new NetworkCredential("yanpershay@gmail.com", "relict27");
                    smtp.EnableSsl = true;
                    smtp.Send(m);

                    MessageBox.Show("Check mail");


                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Извините, техническая ошибка.");
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();

                    string sqlExpression2 = $"TRUNCATE TABLE USER_ORDER";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand sqlCommand2 = new SqlCommand(sqlExpression2, connection);

                        int number2 = sqlCommand2.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Спасибо за покупку!");
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }


            string sqlExpression = $"TRUNCATE TABLE USER_ORDER";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);

                int number2 = sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
