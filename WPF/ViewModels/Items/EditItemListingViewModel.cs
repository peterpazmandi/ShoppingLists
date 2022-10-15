using APIRequests.DTOs;
using APIRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands.Items;

namespace WPF.ViewModels.Items
{
    public delegate void AddItemDelegate(ItemDto item);
    public delegate void RemoveItemdelegate(EditItemListingItemViewModel item);

    public sealed class EditItemListingViewModel: ViewModelBase
    {
        private event AddItemDelegate AddItemEvent;
        private event RemoveItemdelegate RemoveItemEvent;

        public AsyncObservableCollection<EditItemListingItemViewModel> _editItemListingItemViewModels;
        public IEnumerable<EditItemListingItemViewModel> EditItemListingItemViewModels => _editItemListingItemViewModels;




        public ICommand AddItemCommand { get; }



        public EditItemListingViewModel(IEnumerable<ItemDto> items)
        {
            AddItemEvent += AddItem;
            RemoveItemEvent += RemoveItem;

            AddItemCommand = new AddItemCommand(AddItemEvent);

            _editItemListingItemViewModels = new AsyncObservableCollection<EditItemListingItemViewModel>();

            foreach (var item in items)
            {
                AddItem(item);
            }
        }


        private void AddItem(ItemDto item)
        {
            _editItemListingItemViewModels.Add(new EditItemListingItemViewModel(RemoveItemEvent)
            {
                Id = item.Id,
                Name = item.Name,
                Qty = item.Qty,
                Unit = item.Unit
            });
        }

        private void RemoveItem(EditItemListingItemViewModel item)
        {
            _editItemListingItemViewModels.Remove(item);
        }

        public IEnumerable<ItemDto> ToItemDtoList()
        {
            List<ItemDto> items = new List<ItemDto>();

            foreach (var item in _editItemListingItemViewModels)
            {
                items.Add(new ItemDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Qty = item.Qty,
                    Unit = item.Unit,
                    Bought = false
                });
            }

            return items;
        }
    }
}
