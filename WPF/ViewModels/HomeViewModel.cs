using APIRequests.Services.ShoppingList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly IMapper _mapper;



        private ObservableCollection<ShoppingListViewModel> _shoppingLists = new ObservableCollection<ShoppingListViewModel>();
        public ObservableCollection<ShoppingListViewModel> ShoppingLists
        {
            get { return _shoppingLists; }
            set 
            {
                _shoppingLists = value;
                OnPropertyChanged(nameof(ShoppingLists));
            }
        }


        public HomeViewModel(IShoppingListService shoppingListService, IMapper mapper)
        {
            _shoppingListService = shoppingListService;

            Task.Run(async () =>
            {
                await GetMyShoppingLists();
            });
            _mapper = mapper;
        }

        private async Task GetMyShoppingLists()
        {
            var lists = await _shoppingListService.GetMyShoppingLists();

            foreach (var item in lists)
            {
                var shoppingList = _mapper.Map<ShoppingListViewModel>(item);
                this.ShoppingLists.Add(shoppingList);
            }
        }
    }
}
