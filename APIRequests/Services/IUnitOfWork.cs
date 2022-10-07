using APIRequests.Services.Account;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;

namespace APIRequests.Services
{
    public interface IUnitOfWork
    {
        IAccountService AccountService { get; }
        IShoppingListService ShoppingListService { get; }
        IItemService ItemService { get; }
        IMemberService MemberService { get; }
    }
}