using LiveCharts.Wpf;
using LiveCharts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Desktop.Servies;
using Desktop.Models;

namespace Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        Grid ExpanderDrag;
        List<string> Weeks = new List<string>() { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс", };
        public PageMain()
        {
            InitializeComponent();

            Refresh();
        }

        private async void Refresh()
        {
            var computers = await NetManage.Get<List<Computer>>("api/computers/");

            var series = new SeriesCollection();

            var columns = new ColumnSeries()
            {
                Title = "Продажи",
                Values = new ChartValues<double>(),
                DataLabels = true,
            };

            var dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var dateStart = dateNow.AddDays(-9);

            var dates = new List<string>();

            while (dateStart <= dateNow)
            {
                double value = computers.Where(x => x.updated_at.Date == dateStart).Count();

                columns.Values.Add(value);

                dates.Add($"{Weeks[(((int)dateStart.DayOfWeek + 6) % 7)]}\n {dateStart.ToString("dd.MM")}");

                dateStart = dateStart.AddDays(1);
            }

            series.Add(columns);

            TabChart.AxisX[0].Labels = dates;
            TabChart.AxisX[0].Separator = new LiveCharts.Wpf.Separator() { Step = 1 };

            TabChart.Series = series;



            UsersPieChart.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Пользователи",
                    Values = new ChartValues<double> { computers.Count },
                    DataLabels = true
                }
            };



            var avgActivity = computers
                .Select(x => (x.updated_at - x.created_at).TotalHours)
                .DefaultIfEmpty(0).Average();
            ActivityGauge.Value = avgActivity;



            var total = computers.Count;
            var errors = computers.Count(x => x.is_work);
            ErrorBarChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Включенных",
                    Values = new ChartValues<int> { errors }
                },
                new ColumnSeries
                {
                    Title = "Всего",
                    Values = new ChartValues<int> { total }
                }
            };


            var roomGroups = computers
                .Where(c => !string.IsNullOrEmpty(c.class_name))
                .GroupBy(c => c.class_name)
                .Select(g => new { Room = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList();

            RoomLoadChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Компьютеры",
                    Values = new ChartValues<double>(roomGroups.Select(x => (double)x.Count)),
                    DataLabels = true
                }
            };

            RoomLoadChart.AxisX[0].Labels = roomGroups.Select(x => x.Room).ToArray();
            RoomLoadChart.AxisX[0].Separator = new LiveCharts.Wpf.Separator { Step = 1 };

        }

        private void Expander_Drop(object sender, DragEventArgs e)
        {
            var stack = sender as Grid;

            var indexSelected = ListForms.Children.IndexOf(stack);

            ListForms.Children.Remove(ExpanderDrag);
            ListForms.Children.Insert(indexSelected, ExpanderDrag);
        }

        private void Expander_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ExpanderDrag = sender as Grid;

            DragDrop.DoDragDrop(this, this, DragDropEffects.Move);
        }
    }
}
