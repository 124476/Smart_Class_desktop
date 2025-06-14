using Desktop.Models;
using Desktop.Servies;
using Newtonsoft.Json;
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
    /// Логика взаимодействия для PageFoodwork.xaml
    /// </summary>
    public partial class PageFoodwork : Page
    {
        Foodwork ContextFoodwork;
        public PageFoodwork(Foodwork foodwork)
        {
            InitializeComponent();

            ContextFoodwork = foodwork;

            DataContext = ContextFoodwork;

            RefreshCombo();
        }

        private async void RefreshCombo()
        {
            var foods = await NetManage.Get<List<Food>>("api/foods/");

            ComboFoods.ItemsSource = foods;
            try
            {
                ComboFoods.SelectedItem = foods.FirstOrDefault(x => x.id == ContextFoodwork.food);
            }
            catch
            {

            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ComboFoods.SelectedIndex == -1)
            {
                App.MessageToast("Заполните все поля", 1);
                return;
            }

            ContextFoodwork.food = (ComboFoods.SelectedItem as Food).id;

            var json = new FoodworkSend()
            {
                food = ContextFoodwork.food,
                date = ContextFoodwork.date.ToString("yyyy-MM-dd")
            };

            if (ContextFoodwork.id == 0)
            {
                var result = await NetManage.Post("api/foodworks/", json);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно добавлен", 2);
                else App.MessageToast("Ошибка добавления", 0);
            }
            else
            {
                var result = await NetManage.Put($"api/foodworks/{ContextFoodwork.id}/", json);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно изменен", 2);
                else App.MessageToast("Ошибка изменения", 0);
            }

            NavigationService.GoBack();
        }
    }
}
