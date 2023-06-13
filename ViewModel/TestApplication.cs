using System;
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
        private Button button = new Button();
        private int numberOfQuestions;
        private List<Question> questionList;
        public TestApplication(List<Question> questions)
        {
            numberOfQuestions= questions.Count;
            questionList = questions;
            for (int i = 0; i< questions.Count; i++)
            {
                questions[i].RadioButtonTrue.GroupName = $"Question {i}";
                questions[i].RadioButtonFalse1.GroupName = $"Question {i}";
                questions[i].RadioButtonFalse2.GroupName = $"Question {i}";
                questions[i].RadioButtonFalse3.GroupName = $"Question {i}";

                panel.Children.Add(questions[i].questionStackPanel);
            }

            button.Content = "Check Results";
            button.Click += ShowResults;
            panel.Children.Add(button);
        }

        public StackPanel GetPanel() { return panel; }

        public int CountCorrectAnswers()
        {
            int correctAnswersCount = 0;
            for (int i = 0; i < questionList.Count; i++)
            {

                if (panel.Children[i] is StackPanel stackPanel && stackPanel.Children[0] is GroupBox groupBox && groupBox.Content is ListBox listBox && listBox.SelectedItem is RadioButton selectedRadioButton && selectedRadioButton == questionList[i].RadioButtonTrue)
                {
                    correctAnswersCount++;
                }
            }
            return correctAnswersCount;
        }

        private void ShowResults(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"You have answered {CountCorrectAnswers()} out of {numberOfQuestions} questions correctly.");
        }
    }
}
