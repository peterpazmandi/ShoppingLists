using APIRequests.DTOs;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
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
        private readonly CreateEditShoppingListViewModel _createEditShoppingListViewModel;
        private readonly INavigator _navigator;
        private readonly IShoppingListService _shoppingListService;
        private readonly IMapper _mapper;


        public SaveShoppingListCommand(CreateEditShoppingListViewModel createEditShoppingListViewModel, INavigator navigator, IShoppingListService shoppingListService, IMapper mapper)
        {
            _navigator = navigator;
            _shoppingListService = shoppingListService;
            _createEditShoppingListViewModel = createEditShoppingListViewModel;
            _mapper = mapper;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigator.CurrentViewModel = _createEditShoppingListViewModel;

            var dto = _mapper.Map<UpdateShoppingListDto>(_createEditShoppingListViewModel.ShoppingListViewModel);
            await _shoppingListService.UpdateShoppingList(dto);
        }
    }
}
