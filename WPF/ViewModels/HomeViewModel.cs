using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using APIRequests.ShoppingLists;
using AutoMapper;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Commands;
using WPF.Helpers;
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

        public double BottomMenuHorizontalPosition => _navigator.CurrentWindowHeight - 100;


        private AsyncObservableCollection<ShoppingListViewModel> _shoppingLists = new AsyncObservableCollection<ShoppingListViewModel>();
        public AsyncObservableCollection<ShoppingListViewModel> ShoppingLists
        {
            get { return _shoppingLists; }
            set 
            {
                _shoppingLists = value;
                OnPropertyChanged(nameof(ShoppingLists));
            }
        }

        private ShoppingListViewModel _selectedShoppingList;

        public ShoppingListViewModel SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set 
            {
                _selectedShoppingList = value;
                OnPropertyChanged(nameof(SelectedShoppingList));
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

            _navigator.StateChanged += Navigator_StateChanged;
        }


        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(BottomMenuHorizontalPosition));
        }





        private async Task GetMyShoppingLists()
        {
            var lists = await _shoppingListService.GetMyShoppingLists();

            foreach (var item in lists)
            {
                var shoppingList = _mapper.Map<ShoppingListViewModel>(item);
                foreach (var listItem in shoppingList.Items)
                {
                    listItem.UpdateItemBoughtState += shoppingList.UpdateItemBoughtStateById;
                }
                shoppingList.ItemService = _itemService;
                shoppingList.OpenShoppingListCommand = new OpenShoppingListCommand(shoppingList, _navigator, _memberService, _shoppingListService, _mapper);
                this.ShoppingLists.Add(shoppingList);
            }
        }
    }
}
