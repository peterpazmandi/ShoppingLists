using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public sealed class ShoppingListListingViewModel: ViewModelBase
    {
        private readonly ShoppingListStore _shoppingListStore;

        private readonly AsyncObservableCollection<ShoppingListListingItemViewModel> _shoppingListListingItemViewModels;
        public IEnumerable<ShoppingListListingItemViewModel> ShoppingListListingItemViewModels => _shoppingListListingItemViewModels;

        public ShoppingListListingViewModel(ShoppingListStore shoppingListStore)
        {
            _shoppingListStore = shoppingListStore;

            _shoppingListListingItemViewModels = new();

            _shoppingListStore.ShoppingListsLoaded += ShoppingListStore_ShoppingListsLoaded;


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
            ShoppingListListingItemViewModel itemViewModel = new(shoppingList, _shoppingListStore);
            _shoppingListListingItemViewModels.Add(itemViewModel);
        }
    }
}
