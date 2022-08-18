using APIRequests.Services.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF.Commands;

namespace WPF.ViewModels
{
    public class CreateEditShoppingListViewModel : ViewModelBase
    {
        public ShoppingListViewModel ShoppingListViewModel { get; set; }
        public FindMembersViewModel FindMembers { get; set; }

        public CreateEditShoppingListViewModel(IMemberService memberService, ShoppingListViewModel? shoppingListViewModel = null)
        {
            this.FindMembers = new FindMembersViewModel(memberService);
            this.FindMembers.AddMemberCommand = new AddMemberCommand(this);
            ShoppingListViewModel = shoppingListViewModel ?? new ShoppingListViewModel();
        }
    }
}
