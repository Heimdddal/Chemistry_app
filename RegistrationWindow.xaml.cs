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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Chemistry_app
{

    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : System.Windows.Window
    {
        public string Gender { get; set; }
        public string Password { get; set; }
        public RegistrationWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MaleRadioButton.Checked += RadioButton_Checked;
            FemaleRadioButton.Checked += RadioButton_Checked;
        }
        public bool ValidateEmail(string email)//проверка почты по шаблону @.
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Regex regex = new Regex(pattern);
            bool isValid = regex.IsMatch(email);

            return isValid;
        }
        public void EmailConfirmation(User user) {//Окно подтверждения почты
            Chemistry_app.EmailConfirmation window = new EmailConfirmation(user, this);
            this.IsEnabled = false;
        }
        bool isUsers(string email)//Вернуть true если пользователь существует, false, если не существует
        {
            User regUser = null;
            List<User> users = UserJsonController.ReadFromJson("Assert\\Users.json");
            regUser = users.Where(b => b.Email == email).FirstOrDefault();
            if (regUser != null)
            { return true; }
            else { return false; }
        }
        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)//Нажата зарегистрироваться
        {
            List<User> users = UserJsonController.ReadFromJson("Assert\\Users.json");
            string name, email, gender, password, repeatePassword;
            int age = 0;
            int passCount = 0;
            #region checkName
            name = textBoxName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(name))
            {
                passCount++;
                textBoxName.SetResourceReference(Control.BorderBrushProperty, "ActiveElements");
            }
            else { 
                textBoxName.ToolTip = "Введите значение";
                textBoxName.BorderBrush = Brushes.Red;
            }
            #endregion
            #region checkEmail
            email = textBoxEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email))
            {
                passCount++;
                textBoxEmail.SetResourceReference(Control.BorderBrushProperty, "ActiveElements");
            }
            else { 
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxEmail.ToolTip = "Введите значение"; 
            }

            if (ValidateEmail(email))
            {
                passCount++;
                textBoxEmail.SetResourceReference(Control.BorderBrushProperty, "ActiveElements");
            }
            else
            {
                textBoxEmail.BorderBrush = Brushes.Red;
                textBoxEmail.ToolTip = "Email введен неверно";
            }
            #endregion
            #region checkGender
            gender = Gender;
            if (!string.IsNullOrWhiteSpace(gender))
            {
                passCount++;
                textBoxGender.SetResourceReference(Control.BorderBrushProperty, "ActiveElements");
            }
            else {
            }
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
                textBoxPassword.SetResourceReference(Control.BorderBrushProperty, "ActiveElements");
            }
            else { 
                textBoxPassword.ToolTip = "Введите значение"; 
                textBoxPassword.BorderBrush = Brushes.Red;
            }
            #endregion
            #region checkRepeatePassword
            repeatePassword = textBoxRepeatPassword.Password;
            if (password == repeatePassword)
            {
                passCount++;
            }
            #endregion
            if (passCount == 7) {
                if (!isUsers(email))
                {
                    User user = new User(name, email, age, gender, password);
                    EmailConfirmation(user);
                }
                else MessageBox.Show("Пользователь уже существует");
            }
        }

        private void ButtonReturnToAuentification_Click(object sender, MouseButtonEventArgs e)//Нажата кнопка назад
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Show();
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)//Получение данных: Пол пользователя
        {
            if (sender is RadioButton radio)
            {
                if (radio.Name == "MaleRadioButton")
                {
                    Gender = "Муж";
                }
                else if (radio.Name == "FemaleRadioButton")
                {
                    Gender = "Жен";
                }
            }
        }

        private void Password_Changed(object sender, RoutedEventArgs e)//Проверка и вывод об ошибках паролей
        {
            string password;
            password = textBoxPassword.Password.Trim();
            if (password.Length <= 5)
            {
                textBoxPassword.ToolTip = "Неверный пароль (Длина меньше 5 символов)";
                textBoxPassword.BorderBrush = Brushes.Red;
            }
            else {
                textBoxPassword.ToolTip = null;
                textBoxPassword.SetResourceReference(Control.BorderBrushProperty, "ActiveElements"); 
                Password = password;
            }

            string repeatePassword;
            repeatePassword = textBoxRepeatPassword.Password;
            if (repeatePassword != Password)
            {
                textBoxRepeatPassword.ToolTip = "Пароль не совпадает";
                textBoxRepeatPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                textBoxRepeatPassword.ToolTip = null;
                textBoxRepeatPassword.SetResourceReference(Control.BorderBrushProperty, "ActiveElements");
            }
        }
    }
}
