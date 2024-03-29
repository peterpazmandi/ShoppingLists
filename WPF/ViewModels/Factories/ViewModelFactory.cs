﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;

namespace WPF.ViewModels.Factories
{
    public class ViewModelFactory: IViewModelFactory
    {
        private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<ShoppingListViewModel> _createShoppingListViewModel;


        public ViewModelFactory(
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<RegisterViewModel> createRegisterViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<ShoppingListViewModel> createShoppingListViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createRegisterViewModel = createRegisterViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createShoppingListViewModel = createShoppingListViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Register:
                    return _createRegisterViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.ShoppingList:
                    return _createShoppingListViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
