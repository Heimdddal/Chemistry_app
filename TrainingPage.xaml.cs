using Chemistry_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для TrainingPage.xaml
    /// </summary>
    public partial class TrainingPage : Page
    {
        public TrainingPage()
        {
            InitializeComponent();
            List<Question> allQuestions = new List<Question>();
            List<string> options1 = new List<string> { "Option 1", "Option 2", "Option 3", "Option 4" };
            Question question1 = new Question("Question 1", options1, 2); // Правильный ответ - третий вариант
            allQuestions.Add(question1);

            QuestionSelector questionSelector = new QuestionSelector(allQuestions);

            List<Question> selectedQuestions = questionSelector.SelectRandomQuestions(3);
        }
    }
}
