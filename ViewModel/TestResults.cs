using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Chemistry_app.ViewModel
{
    internal class TestResults
    {
        private Grid grid;
        private float percentResult;
        private string userName;
        private string nameOfTest;
        Button GetCertificate = new Button()
        {
            Foreground = Brushes.White,
            Background = (Brush)new BrushConverter().ConvertFrom("#66e39c"),
            Content = "Сгенерировать сертификат",
            FontSize = 40,
            Margin = new Thickness(0, 100, 10, 0),
            MinHeight = 100,
            MinWidth = 200,
        };
        public TestResults(ref Grid grid, float result, float numberOfQuestions, string userName, string nameOfTest)
        {
            this.grid = grid;
            this.grid.Children.Clear();
            percentResult = result / numberOfQuestions*100;
            this.userName = userName;
            this.nameOfTest = nameOfTest;

            StackPanel panel = new StackPanel()
            { 
                VerticalAlignment = VerticalAlignment.Center
            };

            Label Results = new Label() 
            {
                Foreground = Brushes.White,
                Content = $"Вы правильно ответили на {result}  из  {numberOfQuestions} вопросов",
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                FontSize = 40
            };
            Label PercentResults = new Label()
            {
                Foreground = Brushes.White,
                Content = $"Ваш результат: {percentResult}%",
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                FontSize = 40,
            };

            Label Conclusion = new Label()
            {
                Foreground = Brushes.White,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                FontSize = 25,
            };
            GetCertificate.Click += GetCertificate_Click;

            panel.Children.Add(Results);
            panel.Children.Add(PercentResults);
            panel.Children.Add(Conclusion);
            this.grid.Children.Add(panel);

            if (percentResult >= 80)
            {
                panel.Children.Add(GetCertificate);
                Conclusion.Content = "Вы набрали достаточно баллов для получения сертефиката:";
            }
            else
            {
                Conclusion.Content = "Вы не набрали достаточно баллов для получения сертефиката";
            }
                
                
        }

        private async void GetCertificate_Click(object sender, RoutedEventArgs e)
        {

            ((Button)sender).Content = "Отправка на почту...";

            await Task.Delay(1);


            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string id = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            try
            {
                CertificateGenerator.GenerateCertificate(userName, nameOfTest, id, percentResult);
                EmailSender.SendCertificate("bearshunter321@gmail.com", nameOfTest, "certificate.pdf");
            }
            catch (Exception)
            {
                
            }
        }
    }
}
