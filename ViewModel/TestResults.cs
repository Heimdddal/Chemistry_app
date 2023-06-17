using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chemistry_app.ViewModel
{
    internal class TestResults
    {
        private Grid grid;
        private float percentResult;
        private string userName;
        private string nameOfTest;
        public TestResults(ref Grid grid, float result, float numberOfQuestions, string userName, string nameOfTest)
        {
            this.grid = grid;
            this.grid.Children.Clear();
            percentResult = result / numberOfQuestions*100;
            this.userName = userName;
            this.nameOfTest = nameOfTest;

            Label Results = new Label() 
            {
                Foreground = Brushes.White,
                Content = $"Вы правильно ответили на {result}  из  {numberOfQuestions} вопросов",
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };

            Button GetCertificate = new Button()
            {
                Foreground = Brushes.White,
                Content = "Сгененриовать сертификат"
            };

            GetCertificate.Click += GetCertificate_Click;

            this.grid.Children.Add(Results);

            if (percentResult >= 80)
                this.grid.Children.Add(GetCertificate);
        }

        private void GetCertificate_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string id = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            CertificateGenerator.GenerateCertificate(userName, nameOfTest,id,percentResult);
            EmailSender.SendCertificate("bearshunter321@gmail.com",nameOfTest, "certificate.pdf");
        }
    }
}
