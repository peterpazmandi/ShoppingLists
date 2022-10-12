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
        public readonly EditShoppingListViewModel _createEditShoppingListViewModel;

        public AddMemberCommand(EditShoppingListViewModel createEditShoppingListViewModel)
        {
            _createEditShoppingListViewModel = createEditShoppingListViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {

        }
    }
}
