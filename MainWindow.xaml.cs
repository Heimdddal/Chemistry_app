
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
        private void SetButtonBackground(System.Windows.Controls.Border button, string colorCode)
        {
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorCode));
        }

        private void SetAllButtonBackgrounds(string colorCode)
        {
            SetButtonBackground(ButtonTests, colorCode);
            SetButtonBackground(ButtonMendeleevTable, colorCode);
            SetButtonBackground(ButtonTheory, colorCode);
            SetButtonBackground(ButtonSolubillityTable, colorCode);
            SetButtonBackground(ButtonMetalActivityTable, colorCode);
            SetButtonBackground(ExitButton, colorCode);
        }

        private void ButtonTests_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new PageForTest(user));
            SetAllButtonBackgrounds("#363636");
            SetButtonBackground(ButtonTests, "#66E39C");

        }
        private void ButtonTheory_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new TheorysPage());
            SetAllButtonBackgrounds("#363636");
            SetButtonBackground(ButtonTheory, "#66E39C");
        }
        private void ButtonMendeleevTable_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new MendeleevTablePage());
            SetAllButtonBackgrounds("#363636");
            SetButtonBackground(ButtonMendeleevTable, "#66E39C");
        }

        private void ButtonSolubillityTable_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new Page1());
            SetAllButtonBackgrounds("#363636");
            SetButtonBackground(ButtonSolubillityTable, "#66E39C");
        }

        private void ButtonMetalActivityTable_Click(object sender, MouseButtonEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new MetalActivity());
            SetAllButtonBackgrounds("#363636");
            SetButtonBackground(ButtonMetalActivityTable, "#66E39C");
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Подтвердите выход", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Close();
        }

        private void GoBack_Click(object sender, MouseButtonEventArgs e)
        {
            if (FrameNavigator.MainFrame.CanGoBack) FrameNavigator.MainFrame.GoBack();
            else FrameNavigator.MainFrame.Navigate(null);
        }

        private void GoForward_Click(object sender, MouseButtonEventArgs e)
        {
            if (FrameNavigator.MainFrame.CanGoForward) FrameNavigator.MainFrame.GoForward();
        }
    }
}

