using APIRequests.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services.Item
{
    public class ItemService : IItemService
    {
        private readonly ShoppingListsHttpClient _client;
        private readonly IAccountStore _accountStore;

        public ItemService(ShoppingListsHttpClient client, IAccountStore accountStore)
        {
            _client = client;
            _accountStore = accountStore;
        }

        public async Task<T> UpdateItemBoughtStateById<T>(int itemId, bool bought)
        {
            return await _client.PostAsync<T>("Item/UpdateItemBoughtStateById", new { ItemId = itemId, Bought = bought }, _accountStore.CurrentAccount.Token);
        }
    }
}
