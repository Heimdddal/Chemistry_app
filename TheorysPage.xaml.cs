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
            //// Скрыть все RichTextBox, кроме выбранного
            //foreach (UIElement element in grid.Children)
            //{
            //    if (element is Grid richTextBox && richTextBox != sender as Grid)
            //    {
            //        richTextBox.Visibility = Visibility.Collapsed;
            //    }
            //}
           
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
            returnButton.Visibility = Visibility.Visible;
            //richTextBox1.Visibility = Visibility.Visible;
            //if (((UIElement)sender).ToString() == "grid1") {
            //    richTextBox1.Visibility = Visibility.Visible;
            //    Grid.SetRow(richTextBox1, 0);
            //    Grid.SetColumn(richTextBox1, 0);
            //    Grid.SetRowSpan(richTextBox1, 3);
            //    Grid.SetColumnSpan(richTextBox1, 3);
            //}
            //int row = Grid.GetRow((UIElement)sender);
            //int column = Grid.GetColumn((UIElement)sender);

            //DoubleAnimation animation = new DoubleAnimation();
            //animation.From = 2; // начальный размер
            //animation.To = 470; // конечный размер
            //animation.Duration = TimeSpan.FromSeconds(10); // продолжительность анимации в секундах

            //((UIElement)sender).BeginAnimation(RichTextBox.HeightProperty, animation);

            //DoubleAnimation animation2 = new DoubleAnimation();
            //animation2.From = 2; // начальный размер
            //animation2.To = 880; // конечный размер
            //animation2.Duration = TimeSpan.FromSeconds(10); // продолжительность анимации в секундах

            //((UIElement)sender).BeginAnimation(RichTextBox.WidthProperty, animation2);

            //Int32Animation rowAnimation = new Int32Animation(row, 3, TimeSpan.FromSeconds(100));
            //Int32Animation colAnimation = new Int32Animation(column, 3, TimeSpan.FromSeconds(10));
            //Grid.SetRow((UIElement)sender, 0);
            //Grid.SetColumn((UIElement)sender, 0);
            //Grid.SetRowSpan((UIElement)sender, 3);
            //Grid.SetColumnSpan((UIElement)sender, 3);
            //grid.BeginAnimation(Grid.RowProperty, rowAnimation);
            //grid.BeginAnimation(Grid.ColumnProperty, colAnimation);

            //grid1.Visibility = Visibility.Visible;
            //grid2.Visibility = Visibility.Visible;
            //grid3.Visibility = Visibility.Visible;
            //grid4.Visibility = Visibility.Visible;
            //grid5.Visibility = Visibility.Visible;
            //grid6.Visibility = Visibility.Visible;
            //// Создаем экземпляр Storyboard
            //var storyboard = new Grid();

            //// Создаем ScaleTransform, чтобы изменить размеры элемента управления
            //var scaleTransform = new ScaleTransform(1, 1);

            //// Создаем анимацию для ScaleTransform
            //var scaleAnimation = new DoubleAnimation
            //{
            //    Duration = TimeSpan.FromSeconds(1),
            //    From = 1,
            //    To = 500,
            //    //AutoReverse = true
            //};

            //// Добавляем анимацию к Storyboard
            ////((UIElement)sender).Children.Add(scaleAnimation);

            //// Указываем свойства, которые будут анимироваться (в данном случае - RenderTransform)
            //Storyboard.SetTargetProperty(scaleAnimation, new PropertyPath("RenderTransform.ScaleX"));
            //Storyboard.SetTargetProperty(scaleAnimation, new PropertyPath("RenderTransform.ScaleY"));

            //// Указываем элемент управления, который будет анимироваться
            //Storyboard.SetTarget(scaleAnimation, (UIElement)sender);

            //// Запускаем анимацию
            //((UIElement)sender).BeginAnimation(RichTextBox.HeightProperty, scaleAnimation);

            //// Установить размеры и расположение выбранного RichTextBox
            //returnButton.Visibility = Visibility.Visible;
            //Grid.SetRow((UIElement)sender, 0);
            //Grid.SetColumn((UIElement)sender, 0);
            //Grid.SetRowSpan((UIElement)sender, 3);
            //Grid.SetColumnSpan((UIElement)sender, 3);

            //TransformGroup transformGroup = new TransformGroup();
            //ScaleTransform scaleTransform = new ScaleTransform();
            //transformGroup.Children.Add(scaleTransform);

            //((UIElement)sender).RenderTransform = transformGroup;

            ////scaleTransform.CenterX = ((UIElement)sender).Ce;
            ////scaleTransform.CenterY = richTextBox.ActualHeight / 2;

            //((UIElement)sender).RenderTransformOrigin = new Point(0.5, 0.5);

            //DoubleAnimation animation = new DoubleAnimation();
            ////Grid.Column = "2" Grid.Row = "1"
            //animation.From = 2; // начальный размер
            //animation.To = 470; // конечный размер
            //animation.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации в секундах
            //((UIElement)sender).BeginAnimation(RichTextBox.HeightProperty, animation);

            //DoubleAnimation animation2 = new DoubleAnimation();
            //animation2.From = 2; // начальный размер
            //animation2.To = 880; // конечный размер
            //animation2.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации в секундах

            //((UIElement)sender).BeginAnimation(RichTextBox.WidthProperty, animation2);
        }


        //private void richTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    //richTextBox2.Visibility = Visibility.Collapsed;
        //    TransformGroup transformGroup = new TransformGroup();
        //    ScaleTransform scaleTransform = new ScaleTransform();
        //    transformGroup.Children.Add(scaleTransform);

        //    richTextBox.RenderTransform = transformGroup;

        //    scaleTransform.CenterX = richTextBox.ActualWidth / 2;
        //    scaleTransform.CenterY = richTextBox.ActualHeight / 2;

        //    richTextBox.RenderTransformOrigin = new Point(0.5, 0.5);

        //    DoubleAnimation animation = new DoubleAnimation();
        //    //Grid.Column = "2" Grid.Row = "1"
        //    animation.From = 2; // начальный размер
        //    animation.To = 470; // конечный размер
        //    animation.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации в секундах
        //    richTextBox.BeginAnimation(RichTextBox.HeightProperty, animation);

        //    DoubleAnimation animation2 = new DoubleAnimation();
        //    animation2.From = 2; // начальный размер
        //    animation2.To = 880; // конечный размер
        //    animation2.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации в секундах

        //    richTextBox.BeginAnimation(RichTextBox.WidthProperty, animation2);
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// Показать все RichTextBox
            //foreach (UIElement element in grid.Children)
            //{
            //    if (element is RichTextBox richTextBox)
            //    {
            //        richTextBox.Visibility = Visibility.Visible;
            //    }
            //}
            // Получаем строку и столбец элемента
            //int row = Grid.GetRow((UIElement)sender);
            //int column = Grid.GetColumn((UIElement)sender);

            //// Создаем обратную анимацию для высоты RichTextBox
            //DoubleAnimation heightAnimation = new DoubleAnimation();
            //heightAnimation.From = 470; // конечный размер в оригинальной анимации
            //heightAnimation.To = 2; // начальный размер
            //heightAnimation.Duration = TimeSpan.FromSeconds(10); // продолжительность анимации в секундах
            //((UIElement)sender).BeginAnimation(RichTextBox.HeightProperty, heightAnimation);

            //// Создаем обратную анимацию для ширины RichTextBox
            //DoubleAnimation widthAnimation = new DoubleAnimation();
            //widthAnimation.From = 880; // конечный размер в оригинальной анимации
            //widthAnimation.To = 2; // начальный размер
            //widthAnimation.Duration = TimeSpan.FromSeconds(10); // продолжительность анимации в секундах
            //((UIElement)sender).BeginAnimation(RichTextBox.WidthProperty, widthAnimation);

            //// Создаем обратные анимации для строки и столбца элемента
            //Int32Animation rowAnimation = new Int32Animation(3, row, TimeSpan.FromSeconds(100));
            //Int32Animation colAnimation = new Int32Animation(3, column, TimeSpan.FromSeconds(10));
            //grid.BeginAnimation(Grid.RowProperty, rowAnimation);
            //grid.BeginAnimation(Grid.ColumnProperty, colAnimation);

            // Возвращаем элемент на исходную позицию и размер
            //Grid.SetRow((UIElement)sender, row);
            //Grid.SetColumn((UIElement)sender, column);
            //Grid.SetRowSpan((UIElement)sender, 1);
            //Grid.SetColumnSpan((UIElement)sender, 1);

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

        //private void richTextBox2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    TransformGroup transformGroup = new TransformGroup();
        //    ScaleTransform scaleTransform = new ScaleTransform();
        //    transformGroup.Children.Add(scaleTransform);

        //    richTextBox2.RenderTransform = transformGroup;

        //    scaleTransform.CenterX = richTextBox2.ActualWidth / 2;
        //    scaleTransform.CenterY = richTextBox2.ActualHeight / 2;

        //    richTextBox2.RenderTransformOrigin = new Point(0.5, 0.5);

        //    DoubleAnimation animation = new DoubleAnimation();
        //    animation.From = 2; // начальный размер
        //    animation.To = 470; // конечный размер
        //    animation.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации в секундах

        //    richTextBox2.BeginAnimation(RichTextBox.HeightProperty, animation);

        //    DoubleAnimation animation2 = new DoubleAnimation();
        //    animation2.From = 2; // начальный размер
        //    animation2.To = 880; // конечный размер
        //    animation2.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации в секундах

        //    richTextBox2.BeginAnimation(RichTextBox.WidthProperty, animation2);
        //}
    }
}
