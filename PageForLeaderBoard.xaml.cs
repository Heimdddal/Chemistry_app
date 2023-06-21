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
using System.IO;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для PageForLeaderBoard.xaml
    /// </summary>
    public partial class PageForLeaderBoard : Page
    {
        public PageForLeaderBoard()
        {
            InitializeComponent();
            string jsonFile = File.ReadAllText("Assert\\results.json");

            List<string> list = jsonFile.Split('\n', '\r').Where(p => !string.IsNullOrEmpty(p))
                .OrderByDescending(p => int.Parse(p.Split(':')[1]))
                .ThenBy(v => v.Split(':')[0])
                .ToList();

            var leaderBoardPage = new LeaderBoardPage(ref LeaderBoardGrid, list);
        }
    }
}
