using APIRequests.DTOs;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using APIRequests.ShoppingLists;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Commands;
using WPF.Extensions;
using WPF.State.Navigators;

namespace WPF.ViewModels
{
    public class ShoppingListListingItemViewModel : ViewModelBase
    {
        public ShoppingListDto ShoppingList { get; set; }

        #region commands

        public ICommand OpenShoppingListCommand { get; set; }
        public ICommand CreateEditShoppingListCommand { get; set; }

        #endregion commands

        #region ctor
        public ShoppingListListingItemViewModel(ShoppingListDto shoppingList, ShoppingListStore shoppingListStore)
        {
            ShoppingList = shoppingList;
        }

        #endregion ctor


    }
}
