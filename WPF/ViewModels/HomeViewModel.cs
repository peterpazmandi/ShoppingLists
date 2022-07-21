using APIRequests.Services.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private readonly IShoppingListService _shoppingListService;

        public HomeViewModel(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;

            Task.Run(async () =>
            {
                await GetMyShoppingLists();
            });
        }

        private async Task GetMyShoppingLists()
        {
            var lists = await _shoppingListService.GetMyShoppingLists();
        }
    }
}
