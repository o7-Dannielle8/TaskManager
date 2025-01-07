﻿using Loginfo.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Loginfo.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand IOpenNewWindow => new RelayCommand(OpenNewWindow);
        public void OpenNewWindow()
        {
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            newTaskWindow.Show();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
