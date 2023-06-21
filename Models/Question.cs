using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app.Models
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswer { get; set; }

        public Question(string text, List<string> options, int correctAnswer)
        {
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
        }
    }

    public class QuestionSelector
    {
        private List<Question> questions;
        private Random random;

        public QuestionSelector(List<Question> questionList)
        {
            questions = questionList;
            random = new Random();
        }

        public List<Question> SelectRandomQuestions(int count)
        {
            if (count <= 0 || count > questions.Count)
                throw new ArgumentException("Invalid count");

            List<Question> selectedQuestions = new List<Question>();

            List<int> indexes = Enumerable.Range(0, questions.Count).ToList();
            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(0, indexes.Count);
                int questionIndex = indexes[randomIndex];
                indexes.RemoveAt(randomIndex);

                Question question = questions[questionIndex];
                List<string> shuffledOptions = ShuffleOptions(question.Options);
                selectedQuestions.Add(new Question(question.Text, shuffledOptions, question.CorrectAnswer));
            }

            return selectedQuestions;
        }

        private List<string> ShuffleOptions(List<string> options)
        {
            List<string> shuffledOptions = new List<string>(options);
            int n = shuffledOptions.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = shuffledOptions[k];
                shuffledOptions[k] = shuffledOptions[n];
                shuffledOptions[n] = value;
            }
            return shuffledOptions;
        }
    }
}
