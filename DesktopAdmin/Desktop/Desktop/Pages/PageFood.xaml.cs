using Desktop.Models;
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

namespace Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageFood.xaml
    /// </summary>
    public partial class PageFood : Page
    {
        Food ContextFood;
        public PageFood(Food food)
        {
            InitializeComponent();

            ContextFood = food;

            TextPrice.Text = food.price.Replace(".", ",");

            DataContext = ContextFood;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ContextFood.name) || string.IsNullOrEmpty(ContextFood.price))
            {
                App.MessageToast("Заполните все поля", 1);
                return;
            }

            if (ContextFood.id == 0)
            {
                var result = await NetManage.Post("api/foods/", ContextFood);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно добавлен", 2);
                else App.MessageToast("Ошибка добавления", 0);
            }
            else
            {
                var result = await NetManage.Put($"api/foods/{ContextFood.id}/", ContextFood);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно изменен", 2);
                else App.MessageToast("Ошибка изменения", 0);
            }

            NavigationService.GoBack();
        }

        string lastPrice = "";
        private void TextPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = TextPrice.Text;

                float price = float.Parse(text);

                ContextFood.price = text.Replace(",", ".");
                lastPrice = text;
            }
            catch
            {
                TextPrice.Text = lastPrice;
            }
        }
    }
}
