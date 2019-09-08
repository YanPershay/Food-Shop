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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
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

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект \n Першай Ян \n 2 курс 8 группа \n Copyright 2019 (c)");
        }

        private void Login_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить только цифры(напр. номер телефона)!");
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            #region Validate
            try
            {


                if (NameBox.Text == "" || SurnameBox.Text == "" || LoginBox.Text == "" || PassBox1.Password == "")
                {
                    MessageBox.Show("Заполните пустые поля!");
                }
                else
                {
                    if (NameBox.Text.Length > 20)
                    {
                        MessageBox.Show("Слишком длинное имя! Сократите.");
                    }
                    else if (SurnameBox.Text.Length > 20)
                    {
                        MessageBox.Show("Слишком длинная фамилия! Сократите.");
                    }
                    else if (LoginBox.Text.Length > 12)
                    {
                        MessageBox.Show("Логин не больше 12 символов!");
                    }
                    else if (LoginBox.Text.Length < 7)
                    {
                        MessageBox.Show("Логин не короче 7 символов");
                    }
                    else if (PassBox1.Password.Length > 15)
                    {
                        MessageBox.Show("Пароль не длиннее 15 символов");
                    }
                    else if (PassBox1.Password.Length < 5)
                    {
                        MessageBox.Show("Пароль не короче 5 символов!");
                    }
                    else if (PassBox1.Password != PassBox2.Password)
                    {
                        MessageBox.Show("Повторите пароль правильно");
                        PassBox2.Password = "";
                    }
                    else
                    {
                        try
                        {

                            Guid guid = Guid.NewGuid();

                            string sqlExpression = $"SELECT * FROM REGISTRATION WHERE LOGIN = '{LoginBox.Text}'";

                            string sqlExpression2 = $"INSERT INTO REGISTRATION (ID, NAME, SURNAME, LOGIN, PASSWORD) VALUES('{guid}','{NameBox.Text}','{SurnameBox.Text}','{LoginBox.Text}','{PassBox1.Password}')";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                                if (sqlDataReader.HasRows)
                                {
                                    MessageBox.Show("Данный логин уже занят.");
                                }
                                else
                                {
                                    sqlDataReader.Close();
                                    SqlCommand sqlCommand2 = new SqlCommand(sqlExpression2, connection);
                                    int number = sqlCommand2.ExecuteNonQuery();
                                    connection.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        MessageBox.Show("Вы успешно зарегестрированы!");

                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Некорректные данные.");
            }
            #endregion
        }
    }
}
