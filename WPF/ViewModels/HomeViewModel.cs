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
            IMapper mapper)
        {
            _shoppingListService = shoppingListService;
            _navigator = navigator;

            Task.Run(async () =>
            {
                await GetMyShoppingLists();
            });

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            _mapper = mapper;
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
                        listItem.PropertyChanged += shoppingList.OnItemsPropertyChanged;
                    }
                    shoppingList.OpenShoppingListCommand = new OpenShoppingListCommand(shoppingList, _navigator);
                    this.ShoppingLists.Add(shoppingList);
                }
            });
        }
    }
}
