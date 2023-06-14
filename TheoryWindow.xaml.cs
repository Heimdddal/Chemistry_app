using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;
using Chemistry_app.View;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для TheoryWindow.xaml
    /// </summary>
    public partial class TheoryWindow : Page
    {
        public TheoryWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private TheoryData theoryData;
        private int currentPageIndex;

        private void DisplayTheoryPage(TheoryPage page)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(page.Content)));
            pageLabel.Text = $"Страница {page.PageNumber}";
        }

        private void LoadTheoryData(string jsonFilePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                theoryData = JsonConvert.DeserializeObject<TheoryData>(jsonContent);
                currentPageIndex = 0;

                if (currentPageIndex >= 0 && currentPageIndex < theoryData.Pages.Count)
                {
                    var currentPage = theoryData.Pages[currentPageIndex];
                    DisplayTheoryPage(currentPage);
                }
                else
                {
                    MessageBox.Show("Недопустимый индекс страницы.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке теории из файла: {ex.Message}");
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                var currentPage = theoryData.Pages[currentPageIndex];
                DisplayTheoryPage(currentPage);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageIndex < theoryData.Pages.Count - 1)
            {
                currentPageIndex++;
                var currentPage = theoryData.Pages[currentPageIndex];
                DisplayTheoryPage(currentPage);
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string jsonFilePath = "C:/Users/emil/Desktop/Theory.json";
            LoadTheoryData(jsonFilePath);
        }
    }
}
