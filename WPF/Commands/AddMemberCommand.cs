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
        private readonly AddMemberDelegate _addMember;

        public AddMemberCommand(AddMemberDelegate AddMember)
        {
            _addMember = AddMember;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _addMember?.Invoke(new UsernameDto() { Username = (string)parameter});
        }
    }
}
