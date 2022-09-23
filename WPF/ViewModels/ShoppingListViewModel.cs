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
    public class ShoppingListViewModel : ViewModelBase
    {
        #region properties

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

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

        private DateTime dateTime;
        public DateTime Created
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged(nameof(Created));
            }
        }

        private DateTime _modified;
        public DateTime Modified
        {
            get { return _modified; }
            set
            {
                _modified = value;
                OnPropertyChanged(nameof(Modified));
            }
        }

        private ObservableCollection<UserViewModel> _members = new ObservableCollection<UserViewModel>();
        public ObservableCollection<UserViewModel> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        private ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
        public ObservableCollection<ItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value.OrderItemsByBought();
                OnPropertyChanged(nameof(Items));
            }
        }

        public ItemViewModel this[int index] => this.Items[index];

        public int ItemsCount => this.Items.Count;
        public int BoughtItems => Items.Count(i => i.Bought);


        public IShoppingListStore _shoppingListStore { get; set; }
        public IItemService ItemService { get; set; }


        #endregion properties

        #region commands

        public ICommand OpenShoppingListCommand { get; set; }
        public ICommand CreateEditShoppingListCommand { get; set; }

        #endregion commands

        #region ctor
        public ShoppingListViewModel()
        {

        }

        public ShoppingListViewModel(ShoppingListViewModel shoppingListViewModel, INavigator navigator, IMemberService memberService, IShoppingListService shoppingListService, IMapper mapper)
        {
            this.PopulateVariables(shoppingListViewModel, navigator, memberService, shoppingListService, mapper);
        }

        #endregion ctor

        private void PopulateVariables(ShoppingListViewModel shoppingListViewModel, INavigator navigator, IMemberService memberService, IShoppingListService shoppingListService, IMapper mapper)
        {
            Id = shoppingListViewModel.Id;
            Title = shoppingListViewModel.Title;
            Created = shoppingListViewModel.Created;
            Modified = shoppingListViewModel.Modified;
            Members = new ObservableCollection<UserViewModel>();
            foreach (var member in shoppingListViewModel.Members)
            {
                Members.Add(new UserViewModel(member));
            }
            Items = new ObservableCollection<ItemViewModel>();
            foreach (var item in shoppingListViewModel.Items)
            {
                var _item = new ItemViewModel(item);
                _item.UpdateItemBoughtState += this.UpdateItemBoughtStateById;
                Items.Add(_item);
            }

            CreateEditShoppingListCommand = new CreateEditShoppingListCommand(this, navigator, memberService, shoppingListService, mapper);

            ItemService = shoppingListViewModel.ItemService;
        }

        public void UpdateItemBoughtStateById(ItemViewModel item)
        {
            this.IsEnabled = false;

            Task.Run(async () =>
            {
                if ((await ItemService.UpdateItemBoughtStateById<MessageViewModel>(item.Id, item.Bought)) != null)
                {
                    App.Current.Dispatcher.Invoke((System.Action)delegate
                    {
                        OnPropertyChanged(nameof(BoughtItems));
                        _items = _items.OrderItemsByBought();
                    });
                }
                else
                {
                    item.Bought = !item.Bought;
                }
                this.IsEnabled = true;
            });
        }
    }
}
