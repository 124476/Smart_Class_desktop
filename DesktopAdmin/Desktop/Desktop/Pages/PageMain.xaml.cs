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
