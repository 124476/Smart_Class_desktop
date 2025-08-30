using Desktop.Models;
using Desktop.Servies;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string host = "https://smart-class.onrender.com/";
        public static List<User> Users = new List<User>();

        public static User User;
        public static MainWindow MainWindow;

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Error");
        }

        public static void MessageToast(string description, int type)
        {
            var random = new Random();

            var border = new Border() { Height = 30, CornerRadius = new CornerRadius(10), Margin = new Thickness(3), };
            var stackPanel = new Grid()
            {
                Margin = new Thickness(5),
            };

            var textBlock = new TextBlock()
            {
                Margin = new Thickness(0, 0, 30, 0),
                VerticalAlignment = VerticalAlignment.Center,
            };

            var textBtn = new TextBlock()
            {
                Text = "×",
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
            };
            var btn = new Button() { 
                Width = 20, 
                Height = 20,
                Background = Brushes.Transparent, 
                BorderThickness = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Right,
            };
            btn.Tag = border;
            btn.Content = textBtn;
            btn.Click += Btn_Click;

            var timer = new DispatcherTimer();
            timer.Tag = border;
            timer.Tick += Timer_Tick;

            if (type == 0)
            {
                textBlock.Text = $"Ошибка: {description}";
                border.Background = Brushes.Red;
            }
            else if (type == 1)
            {
                textBlock.Text = $"⚠️ Внимание: {description}";
                border.Background = Brushes.Yellow;
            }
            else
            {
                textBlock.Text = $"✓ Успешно: {description}";
                border.Background = Brushes.DeepSkyBlue;
            }

            timer.Interval = TimeSpan.FromSeconds(7);
            timer.Start();

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(btn);

            border.Child = stackPanel;
            App.MainWindow.StackToast.Children.Add(border);
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            ((sender as DispatcherTimer).Tag as Border).Visibility = Visibility.Collapsed;
        }

        private static void Btn_Click(object sender, RoutedEventArgs e)
        {
            ((sender as Button).Tag as Border).Visibility = Visibility.Collapsed;
        }
    }
}
