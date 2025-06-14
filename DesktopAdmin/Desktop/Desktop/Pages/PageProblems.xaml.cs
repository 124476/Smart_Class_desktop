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
    /// Логика взаимодействия для PageProblems.xaml
    /// </summary>
    public partial class PageProblems : Page
    {
        int pageNow = 0;
        int pageSelected = 1000;
        List<Problem> problems = new List<Problem>();
        public PageProblems()
        {
            InitializeComponent();

            ComboSelected.ItemsSource = new List<string>() { "Все", "2", "5", "10", "25", };
            ComboSelected.SelectedIndex = 0;
        }

        private async Task Refresh()
        {
            problems = await NetManage.Get<List<Problem>>("api/problems/");

            problems = problems.OrderBy(x => x.status).ToList();

            problems = problems.Where(x => x.name.ToLower().Contains(Search.Text.ToLower())).ToList();

            pageNow = 0;

            RefreshItems();
        }

        private void RefreshItems()
        {
            var items = problems.Skip(pageNow * pageSelected).Take(pageSelected).ToList();

            ListItems.ItemsSource = null;
            ListItems.ItemsSource = items;

            DataItems.ItemsSource = null;
            DataItems.ItemsSource = items;

            TextAll.Text = $"Всего найдено: {problems.Count()} шт.";
            TextPages.Text = $"Записи с {pageNow * pageSelected + 1} до {pageNow * pageSelected + items.Count()} из {problems.Count()} записей";
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
            if (pageNow < problems.Count() / pageSelected + (problems.Count() % pageSelected == 0 ? 0 : 1) - 1) pageNow++;
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

        private async void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            var problem = (sender as Button).DataContext as Problem;
            if (problem == null) return;

            problem.status = 2;

            var result = await NetManage.Put($"api/problems/{problem.id}/", problem);
            if (result.IsSuccessStatusCode) App.MessageToast("Успешно завершена", 2);
            else App.MessageToast("Ошибка завершения", 0);

            await Refresh();
        }
    }
}
