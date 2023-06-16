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
using System.Net;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using System.IO;
using System.Net.Mail;
using Google.Apis.Util.Store;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Chemistry_app
{

    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : System.Windows.Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        public void EmailConfirmation(User user) {;
            Chemistry_app.EmailConfirmation window = new EmailConfirmation(user);
            window.Show();
            Hide();
        }
        bool isUsers(string email)
        {
            User regUser = null;
            List<User> users = UserJsonController.ReadFromJson("Assert\\Users.json");
            regUser = users.Where(b => b.Email == email).FirstOrDefault();
            if (regUser != null)
            { return true; }
            else { return false; }
        }
        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = UserJsonController.ReadFromJson("Assert\\Users.json");
            string name, email, gender, password, repeatePassword;
            int age = 0;
            int passCount = 0;
            #region checkName
            name = textBoxName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(name)) {
                passCount++;
            }
            else textBoxName.ToolTip = "Введите значение";
            #endregion
            #region checkEmail
            email = textBoxEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email)){
                passCount++;
            }
            else textBoxEmail.ToolTip = "Введите значение";

            if (!email.Contains("@") & !email.Contains(".") || email.Count(c => c == '@') > 1)
            {
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxEmail.ToolTip = "Email введен неверно";
            }
            else
            {
                passCount++;
            }
            #endregion
            #region checkGender
            gender = " ";
            if (!string.IsNullOrWhiteSpace(gender)) {
                passCount++;
            }
            else //todo
            #endregion
            #region checkAge
            try
            {
                age = int.Parse(textBoxAge.Text);
                if (age <= 100 && age >= 1)
                    passCount++;
            } 
            catch {
                textBoxAge.ToolTip = "Возраст указан неверно";
            }
            #endregion
            #region checkPassword
            password = textBoxPassword.Password;
            if (!string.IsNullOrWhiteSpace(password) & password.Length >= 5)
            {
                passCount++;
            }
            else textBoxPassword.ToolTip = "Введите значение";
            #endregion
            #region checkRepeatePassword
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
            #endregion
            if (passCount == 8) {
                if (!isUsers(email))
                {
                    User user = new User(name, email, age, gender, password);
                    EmailConfirmation(user);
                }
                else MessageBox.Show("Пользователь уже существует");
            }
        }

        private void ButtonReturnToAuentification_Click(object sender, MouseButtonEventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Show();
            this.Close();
        }
    }
}
