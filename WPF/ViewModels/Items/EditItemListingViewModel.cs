using APIRequests.DTOs;
using APIRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels.Items
{
    public delegate void RemoveItemdelegate(EditItemListingItemViewModel item);

    public sealed class EditItemListingViewModel: ViewModelBase
    {
        private event RemoveItemdelegate RemoveItemEvent;

        public AsyncObservableCollection<EditItemListingItemViewModel> _editItemListingItemViewModels;
        public IEnumerable<EditItemListingItemViewModel> EditItemListingItemViewModels => _editItemListingItemViewModels;


        public EditItemListingViewModel(IEnumerable<ItemDto> items)
        {
            RemoveItemEvent += RemoveItem;

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
    }
}
