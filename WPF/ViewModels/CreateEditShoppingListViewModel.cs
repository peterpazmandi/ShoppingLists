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
        public FindMembersViewModel FindMembers { get; set; }

        public CreateEditShoppingListViewModel(ShoppingListViewModel? shoppingListViewModel = null)
        {
            this.FindMembers = new FindMembersViewModel();
            ShoppingListViewModel = shoppingListViewModel ?? new ShoppingListViewModel();
        }
    }
}
