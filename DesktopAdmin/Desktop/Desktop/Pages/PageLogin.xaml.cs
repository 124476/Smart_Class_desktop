using Desktop.Models;
using Desktop.Servies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var password = Password.PasswordText.Password;

            try
            {
                var loginData = new AuthUser() { username = login, password = password };
                var loginResponse = await NetManage.Post("api/login/", loginData);
                if (loginResponse.IsSuccessStatusCode)
                {
                    NetManage.SetBasicAuth(login, password);

                    var responseContent = await loginResponse.Content.ReadAsStringAsync();

                    App.User = JsonConvert.DeserializeObject<User>(responseContent);

                    NavigationService.Navigate(new PageMain());

                    App.MessageToast("Совершен успешный вход", 2);
                }
                else App.MessageToast("Неверные данные", 0);
            }
            catch
            {
                App.MessageToast("Ошибка входа", 0);
            }
        }

        private void TextSignup_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start(App.host + "auth/signup/");
        }
    }
}
