using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chemistry_app
{
    internal class LeaderBoardPage
    {
        public LeaderBoardPage(ref Grid grid, List<string> strList)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(new Label() {Content="Таблица лидеров:", HorizontalAlignment= System.Windows.HorizontalAlignment.Center
            , FontSize=35, Foreground=Brushes.White});

            ListBox listBox = new ListBox() { HorizontalAlignment = System.Windows.HorizontalAlignment.Center, Foreground = Brushes.White,
            FontSize=20};
            ScrollViewer scrollViewer = new ScrollViewer();
            foreach (string str in strList)
            {
                listBox.Items.Add(str);
            }
            stackPanel.Children.Add(listBox);
            scrollViewer.Content = stackPanel;
            grid.Children.Add(scrollViewer);

        }
    }
}
