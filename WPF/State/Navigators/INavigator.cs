using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.ViewModels;

namespace WPF.State.Navigators
{
    public enum ViewType
    {
        Register,
        Login,
        Home,
        ShoppingList
    }

    public interface INavigator
    {
        public void OnWindowSizeChanged(object sender, SizeChangedEventArgs e);

        ViewModelBase CurrentViewModel { get; set; }
        double CurrentWindowHeight { get; set; }
        event Action StateChanged;
    }
}
