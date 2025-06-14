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
    /// Логика взаимодействия для PageSubsections.xaml
    /// </summary>
    public partial class PageSubsections : Page
    {
        public Topic ContextTopic;
        public Subsection ContextSubsection;
        public List<Subsection> subsections = new List<Subsection>();
        public PageSubsections(Topic topic)
        {
            InitializeComponent();

            ContextTopic = topic;

            ContextSubsection = new Subsection() { topic = ContextTopic.id };
        }

        private async Task Refresh()
        {
            subsections = await NetManage.Get<List<Subsection>>("api/subsections/");

            subsections = subsections.Where(x => x.topic == ContextTopic.id).ToList();

            ListItems.ItemsSource = null;
            ListItems.ItemsSource = subsections;

            TextAll.Text = $"Всего: {subsections.Count()} шт.";
            TextVisible.Visibility = Visibility.Collapsed;

            DataContext = null;
            DataContext = ContextSubsection;
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
            ContextSubsection = (sender as TextBlock).DataContext as Subsection;

            DataContext = null;
            DataContext = ContextSubsection;

            StackForm.Visibility = Visibility.Visible;
            TextForm.Text = "Редактирование";
            BtnSave.Content = "Изменить";
        }

        private async void BtnRemove_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as TextBlock).DataContext as Subsection;
            if (item == null) return;

            var result = MessageBox.Show("Вы точно хотите удалить?", "Предупреждение", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            var resultDelete = await NetManage.Delete($"api/subsections/{item.id}/");

            if (resultDelete.IsSuccessStatusCode) App.MessageToast("Успешно удален", 2);
            else App.MessageToast("Ошибка удаления", 0);

            ContextSubsection = new Subsection() { topic = ContextTopic.id };

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
            if (string.IsNullOrEmpty(ContextSubsection.name) || string.IsNullOrEmpty(ContextSubsection.description))
            {
                App.MessageToast("Заполните все поля", 1);
                return;
            }

            if (ContextSubsection.id == 0)
            {
                var result = await NetManage.Post("api/subsections/", ContextSubsection);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно добавлен", 2);
                else App.MessageToast("Ошибка добавления", 0);
            }
            else
            {
                var result = await NetManage.Put($"api/subsections/{ContextSubsection.id}/", ContextSubsection);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно изменен", 2);
                else App.MessageToast("Ошибка изменения", 0);
            }

            ContextSubsection = new Subsection() { topic = ContextTopic.id };

            await Refresh();

            TextForm.Text = "Добавление";
            BtnSave.Content = "Добавить";
        }
    }
}
