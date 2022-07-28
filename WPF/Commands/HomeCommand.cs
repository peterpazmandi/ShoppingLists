using APIRequests.Exceptions;
using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Authenticator;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class HomeCommand : AsyncCommandBase
    {
        private readonly IRenavigator _renavigator;

        public HomeCommand(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _renavigator.Renavigate();
        }
    }
}
