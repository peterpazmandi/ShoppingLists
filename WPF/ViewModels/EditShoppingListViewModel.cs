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
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Commands;
using WPF.State.Navigators;
using WPF.ViewModels.Members;

namespace WPF.ViewModels
{
    public delegate void AddMemberDelegate(UsernameDto member);
    public delegate void RemoveMemberDelegate(UsernameDto member);

    public class EditShoppingListViewModel : ViewModelBase
    {
        public event AddMemberDelegate AddMember;


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


        public FindMembersViewModel FindMembersViewModel { get; set; }
        public EditMemberListingViewModel EditMemberListingViewModel { get; set; }


        private readonly ShoppingListStore _shoppingListStore;
        private readonly INavigator _navigator;
        private readonly IUnitOfWork _unitOfWork;



        #region commands

        public ICommand SaveShoppingListCommand { get; set; }

        #endregion commands



        public EditShoppingListViewModel(ShoppingListStore shoppingListStore, INavigator navigator, IUnitOfWork unitOfWork)
        {
            _shoppingListStore = shoppingListStore;
            _navigator = navigator;
            _unitOfWork = unitOfWork;

            PopulateFormFields();
        }

        private void PopulateFormFields()
        {
            Id = _shoppingListStore.SelectedShoppingList.Id;
            Title = _shoppingListStore.SelectedShoppingList.Title;

            EditMemberListingViewModel = new EditMemberListingViewModel(_shoppingListStore.SelectedShoppingList.Members);

            AddMember += EditMemberListingViewModel.AddMember;
            FindMembersViewModel = new FindMembersViewModel(_unitOfWork, AddMember);
        }
    }
}
