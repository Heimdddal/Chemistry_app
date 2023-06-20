using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chemistry_app.ViewModel
{
    internal class TestApplication
    {
        private StackPanel panel = new StackPanel();
        private Button button = new Button()
        {
            Foreground = Brushes.White,
            Background = (Brush)new BrushConverter().ConvertFrom("#66e39c"),
            MinHeight = 100,
            FontSize= 25
        };
        private int numberOfQuestions;
        private List<Question> questionList;
        private string userName;
        private Grid grid;
        private string nameOfTest;
        private string email;
        public TestApplication(List<Question> questions, ref Grid grid, string testName, string userName, string email)
        {
            this.grid = grid;
            this.nameOfTest = testName;

            this.userName= userName;
            this.email= email;

            numberOfQuestions = questions.Count;
            questionList = questions;
            panel.Children.Add(new TextBlock()
            {
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = testName,
                FontSize = 40
            });
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].RadioButtonTrue.GroupName = $"Question {i}";
                questions[i].RadioButtonFalse1.GroupName = $"Question {i}";
                questions[i].RadioButtonFalse2.GroupName = $"Question {i}";
                questions[i].RadioButtonFalse3.GroupName = $"Question {i}";


                panel.Children.Add(questions[i].questionStackPanel);
            }

            button.Content = "Узнать результаты";
            button.Click += ShowResults;
            panel.Children.Add(button);
            this.grid.Children.Add(panel);
        }

        private int CountCorrectAnswers()
        {
            int correctAnswers = 0;

            foreach (var question in questionList)
            {
                if (question.RadioButtonTrue.IsChecked == true)
                {
                    correctAnswers++;
                }
            }

            return correctAnswers;
        }

        private void ShowResults(object sender, RoutedEventArgs e)
        {
            TestResults testResults = new TestResults(ref grid, CountCorrectAnswers(), 
                numberOfQuestions, userName,email, nameOfTest,
                questionList);
            panel.Children.Clear();
            string jsonResult = $"{email}:{CountCorrectAnswers()}\n";
            string jsonFileText = File.ReadAllText("Assert\\results.json");
            var jsonStrArr = jsonFileText.Split('\n', '\r');
            int index = jsonStrArr.Select((p, i) => new { value = p, indx = i }).Where(s => s.value.Split(':')[0] == userName)
                .Select(x=>x.indx).First();

            int oldResult = int.Parse(jsonStrArr[index].Split(':')[1]);
            if (CountCorrectAnswers()>oldResult)
            {
                jsonStrArr[index] = jsonResult;
                jsonFileText = string.Join("\n", jsonStrArr);
            }
            try
            {
                File.WriteAllText("Assert\\results.json", jsonFileText);
            }
            catch (Exception ex)
            {
                // обработка ошибок записи в файл
                MessageBox.Show($"Error writing to file: {ex.Message}");
            }
        }
    }
}