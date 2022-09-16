using APIRequests.Accounts;
using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services.ShoppingList
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly ShoppingListsHttpClient _client;
        private readonly IAccountStore _accountStore;

        public ShoppingListService(ShoppingListsHttpClient client, IAccountStore accountStore)
        {
            _client = client;
            _accountStore = accountStore;
        }

        public async Task<List<ShoppingListDto>> GetMyShoppingLists()
        {
            var lists = await _client
                .GetAsync<List<ShoppingListDto>>("ShoppingList/GetMyShoppingLists", _accountStore.CurrentAccount.Token);
            return lists;
        }

        public async Task<MessageDto> UpdateShoppingList(UpdateShoppingListDto updateShoppingListDto)
        {
            return await _client
                .PostAsync<MessageDto>("ShoppingList/Update", updateShoppingListDto);
        }
    }
}
