using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Commands;
using WPF.State.Navigators;

namespace WPF.ViewModels
{
    public class CreateEditShoppingListViewModel : ViewModelBase
    {
        public ShoppingListViewModel ShoppingListViewModel { get; set; }
        public FindMembersViewModel FindMembers { get; set; }


        #region commands

        public ICommand SaveShoppingListCommand { get; set; }

        #endregion commands

        public CreateEditShoppingListViewModel(IMemberService memberService, IShoppingListService shoppingListService, INavigator navigator, IMapper mapper, ShoppingListViewModel? shoppingListViewModel = null)
        {
            this.FindMembers = new FindMembersViewModel(memberService);
            this.FindMembers.AddMemberCommand = new AddMemberCommand(this);
            this.FindMembers.RemoveMemberCommand = new RemoveMemberCommand(this);
            ShoppingListViewModel = shoppingListViewModel ?? new ShoppingListViewModel();

            SaveShoppingListCommand = new SaveShoppingListCommand(this, navigator, shoppingListService, mapper);
        }
    }
}
