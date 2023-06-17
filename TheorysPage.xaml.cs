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
                richTextBox1.Document.Blocks.Clear();
                richTextBox1.Document.Blocks.Add(new Paragraph(new Run((theoryData.Pages[0]).Content)));
                richTextBox2.Document.Blocks.Clear();
                richTextBox2.Document.Blocks.Add(new Paragraph(new Run((theoryData.Pages[1]).Content)));
                richTextBox3.Document.Blocks.Clear();
                richTextBox3.Document.Blocks.Add(new Paragraph(new Run((theoryData.Pages[2]).Content)));
                richTextBox4.Document.Blocks.Clear();
                richTextBox4.Document.Blocks.Add(new Paragraph(new Run((theoryData.Pages[3]).Content)));
                richTextBox5.Document.Blocks.Clear();
                richTextBox5.Document.Blocks.Add(new Paragraph(new Run((theoryData.Pages[4]).Content)));
                richTextBox6.Document.Blocks.Clear();
                richTextBox6.Document.Blocks.Add(new Paragraph(new Run((theoryData.Pages[5]).Content)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке теории из файла: {ex.Message}");
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            richTextBox1.Visibility = Visibility.Collapsed;
            richTextBox2.Visibility = Visibility.Collapsed;
            richTextBox3.Visibility = Visibility.Collapsed;
            richTextBox4.Visibility = Visibility.Collapsed;
            richTextBox5.Visibility = Visibility.Collapsed;
            richTextBox6.Visibility = Visibility.Collapsed;
            returnButton.Visibility = Visibility.Collapsed;
            string jsonFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assert\\Theory.json");
            LoadTheoryData(jsonFilePath);
        }
        private void RichTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grid1.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid3.Visibility = Visibility.Collapsed;
            grid4.Visibility = Visibility.Collapsed;
            grid5.Visibility = Visibility.Collapsed;
            grid6.Visibility = Visibility.Collapsed;
            returnButton.Visibility = Visibility.Visible;
            if (sender is MaterialDesignThemes.Wpf.Card card)
            {
                if (card.Name == "grid1")
                {
                    richTextBox1.Visibility = Visibility.Visible;
                    Grid.SetRow(richTextBox1, 0);
                    Grid.SetColumn(richTextBox1, 0);
                    Grid.SetRowSpan(richTextBox1, 3);
                    Grid.SetColumnSpan(richTextBox1, 3);
                }
                else if (card.Name == "grid2")
                {
                    richTextBox2.Visibility = Visibility.Visible;
                    Grid.SetRow(richTextBox2, 0);
                    Grid.SetColumn(richTextBox2, 0);
                    Grid.SetRowSpan(richTextBox2, 3);
                    Grid.SetColumnSpan(richTextBox2, 3);
                }
                else if (card.Name == "grid3")
                {
                    richTextBox3.Visibility = Visibility.Visible;
                    Grid.SetRow(richTextBox3, 0);
                    Grid.SetColumn(richTextBox3, 0);
                    Grid.SetRowSpan(richTextBox3, 3);
                    Grid.SetColumnSpan(richTextBox3, 3);
                }
                else if (card.Name == "grid4")
                {
                    richTextBox4.Visibility = Visibility.Visible;
                    Grid.SetRow(richTextBox4, 0);
                    Grid.SetColumn(richTextBox4, 0);
                    Grid.SetRowSpan(richTextBox4, 3);
                    Grid.SetColumnSpan(richTextBox4, 3);
                }
                else if (card.Name == "grid5")
                {
                    richTextBox5.Visibility = Visibility.Visible;
                    Grid.SetRow(richTextBox5, 0);
                    Grid.SetColumn(richTextBox5, 0);
                    Grid.SetRowSpan(richTextBox5, 3);
                    Grid.SetColumnSpan(richTextBox5, 3);
                }
                else if (card.Name == "grid6")
                {
                    richTextBox6.Visibility = Visibility.Visible;
                    Grid.SetRow(richTextBox6, 0);
                    Grid.SetColumn(richTextBox6, 0);
                    Grid.SetRowSpan(richTextBox6, 3);
                    Grid.SetColumnSpan(richTextBox6, 3);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Visible;
            grid2.Visibility = Visibility.Visible;
            grid3.Visibility = Visibility.Visible;
            grid4.Visibility = Visibility.Visible;
            grid5.Visibility = Visibility.Visible;
            grid6.Visibility = Visibility.Visible;
            returnButton.Visibility = Visibility.Collapsed;
            // Установить размеры и расположение всех RichTextBox обратно
            Grid.SetRow(richTextBox1, 0);
            Grid.SetColumn(richTextBox1, 0);
            Grid.SetRowSpan(richTextBox1, 1);
            Grid.SetColumnSpan(richTextBox1, 1);

            Grid.SetRow(richTextBox2, 0);
            Grid.SetColumn(richTextBox2, 1);
            Grid.SetRowSpan(richTextBox2, 1);
            Grid.SetColumnSpan(richTextBox2, 1);

            Grid.SetRow(richTextBox3, 1);
            Grid.SetColumn(richTextBox3, 0);
            Grid.SetRowSpan(richTextBox3, 1);
            Grid.SetColumnSpan(richTextBox3, 1);

            Grid.SetRow(richTextBox4, 1);
            Grid.SetColumn(richTextBox4, 1);
            Grid.SetRowSpan(richTextBox4, 1);
            Grid.SetColumnSpan(richTextBox4, 1);

            Grid.SetRow(richTextBox5, 2);
            Grid.SetColumn(richTextBox5, 0);
            Grid.SetRowSpan(richTextBox5, 1);
            Grid.SetColumnSpan(richTextBox5, 1);

            Grid.SetRow(richTextBox6, 2);
            Grid.SetColumn(richTextBox6, 1);
            Grid.SetRowSpan(richTextBox6, 1);
            Grid.SetColumnSpan(richTextBox6, 1);
            richTextBox1.Visibility = Visibility.Collapsed;
            richTextBox2.Visibility = Visibility.Collapsed;
            richTextBox3.Visibility = Visibility.Collapsed;
            richTextBox4.Visibility = Visibility.Collapsed;
            richTextBox5.Visibility = Visibility.Collapsed;
            richTextBox6.Visibility = Visibility.Collapsed;
            returnButton.Visibility = Visibility.Collapsed;
        }
    }
}
