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
    public class OpenShoppingListCommand : AsyncCommandBase
    {
        private readonly ShoppingListViewModel _shoppingListViewModel;
        private readonly INavigator _navigator;
        public IMemberService _memberService;

        public OpenShoppingListCommand(ShoppingListViewModel shoppingListViewModel, INavigator navigator, IMemberService memberService)
        {
            _shoppingListViewModel = shoppingListViewModel;
            _navigator = navigator;
            _memberService = memberService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigator.CurrentViewModel = new ShoppingListViewModel(_shoppingListViewModel, _navigator, _memberService);
        }
    }
}
