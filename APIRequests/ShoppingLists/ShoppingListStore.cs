using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services;
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
        private readonly IUnitOfWork _unitOfWork;


        private List<ShoppingListDto> _shoppingLists;
        public IEnumerable<ShoppingListDto> ShoppingLists => _shoppingLists;



        private ShoppingListDto _selectedShoppingList;
        public ShoppingListDto SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set { _selectedShoppingList = value; }
        }




        public event Action ShoppingListsLoaded;



        public ShoppingListStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _shoppingLists = new();

            var numbers = new List<int>();
        }

        public async Task GetShoppingLists()
        {
            var shoppingLists = _unitOfWork.ShoppingListService.GetMyShoppingLists();

            this._shoppingLists.Clear();
            this._shoppingLists.AddRange(await shoppingLists);

            this.ShoppingListsLoaded?.Invoke();
        }

        public async Task<bool> UpdateItemBoughtState(int itemId, bool bought)
        {
            var result = await _unitOfWork.ItemService.UpdateItemBoughtStateById<MessageDto>(itemId, bought);

            if (result.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                await _unitOfWork.ShoppingListHubService.SendUpdateItemBoughtChanged(itemId, bought);
            }

            return result.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
