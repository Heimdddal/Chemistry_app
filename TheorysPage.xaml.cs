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
    /// Логика взаимодействия для TheorysPage.xaml
    /// </summary>
    public partial class TheorysPage : Page
    {
        private TheoryData theoryData;
        private bool isAnimating;
        public TheorysPage()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void LoadTheoryData(string jsonFilePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                theoryData = JsonConvert.DeserializeObject<TheoryData>(jsonContent);

                for (int i = 0; i < theoryData.Pages.Count; i++)
                {
                    RichTextBox richTextBox = FindName($"richTextBox{i + 1}") as RichTextBox;
                    richTextBox.Document.Blocks.Clear();

                    var page = theoryData.Pages[i];
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
                            run.FontSize = 20;
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
                Duration = TimeSpan.FromSeconds(1)
            };

            richTextBox.BeginAnimation(OpacityProperty, animation);

            await Task.Delay(TimeSpan.FromSeconds(3));

            richTextBox.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
            isAnimating = false;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            List<RichTextBox> richTextBoxes = new List<RichTextBox>()
            {
                richTextBox1,
                richTextBox2,
                richTextBox3,
                richTextBox4,
                richTextBox5,
                richTextBox6
            };

            foreach (RichTextBox rtb in richTextBoxes)
            {
                rtb.Visibility = Visibility.Collapsed;
            }
            string jsonFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assert\\Theory.json");
            LoadTheoryData(jsonFilePath);
        }


        private async void RichTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            foreach (MaterialDesignThemes.Wpf.Card grid in new List<MaterialDesignThemes.Wpf.Card> { grid1, grid2, grid3, grid4, grid5, grid6 })
            {
                grid.Visibility = Visibility.Collapsed;
            }
            Dictionary<string, (RichTextBox richTextBox, int row, int column, int rowSpan, int columnSpan)> cardMap = new Dictionary<string, (RichTextBox, int, int, int, int)>
            {
                {"grid1", (richTextBox1, 0, 0, 2, 2)},
                {"grid2", (richTextBox2, 0, 0, 2, 2)},
                {"grid3", (richTextBox3, 0, 0, 2, 2)},
                {"grid4", (richTextBox4, 0, 0, 2, 2)},
                {"grid5", (richTextBox5, 0, 0, 2, 2)},
                {"grid6", (richTextBox6, 0, 0, 2, 2)}
            };
            if (sender is MaterialDesignThemes.Wpf.Card card && cardMap.TryGetValue(card.Name, out var mapping))
            {
                foreach (var pair in cardMap.Values)
                {
                    pair.richTextBox.Visibility = Visibility.Collapsed;
                }
                page.Height = 600;
                mapping.richTextBox.Visibility = Visibility.Visible;
                Grid.SetRow(mapping.richTextBox, mapping.row);
                Grid.SetColumn(mapping.richTextBox, mapping.column);
                Grid.SetRowSpan(mapping.richTextBox, mapping.rowSpan);
                Grid.SetColumnSpan(mapping.richTextBox, mapping.columnSpan);
                await AnimateRichTextBox(mapping.richTextBox, true);
                
                returnButton.Visibility = Visibility.Visible;
                Grid.SetColumnSpan(returnButton, 2);
                Grid.SetRow(returnButton, 2);
                returnButton.Margin = new Thickness(0, 100, 0, 0);
            }
        }
        private void returnButton_Click(object sender, RoutedEventArgs e)
        {

            page.Height = 1200;
            // Установить видимость всех сеток
            foreach (MaterialDesignThemes.Wpf.Card grid in new List<MaterialDesignThemes.Wpf.Card> { grid1, grid2, grid3, grid4, grid5, grid6 })
            {
                grid.Visibility = Visibility.Visible;
            }

            // Установить размеры и расположение всех RichTextBox
            foreach (RichTextBox richTextBox in new List<RichTextBox> {richTextBox1, richTextBox2,
                                                             richTextBox3, richTextBox4,
                                                             richTextBox5, richTextBox6})
            {
                int rowIndex = Grid.GetRow(richTextBox);
                int columnIndex = Grid.GetColumn(richTextBox);


                richTextBox.SetValue(Grid.RowSpanProperty, 1);
                richTextBox.SetValue(Grid.ColumnSpanProperty, 1);
                Grid.SetRow(richTextBox, rowIndex);
                Grid.SetColumn(richTextBox, columnIndex);
            }

            // Скрыть все RichTextBox и кнопку "returnButton"
            foreach (RichTextBox richTextBox in new List<RichTextBox> {richTextBox1, richTextBox2,
                                                             richTextBox3, richTextBox4,
                                                             richTextBox5, richTextBox6})
            {
                richTextBox.Visibility = Visibility.Collapsed;
            }
            returnButton.Visibility = Visibility.Collapsed;
        }
    }

}
