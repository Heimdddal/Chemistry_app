using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Newtonsoft.Json;

namespace Chemistry_app.View
{
    internal class TheoryPager
    {
        private List<string> theoryPages;  // Список страниц с теорией
        private int currentPageIndex;      // Индекс текущей страницы
        private int maxLinesPerPage;       // Максимальное количество строк на странице

        public TheoryPager(int linesPerPage)
        {
            theoryPages = new List<string>();
            currentPageIndex = 0;
            maxLinesPerPage = linesPerPage;
        }

        public void LoadTheoryFromJson(string jsonFilePath)
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                theoryPages = JsonConvert.DeserializeObject<List<string>>(json);
                currentPageIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке теории из файла: {ex.Message}");
            }
        }

        public void NextPage()
        {
            if (currentPageIndex < theoryPages.Count - 1)
                currentPageIndex++;
            else
                MessageBox.Show("Вы достигли последней страницы.");
        }

        public void PreviousPage()
        {
            if (currentPageIndex > 0)
                currentPageIndex--;
            else
                MessageBox.Show("Вы находитесь на первой странице.");
        }

        public void DisplayCurrentPage(RichTextBox richTextBox, TextBlock pageLabel)
        {
            if (currentPageIndex >= 0 && currentPageIndex < theoryPages.Count)
            {
                string currentPage = theoryPages[currentPageIndex];
                string[] lines = currentPage.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                int startIndex = Math.Max(0, lines.Length - maxLinesPerPage);
                int endIndex = Math.Min(startIndex + maxLinesPerPage, lines.Length);

                richTextBox.Document.Blocks.Clear();
                pageLabel.Text = $"Страница {currentPageIndex + 1} из {theoryPages.Count}";

                Paragraph paragraph = new Paragraph();

                for (int i = startIndex; i < endIndex; i++)
                {
                    paragraph.Inlines.Add(new Run(lines[i]));
                    paragraph.Inlines.Add(new LineBreak());
                }

                richTextBox.Document.Blocks.Add(paragraph);
            }
        }
    }
}
