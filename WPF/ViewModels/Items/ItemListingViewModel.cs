using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services;
using APIRequests.Services.Item;
using APIRequests.ShoppingLists;
using APIRequests.SignalR.ShoppingList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF.ViewModels.Items
{
    public sealed class ItemListingViewModel: ViewModelBase
    {
        private readonly ObservableCollection<ItemListingItemViewModel> _itemListingItemViewModels;
        public ObservableCollection<ItemListingItemViewModel> ItemListingItemViewModels => _itemListingItemViewModels;

        private readonly ShoppingListDto shoppingList;
        private readonly ShoppingListStore _shoppingListStore;
        private readonly IUnitOfWork _unitOfWork;

        //lock object for synchronization;
        private static object _syncLock = new object();

        public ItemListingViewModel(ShoppingListStore shoppingListStore, IUnitOfWork unitOfWork)
        {
            _itemListingItemViewModels = new AsyncObservableCollection<ItemListingItemViewModel>();
            _shoppingListStore = shoppingListStore;
            _unitOfWork = unitOfWork;

            //Enable the cross acces to this collection elsewhere
            BindingOperations.EnableCollectionSynchronization(ItemListingItemViewModels, _syncLock);

            AddItems(shoppingListStore);
        }

        private void AddItems(ShoppingListStore shoppingListStore)
        {
            foreach (var item in shoppingListStore.SelectedShoppingList.Items)
            {
                var _item = new ItemListingItemViewModel(_shoppingListStore, _unitOfWork)
                {
                    Id = item.Id,
                    Name = item.Name,
                    Qty = item.Qty,
                    Unit = item.Unit,
                    Bought = item.Bought
                };
                _item.ReorderItemsOrderByBoughtDelegate += ReorderItemsOrderByBought;
                _itemListingItemViewModels.Add(_item);
            }
        }

        private void ReorderItemsOrderByBought()
        {
            try
            {
                var orderedItems = _itemListingItemViewModels.OrderBy(i => i.Bought).ToList();
                _itemListingItemViewModels.Clear();
                foreach (var item in orderedItems)
                {
                    _itemListingItemViewModels.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
