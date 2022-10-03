using APIRequests.DTOs;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;
using WPF.ViewModels.Items;

namespace WPF.ViewModels
{
    public sealed class ViewShoppingListViewModel: ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IMemberService _memberService;

        public ShoppingListDto ShoppingList { get; set; }
        public ItemListingViewModel ItemListingViewModel { get; }

        public ViewShoppingListViewModel(ShoppingListStore shoppingListStore, INavigator navigator, IMemberService memberService, IItemService itemService)
        {
            _navigator = navigator;
            _memberService = memberService;

            ShoppingList = shoppingListStore.SelectedShoppingList;

            ItemListingViewModel = new ItemListingViewModel(shoppingListStore, itemService);
        }
    }
}
