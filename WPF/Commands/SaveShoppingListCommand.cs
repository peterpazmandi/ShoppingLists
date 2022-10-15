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
    public class SaveShoppingListCommand : AsyncCommandBase
    {
        private readonly EditShoppingListViewModel _editShoppingListViewModel;
        private readonly ShoppingListStore _shoppingListStore;
        private readonly IUnitOfWork _unitOfWork;

        public SaveShoppingListCommand(EditShoppingListViewModel editShoppingListViewModel, ShoppingListStore shoppingListStore, IUnitOfWork unitOfWork)
        {
            _editShoppingListViewModel = editShoppingListViewModel;
            _shoppingListStore = shoppingListStore;
            _unitOfWork = unitOfWork;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var shoppingList = _editShoppingListViewModel.ShoppingListDtoFactory();
        }
    }
}
