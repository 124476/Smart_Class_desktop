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
using Object = Desktop.Models.Object;

namespace Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageObjects.xaml
    /// </summary>
    public partial class PageObjects : Page
    {
        public List<Object> objects = new List<Object>();
        public Object ContextObject = new Object() { user = App.User.MainUser };
        public PageObjects()
        {
            InitializeComponent();
        }

        private async Task Refresh()
        {
            objects = await NetManage.Get<List<Object>>("api/objects/");

            ListItems.ItemsSource = null;
            ListItems.ItemsSource = objects;

            TextAll.Text = $"Всего: {objects.Count()} шт.";
            TextVisible.Visibility = Visibility.Collapsed;

            DataContext = null;
            DataContext = ContextObject;
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
            ContextObject = (sender as TextBlock).DataContext as Object;

            DataContext = null;
            DataContext = ContextObject;

            StackForm.Visibility = Visibility.Visible;
            TextForm.Text = "Редактирование";
            BtnSave.Content = "Изменить";
        }

        private async void BtnRemove_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as TextBlock).DataContext as Object;
            if (item == null) return;

            var result = MessageBox.Show("Вы точно хотите удалить?", "Предупреждение", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            var resultDelete = await NetManage.Delete($"api/objects/{item.id}/");

            if (resultDelete.IsSuccessStatusCode) App.MessageToast("Успешно удален", 2);
            else App.MessageToast("Ошибка удаления", 0);

            ContextObject = new Object() { user = App.User.MainUser };

            await Refresh();

            TextForm.Text = "Добавление";
            BtnSave.Content = "Добавить";
        }

        private void BtnForm_Click(object sender, RoutedEventArgs e)
        {
            if (StackForm.Visibility == Visibility.Visible) StackForm.Visibility = Visibility.Collapsed;
            else StackForm.Visibility = Visibility.Visible;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ContextObject.name))
            {
                App.MessageToast("Заполните все поля", 1);
                return;
            }

            if (ContextObject.id == 0)
            {
                var result = await NetManage.Post("api/objects/", ContextObject);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно добавлен", 2);
                else App.MessageToast("Ошибка добавления", 0);
            }
            else
            {
                var result = await NetManage.Put($"api/objects/{ContextObject.id}/", ContextObject);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно изменен", 2);
                else App.MessageToast("Ошибка изменения", 0);
            }

            ContextObject = new Object() { user = App.User.MainUser };

            await Refresh();

            TextForm.Text = "Добавление";
            BtnSave.Content = "Добавить";
        }

        private void BtnTopics_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Object;
            if (item == null) return;

            NavigationService.Navigate(new PageTopics(item));
        }
    }
}
