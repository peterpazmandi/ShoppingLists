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
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Commands;
using WPF.State.Navigators;
using WPF.ViewModels.Members;

namespace WPF.ViewModels
{
    public class EditShoppingListViewModel : ViewModelBase
    {
        private int Id;

        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }



        private readonly ShoppingListStore _shoppingListStore;
        private readonly INavigator _navigator;
        private readonly IUnitOfWork _unitOfWork;

        public FindMembersViewModel FindMembersViewModel { get; set; }





        #region commands

        public ICommand SaveShoppingListCommand { get; set; }

        #endregion commands

        public EditShoppingListViewModel(ShoppingListStore shoppingListStore, INavigator navigator, IUnitOfWork unitOfWork)
        {
            _shoppingListStore = shoppingListStore;
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            FindMembersViewModel = new(unitOfWork);

            PopulateFormFields();
        }

        private void PopulateFormFields()
        {
            Id = _shoppingListStore.SelectedShoppingList.Id;
            Title = _shoppingListStore.SelectedShoppingList.Title;

        }
    }
}
