using Microsoft.Win32;
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
    /// Interaction logic for General.xaml
    /// </summary>
    public partial class General : UserControl
    {
        public General()
        {
            InitializeComponent();
        }

        private void AddAdminButton_Click(object sender, RoutedEventArgs e)
        {
            // Create the popup window
            Window popup = new Window
            {
                Title = "Add New Admin",
                Width = 400,
                Height = 400,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                Owner = Application.Current.MainWindow
            };

            // Create the popup content
            Grid popupGrid = new Grid { Margin = new Thickness(10) };
            popup.Content = popupGrid;

            StackPanel popupStackPanel = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };

            TextBlock popupTitle = new TextBlock
            {
                Text = "Add New Admin",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 20),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBox nameTextBox = new TextBox
            {
                Width = 300,
                Height = 30,
                Margin = new Thickness(0, 0, 0, 10),
                VerticalContentAlignment = VerticalAlignment.Center
            };
            nameTextBox.GotFocus += (s, args) => { if (nameTextBox.Text == "Enter Admin Name") nameTextBox.Text = ""; };
            nameTextBox.LostFocus += (s, args) => { if (string.IsNullOrWhiteSpace(nameTextBox.Text)) nameTextBox.Text = "Enter Admin Name"; };
            nameTextBox.Text = "Enter Admin Name";

            TextBox roleTextBox = new TextBox
            {
                Width = 300,
                Height = 30,
                Margin = new Thickness(0, 0, 0, 10),
                VerticalContentAlignment = VerticalAlignment.Center
            };
            roleTextBox.GotFocus += (s, args) => { if (roleTextBox.Text == "Enter Admin Role") roleTextBox.Text = ""; };
            roleTextBox.LostFocus += (s, args) => { if (string.IsNullOrWhiteSpace(roleTextBox.Text)) roleTextBox.Text = "Enter Admin Role"; };
            roleTextBox.Text = "Enter Admin Role";

            Button selectImageButton = new Button
            {
                Content = "Select Image",
                Width = 150,
                Height = 30,
                Margin = new Thickness(0, 0, 0, 10)
            };

            string selectedImagePath = string.Empty;
            Image imagePreview = new Image
            {
                Width = 100,
                Height = 100,
                Margin = new Thickness(0, 10, 0, 10),
                Visibility = Visibility.Collapsed
            };

            selectImageButton.Click += (s, args) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                    Title = "Select an Image"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    selectedImagePath = openFileDialog.FileName;
                    imagePreview.Source = new BitmapImage(new Uri(selectedImagePath, UriKind.Absolute));
                    imagePreview.Visibility = Visibility.Visible; // Show the image preview
                }
            };

            StackPanel buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 20, 0, 0)
            };

            Button cancelButton = new Button
            {
                Content = "Cancel",
                Width = 80
            };

            Button addButton = new Button
            {
                Content = "Add",
                Width = 80
            };

            // Add UI elements to popup
            popupStackPanel.Children.Add(popupTitle);
            popupStackPanel.Children.Add(nameTextBox);
            popupStackPanel.Children.Add(roleTextBox);
            popupStackPanel.Children.Add(selectImageButton);
            popupStackPanel.Children.Add(imagePreview); // Add the image preview control
            buttonPanel.Children.Add(cancelButton);
            buttonPanel.Children.Add(addButton);
            popupStackPanel.Children.Add(buttonPanel);
            popupGrid.Children.Add(popupStackPanel);

            // Cancel button click event
            cancelButton.Click += (s, args) => popup.Close();

            // Add button click event
            addButton.Click += (s, args) =>
            {
                string adminName = nameTextBox.Text;
                string adminRole = roleTextBox.Text;

                if (string.IsNullOrWhiteSpace(adminName) || adminName == "Enter Admin Name" || string.IsNullOrWhiteSpace(adminRole) || adminRole == "Enter Admin Role")
                {
                    MessageBox.Show("Both name and role are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(selectedImagePath))
                {
                    MessageBox.Show("Please select an image for the admin.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Add new admin card
                AddAdminCard(adminName, adminRole, selectedImagePath);
                popup.Close();
            };

            // Show popup
            popup.ShowDialog();
        }

        private void AddAdminCard(string name, string role, string imagePath)
        {
            // Create new admin card
            Border newCard = new Border
            {
                BorderBrush = new SolidColorBrush(Color.FromRgb(221, 221, 221)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(10),
                Width = 250,
                Height = 250,
                Margin = new Thickness(10),
                Background = Brushes.White
            };

            StackPanel stackPanel = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10)
            };

            Image image = new Image
            {
                Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)),
                Width = 80,
                Height = 80,
                ClipToBounds = true,
                Stretch = Stretch.Uniform,
                Margin = new Thickness(0, 10, 0, 10)
            };

            image.Clip = new EllipseGeometry
            {
                RadiusX = 40,
                RadiusY = 40,
                Center = new Point(40, 40)
            };

            TextBlock nameText = new TextBlock
            {
                Text = name,
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51)),
                Margin = new Thickness(10, 10, 10, 0),
                TextAlignment = TextAlignment.Center
            };

            TextBlock roleText = new TextBlock
            {
                Text = role,
                FontSize = 22,
                Foreground = new SolidColorBrush(Color.FromRgb(119, 119, 119)),
                TextAlignment = TextAlignment.Center
            };

            stackPanel.Children.Add(image);
            stackPanel.Children.Add(nameText);
            stackPanel.Children.Add(roleText);
            newCard.Child = stackPanel;

            // Add the new card to the WrapPanel before the AddAdminButton
            AdminWrapPanel.Children.Insert(AdminWrapPanel.Children.Count - 1, newCard);
        }
    }
}
