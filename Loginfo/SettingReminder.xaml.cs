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
    /// Interaction logic for SettingReminder.xaml
    /// </summary>
    public partial class SettingReminder : Window
    {

        private bool isNotificationOn = false;

        public SettingReminder()
        {
            InitializeComponent();

            // Attach event handlers for the toggle button
            NotificationToggle.Checked += ToggleButton_Checked;
            NotificationToggle.Unchecked += ToggleButton_Unchecked;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            isNotificationOn = true;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            isNotificationOn = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Display a message based on the toggle state
            if (isNotificationOn)
            {
                MessageBox.Show("Notifications are ON.");
            }
            else
            {
                MessageBox.Show("Notifications are OFF.");
            }
        }

        private void EPButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.Close();
            settings.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDashboard taskDashboard = new TaskDashboard();
            this.Close();
            taskDashboard.Show();
        }
    }
}
