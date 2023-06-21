using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app.Models
{
    public class Questions
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public Questions(string text, List<string> options, int correctAnswerIndex)
        {
            Text = text;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }

    public class QuestionSelector
    {
        private List<Questions> questions;
        private Random random;
        private Questions currentQuestion;

        public QuestionSelector(List<Questions> questionList)
        {
            questions = questionList;
            random = new Random();
        }

        public List<Questions> SelectRandomQuestions(int count)
        {
            if (count <= 0 || count > questions.Count)
                throw new ArgumentException("Invalid count");

            List<Questions> selectedQuestions = new List<Questions>();

            List<int> indexes = Enumerable.Range(0, questions.Count).ToList();
            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(0, indexes.Count);
                int questionIndex = indexes[randomIndex];
                indexes.RemoveAt(randomIndex);

                currentQuestion = questions[questionIndex];
                ShuffleOptions(currentQuestion.Options);
                selectedQuestions.Add(currentQuestion);
            }

            return selectedQuestions;
        }

        private void ShuffleOptions(List<string> options)
        {
            int n = options.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = options[k];
                options[k] = options[n];
                options[n] = value;

                if (k == currentQuestion.CorrectAnswerIndex)
                    currentQuestion.CorrectAnswerIndex = n;
                else if (n == currentQuestion.CorrectAnswerIndex)
                    currentQuestion.CorrectAnswerIndex = k;
            }
        }
    }
}
