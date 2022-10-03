using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services.Item;
using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels.Items
{
    public sealed class ItemListingViewModel: ViewModelBase
    {
        private readonly AsyncObservableCollection<ItemListingItemViewModel> _itemListingItemViewModels;
        public IEnumerable<ItemListingItemViewModel> ItemListingItemViewModels => _itemListingItemViewModels;

        private readonly ShoppingListDto shoppingList;
        private readonly IItemService _itemService;

        public ItemListingViewModel(ShoppingListStore shoppingListStore, IItemService itemService)
        {
            _itemListingItemViewModels = new AsyncObservableCollection<ItemListingItemViewModel>();
            _itemService = itemService;

            AddItems(shoppingListStore);
        }

        private void AddItems(ShoppingListStore shoppingListStore)
        {
            foreach (var item in shoppingListStore.SelectedShoppingList.Items)
            {
                var _item = new ItemListingItemViewModel()
                {
                    Name = item.Name
                };
                _itemListingItemViewModels.Add(_item);
            }
        }
    }
}
