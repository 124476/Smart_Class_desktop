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
    /// Логика взаимодействия для PageFoods.xaml
    /// </summary>
    public partial class PageFoods : Page
    {
        int pageNow = 0;
        int pageSelected = 1000;
        List<Food> foods = new List<Food>();
        public PageFoods()
        {
            InitializeComponent();

            ComboSelected.ItemsSource = new List<string>() { "Все", "2", "5", "10", "25", };
            ComboSelected.SelectedIndex = 0;
        }

        private async Task Refresh()
        {
            foods = await NetManage.Get<List<Food>>("api/foods/");

            foods = foods.Where(x => x.name.ToLower().Contains(Search.Text.ToLower())).ToList();

            pageNow = 0;

            RefreshItems();
        }

        private void RefreshItems()
        {
            var items = foods.Skip(pageNow * pageSelected).Take(pageSelected).ToList();

            ListItems.ItemsSource = null;
            ListItems.ItemsSource = items;

            DataItems.ItemsSource = null;
            DataItems.ItemsSource = items;

            TextAll.Text = $"Всего найдено: {foods.Count()} шт.";
            TextPages.Text = $"Записи с {pageNow * pageSelected + 1} до {pageNow * pageSelected + items.Count()} из {foods.Count()} записей";
            TextNow.Text = $"{pageNow + 1}";
            TextVisible.Visibility = Visibility.Collapsed;
        }

        private void BtnList_Click(object sender, RoutedEventArgs e)
        {
            DataItems.Visibility = Visibility.Collapsed;
        }

        private void BtnTable_Click(object sender, RoutedEventArgs e)
        {
            DataItems.Visibility = Visibility.Visible;
        }

        private async void ComboSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                pageSelected = Int32.Parse(ComboSelected.SelectedItem as string);
            }
            catch
            {
                pageSelected = 1000;
            }

            await Refresh();
        }

        private async void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Refresh();
        }


        private void BtnDown_Click(object sender, RoutedEventArgs e)
        {
            if (pageNow > 0) pageNow--;
            RefreshItems();
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            if (pageNow < foods.Count() / pageSelected + (foods.Count() % pageSelected == 0 ? 0 : 1) - 1) pageNow++;
            RefreshItems();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

        private void DataItems_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var food = (sender as Button).DataContext as Food;
            if (food == null) return;

            NavigationService.Navigate(new PageFood(food));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var food = new Food() { user = App.User.MainUser, };

            NavigationService.Navigate(new PageFood(food));
        }
    }
}
