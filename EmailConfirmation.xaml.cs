using Chemistry_app.Controllers;
using Chemistry_app.Models;
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
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Threading;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для EmailConfirmation.xaml
    /// </summary>
    public partial class EmailConfirmation : System.Windows.Window
    {
        public User user { get; set; }
        public string codeAuth { get; set; }
        public RegistrationWindow registrationWindow { get; set; }
        public EmailConfirmation(User user, RegistrationWindow registrationWindow)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.user = user;
            int code = GenerateCode();
            codeAuth = code.ToString();

            ShowLoadedWindow();

            Task.Run(() =>
            {
                Thread.Sleep(1000);
                EmailSender.SendCode(code.ToString(), user.Email);
            }).ContinueWith(task =>
            {
                CloseLoadedWindow();
                ShowConfirmationWindow();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            this.registrationWindow = registrationWindow;
        }
        private async void ShowLoadedWindow()
        {
            LoadingWindow window = new LoadingWindow();
            await Task.Delay(100);
            window.Show();
        }

        private void CloseLoadedWindow()
        {
            LoadingWindow window = Application.Current.Windows.OfType<LoadingWindow>().FirstOrDefault();
            window?.Close();
        }

        private void ShowConfirmationWindow()
        {
            this.Show();
        }
        public int GenerateCode()
        {
            Random random = new Random();
            int code = random.Next(100000, 1000000);
            return code;
        }
        public void checkEmail() {
            string fileName = "Assert\\Users.json";
            if (codeAuth == textBoxCode.Text)
            {
                registrationWindow.Close();
                List<User> users = UserJsonController.ReadFromJson(fileName);
                users.Add(user);
                UserJsonController.WriteToJson(users, fileName);
                MainWindow window = new MainWindow(user);
                window.Show();
                Hide();
            }
            else MessageBox.Show("Неверный код");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           checkEmail();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            registrationWindow.IsEnabled = true;
            this.Close();
        }
    }
}
