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
        private readonly RemoveMemberDelegate _removeMember;

        public RemoveMemberCommand(RemoveMemberDelegate removeMember)
        {
            _removeMember = removeMember;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var member = new UsernameDto()
            {
                Username = (string)parameter
            };

            _removeMember?.Invoke(member);
        }
    }
}
