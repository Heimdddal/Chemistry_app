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



namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для TheorysPage.xaml
    /// </summary>
    public partial class TheorysPage : Page
    {
        public TheorysPage()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private TheoryData theoryData;

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
                    richTextBox.Document.Blocks.Add(new Paragraph(new Run((theoryData.Pages[i]).Content)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке теории из файла: {ex.Message}");
            }
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
            returnButton.Visibility = Visibility.Collapsed;
            string jsonFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assert\\Theory.json");
            LoadTheoryData(jsonFilePath);
        }


        private void RichTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Dictionary<string, (RichTextBox richTextBox, int row, int column, int rowSpan, int columnSpan)> cardMap = new Dictionary<string, (RichTextBox, int, int, int, int)>
            {
                {"grid1", (richTextBox1, 0, 0, 3, 3)},
                {"grid2", (richTextBox2, 0, 0, 3, 3)},
                {"grid3", (richTextBox3, 0, 0, 3, 3)},
                {"grid4", (richTextBox4, 0, 0, 3, 3)},
                {"grid5", (richTextBox5, 0, 0, 3, 3)},
                {"grid6", (richTextBox6, 0, 0, 3, 3)}
            };

            if (sender is MaterialDesignThemes.Wpf.Card card && cardMap.TryGetValue(card.Name, out var mapping))
            {
                foreach (var pair in cardMap.Values)
                {
                    pair.richTextBox.Visibility = Visibility.Collapsed;
                }

                mapping.richTextBox.Visibility = Visibility.Visible;
                Grid.SetRow(mapping.richTextBox, mapping.row);
                Grid.SetColumn(mapping.richTextBox, mapping.column);
                Grid.SetRowSpan(mapping.richTextBox, mapping.rowSpan);
                Grid.SetColumnSpan(mapping.richTextBox, mapping.columnSpan);

                grid1.Visibility = Visibility.Collapsed;
                grid2.Visibility = Visibility.Collapsed;
                grid3.Visibility = Visibility.Collapsed;
                grid4.Visibility = Visibility.Collapsed;
                grid5.Visibility = Visibility.Collapsed;
                grid6.Visibility = Visibility.Collapsed;

                returnButton.Visibility = Visibility.Visible;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
