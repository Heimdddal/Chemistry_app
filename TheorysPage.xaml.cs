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
        public TheorysPage()
        {
            InitializeComponent();
        }
        private void card_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dictionary<string, int> cardMap = new Dictionary<string, int>
            {
                {"card1", 1},
                {"card2", 2},
                {"card3", 3},
                {"card4", 4},
                {"card5", 5},
                {"card6", 6}
            };

            if (sender is MaterialDesignThemes.Wpf.Card card && cardMap.TryGetValue(card.Name, out var mapping))
            {
                NavigationService?.Navigate(new RichTextBoxPage(mapping));
            }
        }
    }
}
