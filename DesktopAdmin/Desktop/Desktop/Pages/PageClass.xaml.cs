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
    /// Логика взаимодействия для PageClass.xaml
    /// </summary>
    public partial class PageClass : Page
    {
        Class ContextClass;
        public PageClass(Class @class)
        {
            InitializeComponent();

            ContextClass = @class;

            DataContext = ContextClass;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ContextClass.name))
            {
                App.MessageToast("Заполните все поля", 1);
                return;
            }

            if (ContextClass.id == 0)
            {
                var result = await NetManage.Post("api/classes/", ContextClass);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно добавлен", 2);
                else App.MessageToast("Ошибка добавления", 0);
            }
            else
            {
                var result = await NetManage.Put($"api/classes/{ContextClass.id}/", ContextClass);
                if (result.IsSuccessStatusCode) App.MessageToast("Успешно изменен", 2);
                else App.MessageToast("Ошибка изменения", 0);
            }

            NavigationService.GoBack();
        }
    }
}
