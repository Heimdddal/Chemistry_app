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
        private List<Question> questionList;
        private string email;
       Button GetCertificate = new Button()
        {
            Foreground = Brushes.White,
            Background = (Brush)new BrushConverter().ConvertFrom("#66e39c"),
            Content = "Отправка сертефиката на почту",
            FontSize = 40,
            Margin = new Thickness(0, 100, 10, 0),
            MinHeight = 100,
            MinWidth = 200,
            
        };

        Button RepeatTest = new Button()
        {
            Foreground = Brushes.White,
            Background = (Brush)new BrushConverter().ConvertFrom("#66e39c"),
            Content = "Пройти тест заново",
            FontSize = 40,
            Margin = new Thickness(0, 100, 10, 0),
            MinHeight = 100,
            MinWidth = 200,

        };

        public TestResults(ref Grid grid, float result, float numberOfQuestions, string userName,string email,
            string nameOfTest, List<Question> questionList)
        {
            this.grid = grid;
            this.grid.Children.Clear();
            percentResult = result / numberOfQuestions*100;
            this.userName = userName;
            this.nameOfTest = nameOfTest;
            this.questionList = questionList;
            this.email = email;

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
            RepeatTest.Click += RepeatTest_click;

            panel.Children.Add(Results);
            panel.Children.Add(PercentResults);
            panel.Children.Add(Conclusion);
            this.grid.Children.Add(panel);

            if (email != "guest@gmail.com")
            {
                if (percentResult >= 80)
                {
                    panel.Children.Add(GetCertificate);
                    Conclusion.Content = "Вы набрали достаточно баллов для получения сертефиката:";
                }
                else
                {
                    Conclusion.Content = "Вы не набрали достаточно баллов для получения сертефиката";
                    panel.Children.Add(RepeatTest);
                }
            }
            else
            {
                Conclusion.Content = "Зарегистрируйтесь чтобы иметь возможность получить сертификат";
                panel.Children.Add(RepeatTest);
            }
                
        }

        private void GetCertificate_Click(object sender, RoutedEventArgs e)
        {

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string id = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
             CertificateGenerator.GenerateCertificate(userName, nameOfTest, id, percentResult);
                EmailSender.SendCertificate(email, nameOfTest, "certificate.pdf");
                MessageBox.Show($"Сертефикат успешно отправлен на ваш e-mail: {email}");
         
            grid.Children.Clear();
            foreach (Question quest in questionList)
            {
                quest.RadioButtonTrue.IsChecked = false;
                quest.RadioButtonFalse1.IsChecked = false;
                quest.RadioButtonFalse2.IsChecked = false;
                quest.RadioButtonFalse3.IsChecked = false;
            }
            new TestApplication(questionList, ref grid, nameOfTest, userName, email);
        }

        private void RepeatTest_click(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            foreach (Question quest in questionList)
            {
                quest.RadioButtonTrue.IsChecked = false;
                quest.RadioButtonFalse1.IsChecked = false;
                quest.RadioButtonFalse2.IsChecked = false;
                quest.RadioButtonFalse3.IsChecked = false;
            }
            new TestApplication(questionList, ref grid, nameOfTest, userName, email);
        }
    }
}