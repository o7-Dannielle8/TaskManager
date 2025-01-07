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
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        // Callback to pass the created task back to MainWindow
        public Action<TaskDashboard.TaskModel> TaskAddedCallback { get; set; }

        public NewTaskWindow()
        {
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate if the task title is not empty
            if (string.IsNullOrWhiteSpace(TaskTitleBox.Text))
            {
                MessageBox.Show("Task title cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new task
            var newTask = new TaskDashboard.TaskModel
            {
                Title = TaskTitleBox.Text,
                Description = TaskDescriptionBox.Text,
                Category = ((ComboBoxItem)CategoryComboBox.SelectedItem)?.Content.ToString(),
                DueDate = DueDatePicker.SelectedDate ?? DateTime.Now
            };

            // Check if TaskAddedCallback is not null before invoking it
            TaskAddedCallback?.Invoke(newTask);

            // Explicitly close the current NewTaskWindow
            this.Close();
        }

    }
}
