using Loginfo.View;
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
using System.Windows.Shapes;

namespace Loginfo
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();

            // Load General tab initially
            GeneralButton.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 123, 255));
            MainContentControl.Content = new General();
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            // Reset background for all buttons
            GeneralButton.Background = SettingsButton.Background = UsersButton.Background =
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 240, 240, 240));

            // Highlight the clicked button in blue
            clickedButton.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 123, 255));

            // Switch the content based on the clicked tab
            switch (clickedButton.Tag.ToString())
            {
                case "General":
                    MainContentControl.Content = new General();
                    break;
                case "Settings":
                    MainContentControl.Content = new AdminSetting();
                    break;
                case "Users":
                    MainContentControl.Content = new Users();
                    break;
            }
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            this.Close();
            loginView.Show();
        }
    }
}
