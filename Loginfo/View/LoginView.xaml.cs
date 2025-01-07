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

namespace Loginfo.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            /*SignUp objSignUp = new SignUp();
            this.Visibility = Visibility.Hidden;
            objSignUp.Show();*/

            AdminDashboard adminDashboard = new AdminDashboard();
            this.Close();
            adminDashboard.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //OTP objOTP = new OTP();
            //this.Close();
            //objOTP.Show();

            TaskDashboard taskDashboard = new TaskDashboard();
            this.Close();
            taskDashboard.Show();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ForgotPass objForgotPass = new ForgotPass();
            this.Close();
            objForgotPass.Show();
        }
    }
}
