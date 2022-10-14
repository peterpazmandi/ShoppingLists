using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Items;

namespace WPF.Commands.Items
{
    public sealed class AddItemCommand : AsyncCommandBase
    {
        private AddItemDelegate _addItemEvent;

        public AddItemCommand(AddItemDelegate addItemEvent)
        {
            _addItemEvent = addItemEvent;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _addItemEvent?.Invoke(new ItemDto());
        }
    }
}
