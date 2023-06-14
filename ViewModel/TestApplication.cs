using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chemistry_app.ViewModel
{
    internal class TestApplication
    {
        private StackPanel panel = new StackPanel();
        private ScrollViewer scrollViewer = new ScrollViewer();
        private Button button = new Button();
        private int numberOfQuestions;
        private List<Question> questionList;
        private string userName;
        private Grid grid;
        public TestApplication(List<Question> questions, ref Grid grid, string testName, string userName)
        {
            this.grid = grid;


            this.userName= userName;
            numberOfQuestions = questions.Count;
            questionList = questions;
            panel.Children.Add(new TextBlock() 
            {
                HorizontalAlignment=HorizontalAlignment.Center,
                Text=testName
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
            scrollViewer.Content = panel;
            this.grid.Children.Add(scrollViewer);
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
            TestResults testResults = new TestResults(ref grid, $"Вы правильно ответили на {CountCorrectAnswers()}  из  {numberOfQuestions} вопросов");
            string jsonResult = $"{userName}:{CountCorrectAnswers()}\n";
            try
            {
                File.AppendAllText("results.json", jsonResult + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // обработка ошибок записи в файл
                MessageBox.Show($"Error writing to file: {ex.Message}");
            }
        }
    }
}