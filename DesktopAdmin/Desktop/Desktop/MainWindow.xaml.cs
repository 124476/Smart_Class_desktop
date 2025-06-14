using Desktop.Models;
using Desktop.Pages;
using Desktop.Servies;
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

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.Delay(1000).Wait();

            App.MainWindow = this;

            TextNav.Text = "Главная";
            MyFrame.Navigate(new PageLogin());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Главная";
            MyFrame.Navigate(new PageLogin());
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnMenu.ContextMenu.IsOpen = true;
            BtnMenu.ContextMenu.PlacementTarget = BtnMenu;
            BtnMenu.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
        }

        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Главная";
            MyFrame.Navigate(new PageMain());
        }

        private void BtnNav_Click(object sender, RoutedEventArgs e)
        {
            if (StackNav.Visibility == Visibility.Visible) StackNav.Visibility = Visibility.Collapsed;
            else StackNav.Visibility = Visibility.Visible;
        }

        private void MyFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MyFrame.Content.GetType() == typeof(PageLogin))
            {
                ColNav.Width = new GridLength(0);
                RowHeader.Height = new GridLength(0);
                BtnMenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                ColNav.Width = GridLength.Auto;
                RowHeader.Height = GridLength.Auto;
                BtnMenu.Visibility = Visibility.Visible;
            }

            DataContext = null;
            DataContext = App.User;
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Пользователи";
            MyFrame.Navigate(new PageUsers());
        }

        private void BtnNews_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Новости";
            MyFrame.Navigate(new PageNews());
        }

        private void BtnFoods_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Столовая / Питание";
            MyFrame.Navigate(new PageFoods());
        }

        private void BtnWorks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnProblems_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Технические проблемы";
            MyFrame.Navigate(new PageProblems());
        }

        private void BtnClassses_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Администрирование / Классы";
            MyFrame.Navigate(new PageClasses());
        }

        private void BtnComputers_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Администрирование / Компьютеры";
            MyFrame.Navigate(new PageComputers());
        }

        private void BtnFoodworks_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Столовая / Расписание питания";
            MyFrame.Navigate(new PageFoodworks());
        }

        private void BtnObjeccts_Click(object sender, RoutedEventArgs e)
        {
            TextNav.Text = "Карточки обучения";
            MyFrame.Navigate(new PageObjects());
        }
    }
}
