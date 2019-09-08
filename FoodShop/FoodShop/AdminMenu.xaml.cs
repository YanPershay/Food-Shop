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

namespace FoodShop
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

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

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект \n Першай Ян \n 2 курс 8 группа \n Copyright 2019 (c)");
        }
    }
}
