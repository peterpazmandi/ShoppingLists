﻿using APIRequests.DTOs;
using APIRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.ShoppingLists
{
    public class ShoppingListStore : IShoppingListStore
    {
        private AsyncObservableCollection<ShoppingListDto> _shoppingLists = new AsyncObservableCollection<ShoppingListDto>();
        public AsyncObservableCollection<ShoppingListDto> ShoppingLists
        {
            get
            {
                return _shoppingLists;
            }
            set 
            { 
                _shoppingLists = value;
                StateChanged?.Invoke();
            }
        }

        private ShoppingListDto _selectedShoppingList;
        public ShoppingListDto SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set 
            { 
                _selectedShoppingList = value;
                StateChanged?.Invoke();
            }
        }


        public event Action StateChanged;
    }
}
