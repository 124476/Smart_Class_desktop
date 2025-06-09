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
    /// Логика взаимодействия для PageNews.xaml
    /// </summary>
    public partial class PageNews : Page
    {
        public PageNews()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            var news = await NetManage.Get<List<News>>("api/news/");

            ListItems.ItemsSource = null;
            ListItems.ItemsSource = news;

            TextVisible.Visibility = Visibility.Collapsed;
        }

        private void BtnSee_Click(object sender, RoutedEventArgs e)
        {
            var news = (sender as Button).DataContext as News;
            if (news == null) return;

            NavigationService.Navigate(new PageNewsSee(news));
        }
    }
}
