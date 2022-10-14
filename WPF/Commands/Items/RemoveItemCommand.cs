using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Items;

namespace WPF.Commands.Items
{
    public sealed class RemoveItemCommand : AsyncCommandBase
    {
        private RemoveItemdelegate _removeItemEvent;

        public RemoveItemCommand(RemoveItemdelegate removeItemEvent)
        {
            _removeItemEvent = removeItemEvent;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is EditItemListingItemViewModel)
            {
                _removeItemEvent?.Invoke((EditItemListingItemViewModel)parameter);
            }
        }
    }
}
