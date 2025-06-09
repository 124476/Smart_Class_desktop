using Desktop.Models;
using Desktop.Properties;
using Desktop.Servies;
using Desktop.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Rectangle = System.Drawing.Rectangle;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Computer ContextComputer;
        public MainWindow()
        {
            InitializeComponent();

            StartProgram();
        }

        private void BlockComputer()
        {
            var dialog = new WindowLock();
            dialog.ShowDialog();
        }

        private async void StartProgram()
        {
            if (!string.IsNullOrEmpty(Settings.Default.Code))
            {
                ContextComputer = await NetManage.Get<Computer>($"api/computers_connection/{Settings.Default.Code}/");
                Hide();
            }

            var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            registryKey.SetValue("Smart_Class", exePath);
            //registryKey.DeleteValue("Smart_Class", false);
            Settings.Default.Save();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            Refresh();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        public async void Refresh()
        {
            if (!string.IsNullOrEmpty(Settings.Default.Code))
                ContextComputer = await NetManage.Get<Computer>($"api/computers_connection/{Settings.Default.Code}/");

            if (ContextComputer != null)
            {
                if (ContextComputer.is_sound)
                    SystemSounds.Beep.Play();

                if (!ContextComputer.is_work)
                    Process.Start("shutdown", "/s /t 0");

                if (ContextComputer.is_block)
                    BlockComputer();

                Screen[] screens = Screen.AllScreens;

                Rectangle bounds = screens[0].Bounds;

                using (Bitmap bmp = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Png);
                        byte[] imageBytes = ms.ToArray();
                        ContextComputer.image = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                    }
                }

                var jsonPayload = JsonConvert.SerializeObject(new { image = ContextComputer.image });

                await NetManage.PatchAsync($"api/computers_connection/{Settings.Default.Code}/update-image/", jsonPayload);
            }
        }

        private async void BtnActive_Click(object sender, RoutedEventArgs e)
        {
            ContextComputer = await NetManage.Get<Computer>($"api/computers_connection/{Code.Text}/");

            if (ContextComputer != null)
            {
                Settings.Default.Code = Code.Text;
                Settings.Default.Save();

                Hide();
            }
        }
    }
}
