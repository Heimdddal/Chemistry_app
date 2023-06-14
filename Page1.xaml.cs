using Chemistry_app.ViewModel;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            var questions = new List<Question>()
            {
                new Question("Question 1", "True", "False1", "False2", "False3"),
                new Question("Question 2", "False1", "False2", "False3", "True"),
                new Question("Question 3", "False2", "False3", "True", "False1")
            };

            var testApplication = new TestApplication(questions, ref MainGrid, "Тест", "klim");

        }
    }
}
