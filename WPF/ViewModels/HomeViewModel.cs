using APIRequests.DTOs;
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
        private readonly IItemService _itemService;
        public IMemberService _memberService;
        private readonly INavigator _navigator;
        private readonly IMapper _mapper;

        public ShoppingListListingViewModel ShoppingListListingViewModel { get; }

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


        public ICommand GetShoppingListsCommand { get; init; }
        public ICommand UpdateCurrentViewModelCommand { get; }


        public HomeViewModel(
            INavigator navigator,
            IViewModelFactory viewModelFactory,
            IMapper mapper,
            IItemService itemService,
            IMemberService memberService,
            ShoppingListStore shoppingListStore)
        {
            ErrorMessageViewModel = new();

            _navigator = navigator;
            _mapper = mapper;
            _itemService = itemService;
            _memberService = memberService;

            ShoppingListListingViewModel = new ShoppingListListingViewModel(shoppingListStore, navigator, memberService, itemService);

            GetShoppingListsCommand = new GetShoppingListsCommand(this, shoppingListStore);
            GetShoppingListsCommand.Execute(null);

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);

            _navigator.StateChanged += Navigator_StateChanged;
        }


        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(BottomMenuHorizontalPosition));
        }
    }
}
