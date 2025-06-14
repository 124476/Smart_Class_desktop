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
    /// Логика взаимодействия для PageFoodworkToday.xaml
    /// </summary>
    public partial class PageFoodworkToday : Page
    {
        public List<Foodwork> foodworks = new List<Foodwork>();
        public DateTime? dateToday;
        public PageFoodworkToday(DateTime? dateNow)
        {
            InitializeComponent();

            dateToday = dateNow;
        }

        private async Task Refresh()
        {
            foodworks = await NetManage.Get<List<Foodwork>>("api/foodworks/");

            foodworks = foodworks.Where(x => x.date == dateToday).ToList();

            ListItems.ItemsSource = null;
            ListItems.ItemsSource = foodworks;

            TextAll.Text = $"Всего: {foodworks.Count()} шт.";
            TextVisible.Visibility = Visibility.Collapsed;
        }

        private async void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Refresh();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

        private void DataItems_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnEdit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var foodwork = (sender as TextBlock).DataContext as Foodwork;
            if (foodwork == null) return;

            NavigationService.Navigate(new PageFoodwork(foodwork));
        }

        private async void BtnRemove_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var foodwork = (sender as TextBlock).DataContext as Foodwork;
            if (foodwork == null) return;

            var result = MessageBox.Show("Вы точно хотите удалить?", "Предупреждение", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            var resultDelete = await NetManage.Delete($"api/foodworks/{foodwork.id}/");

            if (resultDelete.IsSuccessStatusCode) App.MessageToast("Успешно удален", 2);
            else App.MessageToast("Ошибка удаления", 0);

            await Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var foodwork = new Foodwork() { date = dateToday ?? DateTime.Now.Date, };

            NavigationService.Navigate(new PageFoodwork(foodwork));
        }
    }
}
