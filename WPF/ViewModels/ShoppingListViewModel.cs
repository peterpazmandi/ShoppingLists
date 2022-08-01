using APIRequests.Services.Item;
using APIRequests.ShoppingLists;
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

        public int ItemsCount => this.Items.Count;
        public int BoughtItems => Items.Count(i => i.Bought);


        public IShoppingListStore _shoppingListStore { get; set; }
        public ICommand OpenShoppingListCommand { get; set; }

        public IItemService ItemService { get; set; }



        public void OnItemsPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            this.IsEnabled = false;
            ItemViewModel item = (ItemViewModel)sender;
            item.Bought = !item.Bought;

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
