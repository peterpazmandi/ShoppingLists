using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services;
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
        private readonly IUnitOfWork _unitOfWork;

        public ItemListingViewModel(ShoppingListStore shoppingListStore, IUnitOfWork unitOfWork)
        {
            _itemListingItemViewModels = new AsyncObservableCollection<ItemListingItemViewModel>();
            _unitOfWork = unitOfWork;

            AddItems(shoppingListStore);
        }

        private void AddItems(ShoppingListStore shoppingListStore)
        {
            foreach (var item in shoppingListStore.SelectedShoppingList.Items)
            {
                var _item = new ItemListingItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Qty = item.Qty,
                    Unit = item.Unit,
                    Bought = item.Bought
                };
                _itemListingItemViewModels.Add(_item);
            }
        }
    }
}
