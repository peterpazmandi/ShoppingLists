using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;
using System.Diagnostics;

namespace WPF.Commands
{
    public sealed class RemoveMemberCommand : AsyncCommandBase
    {
        public readonly CreateEditShoppingListViewModel _createEditShoppingListViewModel;

        public RemoveMemberCommand(CreateEditShoppingListViewModel createEditShoppingListViewModel)
        {
            _createEditShoppingListViewModel = createEditShoppingListViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is string)
            {
                this.RemoveMember(parameter as string);
            }
        }

        private void RemoveMember(string username)
        {
            _createEditShoppingListViewModel.ShoppingListViewModel.Members.Remove(
                    _createEditShoppingListViewModel.ShoppingListViewModel.Members.Where(x => x.Username.Equals(username)).Single());
        }
    }
}
