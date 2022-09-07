using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPF.ViewModels;

namespace WPF.State.Navigators
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        private double _currentWindowHeight;
        public double CurrentWindowHeight
        {
            get 
            { 
                return _currentWindowHeight;
            }
            set 
            { 
                _currentWindowHeight = value;
                StateChanged?.Invoke();
            }
        }


        public event Action StateChanged;

        public void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            CurrentWindowHeight = e.NewSize.Height;
        }
    }
}
