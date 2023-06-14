using Chemistry_app.Controllers;
using Chemistry_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void ButtonReturnToAuentification_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Show();
            Hide();
        }
        bool isUsers(string email)
        {
            User regUser = null;
            List<User> users = UserJsonController.ReadFromJson("..\\Assert\\Users.json");
            regUser = users.Where(b => b.Email == email).FirstOrDefault();
            if (regUser != null)
            { return true; }
            else { return false; }
        }
        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();
            users = UserJsonController.ReadFromJson("Users.json");
            string name, email, gender, password, repeatePassword;
            int age = 0;
            int passCount = 0;

            name = textBoxName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(name)) {
                passCount++;
            }
            else textBoxName.ToolTip = "Введите значение";

            email = textBoxEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email)){
                passCount++;
            }
            else textBoxEmail.ToolTip = "Введите значение";

            if (!email.Contains("@") & !email.Contains("."))
            {
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxEmail.ToolTip = "Email введен неверно";
            }
            else
            {
                passCount++;
            }

            gender = textBoxAge.Text.Trim();
            if (!string.IsNullOrWhiteSpace(gender)) {
                passCount++;
            }
            else textBoxGender.ToolTip = "Введите значение";

            try {
                age = int.Parse(textBoxAge.Text);
                if (age <= 100 && age >= 1)
                    passCount++;
            } 
            catch {
                textBoxAge.ToolTip = "Возраст указан неверно";
            }

            password = textBoxPassword.Password;
            if (!string.IsNullOrWhiteSpace(password))
            {
                passCount++;
            }
            else textBoxPassword.ToolTip = "Введите значение";

            repeatePassword = textBoxRepeatPassword.Password;
            if (!string.IsNullOrWhiteSpace(repeatePassword))
            {
                passCount++;
            }
            else textBoxRepeatPassword.ToolTip = "Введите значение";

            if (password != repeatePassword)
            {
                textBoxPassword.ToolTip = "Пароли не совпадают";
                textBoxRepeatPassword.ToolTip = "Пароли не совпадают";
            }
            else passCount++;
            
            if (passCount == 8) {
                if (!isUsers(email))
                {
                    string fileName = "..\\Chemistry_app\\Users.json";
                    User user = new User(name, email, age, gender, password);
                    users = UserJsonController.ReadFromJson(fileName);
                    users.Add(user);
                    UserJsonController.WriteToJson(users, fileName);
                }
                else MessageBox.Show("Пользователь уже существует");
            }
            }
    }
}
