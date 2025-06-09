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

namespace Desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для UserPassword.xaml
    /// </summary>
    public partial class UserPassword : UserControl
    {
        bool IsVisible = false;
        public UserPassword()
        {
            InitializeComponent();
        }

        private void BtnSee_Click(object sender, RoutedEventArgs e)
        {
            IsVisible = !IsVisible;

            if (IsVisible)
            {
                TextText.Text = PasswordText.Password;
                TextText.Visibility = Visibility.Visible;
                PasswordText.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextText.Visibility = Visibility.Collapsed;
                PasswordText.Visibility = Visibility.Visible;
            }
        }

        private void TextText_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordText.Password = TextText.Text;
        }
    }
}
