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
    /// Логика взаимодействия для PageFoodworks.xaml
    /// </summary>
    public partial class PageFoodworks : Page
    {
        public DateTime dateNow;
        public List<string> Weeks = new List<string>() {"Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс", };
        public PageFoodworks()
        {
            InitializeComponent();

            dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Refresh();
        }

        private void Refresh()
        {
            GridPanel.Children.Clear();

            var dateStart = dateNow;
            var dateEnd = dateStart.AddMonths(1);

            var dat = ((int)dateStart.DayOfWeek + 6) % 7;

            var prevMonth = dateStart.AddDays(-dat);

            for (int indexDay = 0; indexDay < 7; indexDay++)
            {
                var textDay = new TextBlock()
                {
                    Text = Weeks[(indexDay + dat + 1) % 7],
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                GridPanel.Children.Add(textDay);
                Grid.SetColumn(textDay, indexDay);
            }

            int indexDayLast = 0;
                
            while (dateStart < dateEnd)
            {
                var dateN = dateStart.Day + dat - 1;
                AddBtn(dateStart, dateN / 7 + 1, dateN % 7, true);

                dateStart = dateStart.AddDays(1);
                indexDayLast++;
            }

            for (int indexPrev = 0; indexPrev < dat; indexPrev++)
            {
                AddBtn(prevMonth.AddDays(indexPrev), 1, indexPrev, false);
                indexDayLast++;
            }

            while (indexDayLast % 7 != 0)
            {
                AddBtn(dateStart, indexDayLast / 7 + 1, indexDayLast % 7, false);

                dateStart = dateStart.AddDays(1);
                indexDayLast++;
            }

            TextNow.Text = dateNow.ToString("MMMM yyyy");
        }

        private void AddBtn(DateTime date, int row, int col, bool IsMonth)
        {
            var btnFood = new Button()
            {
                DataContext = date,
                Content = date.Day.ToString(),
            };
            btnFood.Click += BtnFood_Click;

            if (date == DateTime.Now.Date) btnFood.Background = Brushes.Gray;

            if (!IsMonth) btnFood.Opacity = 0.2;

            GridPanel.Children.Add(btnFood);

            Grid.SetRow(btnFood, row);
            Grid.SetColumn(btnFood, col);
        }

        private void BtnFood_Click(object sender, RoutedEventArgs e)
        {
            var date = (sender as Button).DataContext as DateTime?;
            if (date == null) return;

            NavigationService.Navigate(new PageFoodworkToday(date));
        }

        private void BtnDown_Click(object sender, RoutedEventArgs e)
        {
            dateNow = dateNow.AddMonths(-1);
            Refresh();
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            dateNow = dateNow.AddMonths(1);
            Refresh();
        }
    }
}
