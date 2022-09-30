using APIRequests.DTOs;
using APIRequests.Services.Member;
using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;

namespace WPF.ViewModels
{
    public sealed class ViewShoppingListViewModel: ViewModelBase
    {
        private readonly ShoppingListDto _selectedShoppingList;
        private readonly INavigator _navigator;
        private readonly IMemberService _memberService;
        private readonly ShoppingListStore _shoppingListStore;

        public ViewShoppingListViewModel(INavigator navigator, IMemberService memberService, ShoppingListStore shoppingListStore)
        {
            _selectedShoppingList = shoppingListStore.SelectedShoppingList;
            _navigator = navigator;
            _memberService = memberService;
            _shoppingListStore = shoppingListStore;
        }
    }
}
