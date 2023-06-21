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
using System.Windows.Media.Animation;
using Chemistry_app.Controllers;
namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для RichTextBoxPage.xaml
    /// </summary>
    public partial class RichTextBoxPage : Page
    {
        private TheoryData theoryData;
        private bool isAnimating;
        int cardNumber;
        public RichTextBoxPage(int cardNumber)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            this.cardNumber = cardNumber;
        }
        private void LoadTheoryData(string jsonFilePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                theoryData = JsonConvert.DeserializeObject<TheoryData>(jsonContent);
                for (int i = 0; i < theoryData.Pages.Count; i++)
                {
                    RichTextBox richTextBox = FindName("ContentRichTextBox") as RichTextBox;
                    richTextBox.Document.Blocks.Clear();
                    var page = theoryData.Pages[cardNumber - 1];
                    var content = page.Content;
                    Paragraph paragraph = new Paragraph();
                    string[] words = content.Split(' ');
                    foreach (string word in words)
                    {
                        // Создание Run для каждого слова
                        Run run = new Run(word);
                        //Задание жирности слова
                        if (page.BoldWords.Contains(word))
                        {
                            run.FontWeight = FontWeights.Bold;
                        }
                        // Добавление Run в параграф
                        paragraph.Inlines.Add(run);
                        paragraph.Inlines.Add(" ");
                    }
                    // Добавление параграфа в RichTextBox
                    richTextBox.Document.Blocks.Add(paragraph);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке теории из файла: {ex.Message}");
            }
        }
        private async Task AnimateRichTextBox(RichTextBox richTextBox, bool show)
        {
            if (isAnimating)
                return;
            isAnimating = true;
            DoubleAnimation animation = new DoubleAnimation
            {
                From = show ? 0 : 1,
                To = show ? 1 : 0,
                Duration = TimeSpan.FromSeconds(2)
            };
            richTextBox.BeginAnimation(OpacityProperty, animation);
            await Task.Delay(TimeSpan.FromSeconds(1));
            richTextBox.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
            isAnimating = false;
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string jsonFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assert\\Theory.json");
            LoadTheoryData(jsonFilePath);
            await AnimateRichTextBox(ContentRichTextBox, true);
        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
