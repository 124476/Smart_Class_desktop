using Desktop.Models;
using Desktop.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using System.Windows.Threading;

namespace Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageComputer.xaml
    /// </summary>
    public partial class PageComputer : Page
    {
        Computer ContextComputer;
        List<Class> ClassList;
        public PageComputer(Computer computer)
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                await InitData();
            }).Wait();

            ContextComputer = computer;

            ComboClasses.ItemsSource = ClassList;
            ComboClasses.SelectedItem = ClassList.FirstOrDefault(x => x.id == computer.class_obj);

            DataContext = ContextComputer;
        }

        private async Task InitData()
        {
            ClassList = await NetManage.Get<List<Class>>("api/classes/");
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ContextComputer.name) || ComboClasses.SelectedIndex == -1)
            {
                App.MessageToast("Заполните все поля", 1);
                return;
            }

            var computer = new ComputerSend()
            {
                id = ContextComputer.id,
                uuid = ContextComputer.uuid,
                class_obj = (ComboClasses.SelectedItem as Class).id,
                is_block = false,
                is_sound = false,
                is_work = true,
                name = ContextComputer.name,
                user = ContextComputer.user,
            };

            if (ContextComputer.id == 0)
            {
                var result = await NetManage.Post("api/computers/", computer);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно добавлен", 2);
                else App.MessageToast("Ошибка добавления", 0);
            }
            else
            {
                var result = await NetManage.Put($"api/computers/{computer.id}/", computer);
                    if (result.IsSuccessStatusCode) App.MessageToast("Успешно изменен", 2);
                else App.MessageToast("Ошибка изменения", 0);
            }

            NavigationService.GoBack();
        }
    }
}
