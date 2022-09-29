using APIRequests.DTOs;
using APIRequests.Helpers;
using APIRequests.Services.ShoppingList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.ShoppingLists
{
    public interface IShoppingListStore
    {
        IShoppingListService ShoppingListService { get; set; }
        IEnumerable<ShoppingListDto> ShoppingLists { get; set; }
        ShoppingListDto SelectedShoppingList { get; set; }
    }
}
