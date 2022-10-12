using APIRequests.DTOs;
using APIRequests.Services;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using WPF.State.Navigators;
using WPF.ViewModels.Items;

namespace WPF.ViewModels
{
    public sealed class ViewShoppingListViewModel: ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IUnitOfWork _unitOfWork;

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

        public ICommand EditShoppingListCommand { get; set; }


        public ViewShoppingListViewModel(ShoppingListStore shoppingListStore, INavigator navigator, IUnitOfWork unitOfWork)
        {
            _navigator = navigator;
            _unitOfWork = unitOfWork;
            ShoppingList = shoppingListStore.SelectedShoppingList;

            ItemListingViewModel = new ItemListingViewModel(shoppingListStore, unitOfWork);

            EditShoppingListCommand = new EditShoppingListCommand(shoppingListStore, navigator, unitOfWork);
        }
    }
}
