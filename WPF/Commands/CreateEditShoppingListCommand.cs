using APIRequests.Services.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class CreateEditShoppingListCommand : AsyncCommandBase
    {
        private readonly CreateEditShoppingListViewModel _createEditShoppingListViewModel;
        private readonly INavigator _navigator;

        public CreateEditShoppingListCommand(ShoppingListViewModel shoppingListViewModel, INavigator navigator, IMemberService memberService)
        {
            _createEditShoppingListViewModel = new CreateEditShoppingListViewModel(memberService, shoppingListViewModel);
            _navigator = navigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigator.CurrentViewModel = _createEditShoppingListViewModel;
        }
    }
}
