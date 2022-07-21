using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services.ShoppingList
{
    public interface IShoppingListService
    {
        Task<List<ShoppingListDto>> GetMyShoppingLists();
    }
}
