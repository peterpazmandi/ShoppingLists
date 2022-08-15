using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class CreateEditShoppingListViewModel : ViewModelBase
    {
        public ShoppingListViewModel ShoppingListViewModel { get; set; }

        public CreateEditShoppingListViewModel(ShoppingListViewModel? shoppingListViewModel = null)
        {
            ShoppingListViewModel = shoppingListViewModel ?? new ShoppingListViewModel();
        }
    }
}
