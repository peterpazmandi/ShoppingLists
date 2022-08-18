using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;

namespace WPF.Commands
{
    public sealed class AddMemberCommand : AsyncCommandBase
    {
        public readonly CreateEditShoppingListViewModel _createEditShoppingListViewModel;

        public AddMemberCommand(CreateEditShoppingListViewModel createEditShoppingListViewModel)
        {
            _createEditShoppingListViewModel = createEditShoppingListViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_createEditShoppingListViewModel.ShoppingListViewModel.Members.FirstOrDefault(
                x => x.Username.ToLower().Equals(_createEditShoppingListViewModel.FindMembers.SelectedMember.ToLower())) is null)
            {
                _createEditShoppingListViewModel.ShoppingListViewModel.Members.Add(
                    new UserViewModel() 
                    { 
                        Username = _createEditShoppingListViewModel.FindMembers.SelectedMember 
                    });
            }
        }
    }
}
