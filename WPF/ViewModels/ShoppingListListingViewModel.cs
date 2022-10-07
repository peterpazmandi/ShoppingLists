using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.ShoppingLists;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ShoppingListListingViewModel> _logger;
        private readonly ShoppingListStore _shoppingListStore;
        private readonly INavigator _navigator;
        private readonly IUnitOfWork _unitOfWork;



        private readonly AsyncObservableCollection<ShoppingListListingItemViewModel> _shoppingListListingItemViewModels;
        public IEnumerable<ShoppingListListingItemViewModel> ShoppingListListingItemViewModels => _shoppingListListingItemViewModels;

        public ShoppingListListingViewModel(ShoppingListStore shoppingListStore, INavigator navigator, IUnitOfWork unitOfWork, ILogger<ShoppingListListingViewModel> logger)
        {
            _shoppingListStore = shoppingListStore;

            _shoppingListListingItemViewModels = new();

            _shoppingListStore.ShoppingListsLoaded += ShoppingListStore_ShoppingListsLoaded;
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            _logger = logger;
        }

        private void ShoppingListStore_ShoppingListsLoaded()
        {
            _shoppingListListingItemViewModels.Clear();

            foreach (ShoppingListDto shoppingList in _shoppingListStore.ShoppingLists)
            {
                _logger.LogInformation($"{shoppingList}");
                AddShoppingList(shoppingList);
            }
        }

        private void AddShoppingList(ShoppingListDto shoppingList)
        {
            ShoppingListListingItemViewModel itemViewModel = new(shoppingList, _shoppingListStore, _navigator, _unitOfWork);
            _shoppingListListingItemViewModels.Add(itemViewModel);
        }
    }
}
