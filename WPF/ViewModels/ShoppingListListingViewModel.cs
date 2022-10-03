using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services.Item;
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
    public sealed class ShoppingListListingViewModel: ViewModelBase
    {
        private readonly ShoppingListStore _shoppingListStore;
        private readonly INavigator _navigator;
        private readonly IMemberService _memberService;
        private readonly IItemService _itemService;



        private readonly AsyncObservableCollection<ShoppingListListingItemViewModel> _shoppingListListingItemViewModels;
        public IEnumerable<ShoppingListListingItemViewModel> ShoppingListListingItemViewModels => _shoppingListListingItemViewModels;

        public ShoppingListListingViewModel(ShoppingListStore shoppingListStore, INavigator navigator, IMemberService memberService, IItemService itemService)
        {
            _shoppingListStore = shoppingListStore;

            _shoppingListListingItemViewModels = new();

            _shoppingListStore.ShoppingListsLoaded += ShoppingListStore_ShoppingListsLoaded;
            _navigator = navigator;
            _memberService = memberService;
            _itemService = itemService;
        }

        private void ShoppingListStore_ShoppingListsLoaded()
        {
            _shoppingListListingItemViewModels.Clear();

            foreach (ShoppingListDto shoppingList in _shoppingListStore.ShoppingLists)
            {
                AddShoppingList(shoppingList);
            }
        }

        private void AddShoppingList(ShoppingListDto shoppingList)
        {
            ShoppingListListingItemViewModel itemViewModel = new(shoppingList, _shoppingListStore, _navigator, _memberService, _itemService);
            _shoppingListListingItemViewModels.Add(itemViewModel);
        }
    }
}
