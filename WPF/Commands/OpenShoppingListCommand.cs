﻿using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class OpenShoppingListCommand : AsyncCommandBase
    {
        private readonly ShoppingListViewModel _shoppingListViewModel;
        private readonly INavigator _navigator;
        private readonly IMemberService _memberService;
        private readonly IShoppingListService _shoppingListService;
        private readonly IMapper _mapper;

        public OpenShoppingListCommand(ShoppingListViewModel shoppingListViewModel, INavigator navigator, IMemberService memberService, IShoppingListService shoppingListService, IMapper mapper)
        {
            _shoppingListViewModel = shoppingListViewModel;
            _navigator = navigator;
            _memberService = memberService;
            _shoppingListService = shoppingListService;
            _mapper = mapper;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigator.CurrentViewModel = new ShoppingListViewModel(_shoppingListViewModel, _navigator, _memberService, _shoppingListService, _mapper);
        }
    }
}
