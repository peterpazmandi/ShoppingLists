using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services.Account;
using APIRequests.Services.ShoppingList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.ShoppingLists
{
    public class ShoppingListStore
    {
        private readonly IShoppingListService _shoppingListService;


        private List<ShoppingListDto> _shoppingLists;
        public IEnumerable<ShoppingListDto> ShoppingLists => _shoppingLists;



        private ShoppingListDto _selectedShoppingList;
        public ShoppingListDto SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set { _selectedShoppingList = value; }
        }




        public event Action ShoppingListsLoaded;

        public ShoppingListStore(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;

            _shoppingLists = new();
        }

        public async Task GetShoppingLists()
        {
            var shoppingLists = _shoppingListService.GetMyShoppingLists();

            this._shoppingLists.Clear();
            this._shoppingLists.AddRange(await shoppingLists);

            this.ShoppingListsLoaded?.Invoke();
        }
    }
}
