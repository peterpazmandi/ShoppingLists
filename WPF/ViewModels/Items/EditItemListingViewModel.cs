using APIRequests.DTOs;
using APIRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels.Items
{
    public sealed class EditItemListingViewModel: ViewModelBase
    {
        public AsyncObservableCollection<EditItemListingItemViewModel> _editItemListingItemViewModels;
        public IEnumerable<EditItemListingItemViewModel> EditItemListingItemViewModels => _editItemListingItemViewModels;


        public EditItemListingViewModel(IEnumerable<ItemDto> items)
        {
            _editItemListingItemViewModels = new AsyncObservableCollection<EditItemListingItemViewModel>();

            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        private void AddItem(ItemDto item)
        {
            _editItemListingItemViewModels.Add(new EditItemListingItemViewModel()
            {
                Name = item.Name,
                Qty = item.Qty,
                Unit = item.Unit
            });
        }
    }
}
