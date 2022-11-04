using APIRequests.DTOs;
using APIRequests.Services;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using APIRequests.ShoppingLists;
using APIRequests.SignalR.ShoppingList;
using AutoMapper;
using Microsoft.Extensions.Logging;
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
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingListStore _shoppingListStore;
        private readonly ILogger<ShoppingListListingViewModel> _logger;

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
            IUnitOfWork unitOfWork,
            ShoppingListStore shoppingListStore,
            ILogger<ShoppingListListingViewModel> logger)
        {
            ErrorMessageViewModel = new();

            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _shoppingListStore = shoppingListStore;
            _logger = logger;

            ShoppingListListingViewModel = new ShoppingListListingViewModel(shoppingListStore, navigator, unitOfWork, logger);

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
