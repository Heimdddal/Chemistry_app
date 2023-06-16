using Chemistry_app.Models;
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
    /// Логика взаимодействия для PageForTest.xaml
    /// </summary>
    public partial class PageForTest : Page
    {
        public PageForTest(User user)
        {
            InitializeComponent();

            List<Question> questions = new List<Question>();

            questions.Add(new Question("What is the chemical symbol for gold?", "Au", "Ag", "Pt", "Cu"));
            questions.Add(new Question("What type of bond involves the sharing of electrons?", "Covalent", "Ionic", "Hydrogen", "Metallic"));
            questions.Add(new Question("Which gas makes up about 78% of Earth's atmosphere?", "Nitrogen", "Oxygen", "Carbon dioxide", "Argon"));
            questions.Add(new Question("What is the pH of a neutral solution?", "7", "1", "14", "0"));
            questions.Add(new Question("What is the process of converting a solid into a gas without passing through the liquid state called?", "Sublimation", "Evaporation", "Condensation", "Freezing"));

            var testApplication = new TestApplication(questions, ref MainGrid, "Chemistry test", user.Name);
        }
    }
}
