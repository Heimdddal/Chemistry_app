using Chemistry_app.Controllers;
using Chemistry_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Xml;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow window = new RegistrationWindow();
            window.Show();
            this.Hide();
        }

        bool isUsers(string email, string password)
        {
            User authUser = null;
            List<User> users = UserJsonController.ReadFromJson("Assert\\Users.json");
            authUser = users.Where(b => b.Email == email && b.Password == password).FirstOrDefault();
            if (authUser != null)
            { return true; }
            else { return false; }
        }
        private void ButtonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            string email, password;

            email = textBoxEmail.Text.Trim();
            password = textBoxPassword.Password.Trim();

            if (email == "root")
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Hide();
            }

            if (!email.Contains("@") & !email.Contains(".")) {
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxEmail.ToolTip = "Email введен неверно";
            }
            else {
                textBoxEmail.SetResourceReference(TextBox.BorderBrushProperty, "UnderLineLight");
            }

            if (password.Length < 5){
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxEmail.ToolTip = "Password введен неконектно";
            }
            else { 
                textBoxEmail.SetResourceReference(TextBox.BorderBrushProperty, "UnderLineLight"); 
            }

            if (isUsers(email, password)){
                MainWindow window = new MainWindow();
                window.Show();
                this.Hide();
            }
            else MessageBox.Show("Пользователь не найден");

        }

    }
}
