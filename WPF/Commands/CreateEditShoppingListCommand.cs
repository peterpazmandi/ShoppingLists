using APIRequests.Services.Member;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Extensions;
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
            _navigator = navigator;
            _createEditShoppingListViewModel = new CreateEditShoppingListViewModel(memberService, shoppingListViewModel);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigator.CurrentViewModel = _createEditShoppingListViewModel;
        }
    }
}
