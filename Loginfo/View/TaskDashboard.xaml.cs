using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TaskDashboard.xaml
    /// </summary>
    public partial class TaskDashboard : Window
    {
        // Inline TaskModel class
        public class TaskModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime DueDate { get; set; }
        }

        // ObservableCollection to store and bind tasks
        public ObservableCollection<TaskModel> Tasks { get; set; }

        public TaskDashboard()
        {
            InitializeComponent();

            // Initialize the Tasks collection
            Tasks = new ObservableCollection<TaskModel>();
            TaskListView.ItemsSource = Tasks; // Bind the ListView to the Tasks collection
        }

        private void Complete_Button(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.Close();
            settings.Show();
        }

        public class TaskList
        {
            public string Character { get; set; }
            public string Task { get; set; }
            public string Details { get; set; }

        }

        // Method to add a new task to the Tasks collection
        public void AddTaskToList(TaskModel newTask)
        {
            Tasks.Add(newTask); // Add the task to the collection
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Open NewTaskWindow
            var newTaskWindow = new View.NewTaskWindow
            {
                TaskAddedCallback = task =>
                {
                    AddTaskToList(task); // Add the task to the list
                                         // Close the NewTaskWindow programmatically
                }
            };

            // Open the window as a dialog
            newTaskWindow.ShowDialog();

            // At this point, the NewTaskWindow is already closed.
        }
    }
}