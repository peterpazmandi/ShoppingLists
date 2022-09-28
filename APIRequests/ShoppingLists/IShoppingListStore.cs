using APIRequests.DTOs;
using APIRequests.Helpers;
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
        AsyncObservableCollection<ShoppingListDto> ShoppingLists { get; set; }
        ShoppingListDto SelectedShoppingList { get; set; }
        public event Action StateChanged;
    }
}
