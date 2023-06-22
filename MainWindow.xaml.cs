
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
            WindowState = WindowState.Maximized;
            this.user = user;
            MenuName.Text = user.Name;
            MenuEmail.Text = user.Email;
            MenuAge.Text = $"Возраст: {user.Age}";
            MenuGender.Text = $"Пол: {user.Gender}";
            textBoxNameUser.Text = user.Name;
            textBoxEmailUser.Text = user.Email;
            SetButtonBackground(ButtonTheory, "#66E39C");
            FrameNavigator.MainFrame = MainFrame;
            FrameNavigator.MainFrame.Navigate(new TheorysPage());
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
            SetButtonBackground(ExitButton, "#FF0000");
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

        private void Border_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var border = (Border)sender;
                ContextMenu contextMenu = border.ContextMenu;
                if (contextMenu != null)
                {
                    contextMenu.PlacementTarget = border;
                    contextMenu.IsOpen = true;
                }
            }
        }

        private void MenuItem_PreviewMouseLeftButtonDown_ExitThisAccount(object sender, MouseButtonEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void LeaderBoard_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigator.MainFrame.Navigate(new PageForLeaderBoard());
            SetAllButtonBackgrounds("#363636");
        }
    }
}

