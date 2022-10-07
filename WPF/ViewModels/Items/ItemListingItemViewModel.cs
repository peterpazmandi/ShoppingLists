using APIRequests.DTOs;
using APIRequests.Services;
using APIRequests.ShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels.Items
{
    public delegate void ReorderItemsOrderByBoughtDelegate();

    public sealed class ItemListingItemViewModel: ViewModelBase
    {
        public event ReorderItemsOrderByBoughtDelegate ReorderItemsOrderByBoughtDelegate;


        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _qty;
        public double Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private bool _bought;
        public bool Bought
        {
            get { return _bought; }
            set
            {
                _bought = value;

                Task.Run(async () =>
                {
                    bool result = await shoppingListStore.UpdateItemBoughtState(Id, value);
                    if (!result)
                    {
                        // Notify the user about the successfull save
                        _bought = !value;
                    }

                    ReorderItemsOrderByBoughtDelegate?.Invoke();
                });
                OnPropertyChanged(nameof(Bought));
            }
        }


        private readonly ShoppingListStore shoppingListStore;
        private readonly IUnitOfWork _unitOfWork;

        public ItemListingItemViewModel(ShoppingListStore shoppingListStore, IUnitOfWork unitOfWork)
        {
            this.shoppingListStore = shoppingListStore;
            _unitOfWork = unitOfWork;
        }
    }
}
