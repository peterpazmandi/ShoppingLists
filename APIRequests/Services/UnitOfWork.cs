using APIRequests.Accounts;
using APIRequests.Services.Account;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using APIRequests.SignalR.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ShoppingListsHttpClient _client;
        private readonly IAccountStore _accountStore;
        private readonly string _shoppingListHub;


        public IAccountService AccountService => new AccountService(_client);
        public IShoppingListService ShoppingListService => new ShoppingListService(_client, _accountStore);
        public IShoppingListHubService ShoppingListHubService { get; init; }
        public IItemService ItemService => new ItemService(_client, _accountStore);
        public IMemberService MemberService => new MemberService(_client, _accountStore);



        public UnitOfWork(ShoppingListsHttpClient client, IAccountStore accountStore, string shoppingListHub)
        {
            _client = client;
            _accountStore = accountStore;
            _shoppingListHub = shoppingListHub;

            ShoppingListHubService = new ShoppingListHubService(_shoppingListHub, _accountStore);
        }
    }
}
