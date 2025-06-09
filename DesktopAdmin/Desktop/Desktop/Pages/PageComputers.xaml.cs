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
    /// Логика взаимодействия для PageComputers.xaml
    /// </summary>
    public partial class PageComputers : Page
    {
        int pageNow = 0;
        int pageSelected = 1000;
        List<Computer> computers = new List<Computer>();
        public PageComputers()
        {
            InitializeComponent();

            ComboSelected.ItemsSource = new List<string>() { "Все", "2", "5", "10", "25", };
            ComboSelected.SelectedIndex = 0;
        }

        private async Task Refresh()
        {
            computers = await NetManage.Get<List<Computer>>("api/computers/");

            computers = computers.Where(x => x.name.ToLower().Contains(Search.Text.ToLower())).ToList();

            pageNow = 0;

            RefreshItems();
        }

        private void RefreshItems()
        {
            var items = computers.Skip(pageNow * pageSelected).Take(pageSelected).ToList();

            ListItems.ItemsSource = null;
            ListItems.ItemsSource = items;

            DataItems.ItemsSource = null;
            DataItems.ItemsSource = items;

            TextAll.Text = $"Всего найдено: {computers.Count()} шт.";
            TextPages.Text = $"Записи с {pageNow * pageSelected + 1} до {pageNow * pageSelected + items.Count()} из {computers.Count()} записей";
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
            if (pageNow < computers.Count() / pageSelected + (computers.Count() % pageSelected == 0 ? 0 : 1) - 1) pageNow++;
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

        private void BtnEdit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var computer = (sender as TextBlock).DataContext as Computer;
            if (computer == null) return;

            NavigationService.Navigate(new PageComputer(computer));
        }

        private async void BtnRemove_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var computer = (sender as TextBlock).DataContext as Computer;
            if (computer == null) return;

            var result = MessageBox.Show("Вы точно хотите удалить?", "Предупреждение", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            var resultDelete = await NetManage.Delete($"api/classes/{computer.id}/");

            if (resultDelete.IsSuccessStatusCode) App.MessageToast("Успешно удален", 2);
            else App.MessageToast("Ошибка удаления", 0);

            await Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var computer = new Computer() { user = App.User.MainUser, };

            NavigationService.Navigate(new PageComputer(computer));
        }

        private void BtnUse_Click(object sender, RoutedEventArgs e)
        {
            var computer = (sender as Button).DataContext as Computer;
            if (computer == null) return;

            NavigationService.Navigate(new PageUseComputer(computer));
        }
    }
}
