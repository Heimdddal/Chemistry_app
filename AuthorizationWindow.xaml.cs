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
            this.Close();
        }

        User authUsers(string email, string password)
        {
            User authUser = null;
            List<User> users = UserJsonController.ReadFromJson("Assert\\Users.json");
            authUser = users.Where(b => b.Email == email && b.Password == password).FirstOrDefault();
            return authUser;
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
            int passCount = 0;
            string email, password;

            email = textBoxEmail.Text.Trim();
            password = textBoxPassword.Password.Trim();
            #region checkEmail
            if (!email.Contains("@") & !email.Contains(".")) {
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxEmail.ToolTip = "Почта введена неверно";
            }
            else {
                passCount++;
                textBoxEmail.SetResourceReference(TextBox.BorderBrushProperty, "UnderLineLight");
                textBoxEmail.ToolTip = "";
            }
            #endregion
            #region checkPassword
            if (password.Length < 5){
                textBoxPassword.BorderBrush = Brushes.Red;
                textBoxPassword.ToolTip = "Пароль введен неконектно";
            }
            else { 
                passCount++;
                textBoxPassword.SetResourceReference(TextBox.BorderBrushProperty, "UnderLineLight");
                textBoxPassword.ToolTip = "";
            }
            #endregion
            if (passCount == 2)
            {
                if (isUsers(email, password))
                {
                    MainWindow window = new MainWindow(authUsers(email,password));
                    window.Show();
                    this.Close();
                }
                else MessageBox.Show("Пользователь не найден");
            }

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = new MainWindow(new User());
            window.Show();
            this.Close();
        }
    }
}
