using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using APIRequests.ShoppingLists;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Commands;
using WPF.State.Authenticator;
using WPF.State.Navigators;
using WPF.ViewModels.Factories;

namespace WPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly IItemService _itemService;
        public IMemberService _memberService;
        private readonly INavigator _navigator;
        private readonly IMapper _mapper;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;


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


        public ICommand UpdateCurrentViewModelCommand { get; }

        public HomeViewModel(
            IShoppingListService shoppingListService,
            INavigator navigator,
            IViewModelFactory viewModelFactory,
            IMapper mapper,
            IItemService itemService,
            IMemberService memberService)
        {
            _shoppingListService = shoppingListService;
            _navigator = navigator;

            Task.Run(async () =>
            {
                await GetMyShoppingLists();
            });

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            _mapper = mapper;
            _itemService = itemService;
            _memberService = memberService;
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private async Task GetMyShoppingLists()
        {
            var lists = await _shoppingListService.GetMyShoppingLists();

            App.Current.Dispatcher.Invoke((System.Action)delegate
            {
                foreach (var item in lists)
                {
                    var shoppingList = _mapper.Map<ShoppingListViewModel>(item);
                    foreach (var listItem in shoppingList.Items)
                    {
                        listItem.UpdateItemBoughtState += shoppingList.UpdateItemBoughtStateById;
                    }
                    shoppingList.ItemService = _itemService;
                    shoppingList.OpenShoppingListCommand = new OpenShoppingListCommand(shoppingList, _navigator);
                    shoppingList.CreateEditShoppingListCommand = new CreateEditShoppingListCommand(shoppingList, _navigator, _memberService);
                    this.ShoppingLists.Add(shoppingList);
                }
            });
        }
    }
}
