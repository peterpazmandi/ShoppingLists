using APIRequests.SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.SignalR.ShoppingList
{
    public interface IShoppingListHubService
    {
        Task ConnectAsync();

        event Action<ShoppingListOpenedDto> OnShoppingListOpened;
    }
}
