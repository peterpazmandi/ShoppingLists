using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class OpenShoppingListCommand : AsyncCommandBase
    {
        private readonly ShoppingListViewModel _shoppingListViewModel;
        private readonly INavigator _navigator;

        public OpenShoppingListCommand(ShoppingListViewModel shoppingListViewModel, INavigator navigator)
        {
            _shoppingListViewModel = shoppingListViewModel;
            _navigator = navigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigator.CurrentViewModel = _shoppingListViewModel;
        }
    }
}
