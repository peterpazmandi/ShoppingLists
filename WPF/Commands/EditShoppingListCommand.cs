using APIRequests.DTOs;
using APIRequests.Services;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using APIRequests.ShoppingLists;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Extensions;
using WPF.State.Navigators;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class EditShoppingListCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingListStore _shoppingListStore;

        public EditShoppingListCommand(ShoppingListStore shoppingListStore, INavigator navigator, IUnitOfWork unitOfWork)
        {
            _shoppingListStore = shoppingListStore;
            _navigator = navigator;
            _unitOfWork = unitOfWork;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var editShoppingListViewModel = new EditShoppingListViewModel(_shoppingListStore, _navigator, _unitOfWork);
            _navigator.CurrentViewModel = editShoppingListViewModel;
        }
    }
}
