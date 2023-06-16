
using Chemistry_app.Controllers;
using Chemistry_app.Models;
using Chemistry_app.ViewModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chemistry_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public User user { get; set; }
        public MainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            textBoxNameUser.Text = user.Name;
            textBoxEmailUser.Text = user.Email;
            FrameNavigator.MainFrame = MainFrame;
            
        }

        private void ButtonTests_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new PageForTest());
        }


        private void ButtonTheory_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new TheorysPage());
        }

        private void ButtonMendeleevTable_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new MendeleevTablePage());
        }

        private void ButtonSolubillityTable_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new Page1());
        }

        private void ButtonMetalActivityTable_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new MetalActivity());
        }
    }
}

