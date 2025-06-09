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
using System.Windows.Threading;

namespace Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageUseComputer.xaml
    /// </summary>
    public partial class PageUseComputer : Page
    {
        Computer ContextComputer;
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1), };
        public PageUseComputer(Computer computer)
        {
            InitializeComponent();

            timer.Tick += Timer_Tick;

            ContextComputer = computer;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            ContextComputer = await NetManage.Get<Computer>($"api/computers_connection/{ContextComputer.uuid}/");

            DataContext = null;
            DataContext = ContextComputer;

            if (ContextComputer.is_work) BtnWork.Content = "Выключить компьютер";
            else BtnWork.Content = "Включить компьютер";

            if (ContextComputer.is_sound) BtnSound.Content = "Выключить звук";
            else BtnSound.Content = "Включить звук";

            if (ContextComputer.is_block) BtnBlock.Content = "Разблокировать";
            else BtnBlock.Content = "Заблокировать";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            DataContext = ContextComputer;

            timer.Start();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void BtnBlock_Click(object sender, RoutedEventArgs e)
        {
            ContextComputer.is_block = !ContextComputer.is_block;

            SendPut();
        }

        private void BtnSound_Click(object sender, RoutedEventArgs e)
        {
            ContextComputer.is_sound = !ContextComputer.is_sound;

            SendPut();
        }

        private void BtnWork_Click(object sender, RoutedEventArgs e)
        {
            ContextComputer.is_work = !ContextComputer.is_work;

            SendPut();
        }

        private async void SendPut()
        {
            var computer = new ComputerSend()
            {
                id = ContextComputer.id,
                class_obj = ContextComputer.class_obj,
                is_block = ContextComputer.is_block,
                is_sound = ContextComputer.is_sound,
                is_work = ContextComputer.is_work,
                name = ContextComputer.name,
                user = ContextComputer.user,
                uuid = ContextComputer.uuid,
            };

            await NetManage.Put($"api/computers/{ContextComputer.id}/", computer);
        }

        private void TextCopy_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(ContextComputer.uuid);

            App.MessageToast("Скопировано в буфет обмена", 2);
        }
    }
}
