using APIRequests.DTOs;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;
using WPF.ViewModels.Items;

namespace WPF.ViewModels
{
    public sealed class ViewShoppingListViewModel: ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IMemberService _memberService;

        public ShoppingListDto ShoppingList { get; set; }
        public ItemListingViewModel ItemListingViewModel { get; }

        private StringBuilder _members;
        public string Members
        { 
            get
            {
                _members = new StringBuilder();
                for (int i = 0; i < ShoppingList.Members.Count(); i++)
                {
                    if (i != ShoppingList.Members.Count()-1)
                    {
                        _members.Append($"{ShoppingList.Members.ElementAt(i).Username}, ");
                    }
                    else
                    {
                        _members.Append($"{ShoppingList.Members.ElementAt(i).Username}");
                    }
                }

                return _members.ToString();
            }
        }

        public ViewShoppingListViewModel(ShoppingListStore shoppingListStore, INavigator navigator, IMemberService memberService, IItemService itemService)
        {
            _navigator = navigator;
            _memberService = memberService;

            ShoppingList = shoppingListStore.SelectedShoppingList;

            ItemListingViewModel = new ItemListingViewModel(shoppingListStore, itemService);
        }
    }
}
