using APIRequests.DTOs;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using APIRequests.ShoppingLists;
using AutoMapper;
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
        private readonly INavigator _navigator;
        private readonly IMemberService _memberService;
        private readonly ShoppingListStore _shoppingListStore;


        public OpenShoppingListCommand(INavigator navigator, IMemberService memberService, ShoppingListStore shoppingListStore)
        {
            _navigator = navigator;
            _memberService = memberService;
            _shoppingListStore = shoppingListStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is ShoppingListDto)
            {
                _shoppingListStore.SelectedShoppingList = (ShoppingListDto)parameter;
            }

            _navigator.CurrentViewModel = new ViewShoppingListViewModel(_navigator, _memberService, _shoppingListStore);
        }
    }
}
