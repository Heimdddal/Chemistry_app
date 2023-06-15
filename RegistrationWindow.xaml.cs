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

namespace Chemistry_app
{

    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        [Obsolete]
        public static void SendEmail(string toAddress, string subject, string body)
        {
            UserCredential credential;

            // Путь к файлу учетных данных, который вы скачали из Google Cloud Console
            using (var stream = new FileStream("path/to/your/credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "path/to/your/token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { GmailService.Scope.GmailSend },
                    "user",
                    System.Threading.CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Создание сервиса Gmail API
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Your application name",
            });

            // Создание сообщения
            var message = new MailMessage();
            message.From = new MailAddress("youremail@gmail.com");
            message.To.Add(toAddress);
            message.Subject = subject;
            message.Body = body;

            // Кодирование сообщения в формат MIME
            var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(message);
            var rawMessage = Base64UrlEncode(mimeMessage.ToString());

            // Отправка сообщения
            var gmailMessage = new Message();
            gmailMessage.Raw = rawMessage;
            service.Users.Messages.Send(gmailMessage, "me").Execute();
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
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
            gender = textBoxAge.Text.Trim();
            if (!string.IsNullOrWhiteSpace(gender)) {
                passCount++;
            }
            else textBoxGender.ToolTip = "Введите значение";
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
