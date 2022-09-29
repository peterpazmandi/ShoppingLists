using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;

namespace WPF.Commands
{
    public sealed class GetShoppingListsCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly ShoppingListStore _shoppingListStore;

        public GetShoppingListsCommand(HomeViewModel homeViewModel, ShoppingListStore shoppingListStore)
        {
            _homeViewModel = homeViewModel;
            _shoppingListStore = shoppingListStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _homeViewModel.ErrorMessage = null;
            _homeViewModel.IsLoading = true;

            try
            {
                await _shoppingListStore.GetShoppingLists();
            }
            catch (Exception ex)
            {
                _homeViewModel.ErrorMessage = ex.Message;
            }
            finally
            {
                _homeViewModel.IsLoading = false;
            }
        }
    }
}
