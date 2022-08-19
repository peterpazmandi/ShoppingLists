using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Extensions;

namespace WPF.ViewModels
{
    public delegate void UpdateItemBoughtStateDelegate(ItemViewModel item);

    public class ItemViewModel: ViewModelBase
    {
        public event UpdateItemBoughtStateDelegate UpdateItemBoughtState;

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

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private double _qty;
        public double Qty
        {
            get { return _qty; }
            set 
            { 
                _qty = value;
                OnPropertyChanged(nameof(Qty));
            }
        }

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set 
            { 
                _unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        private bool _bought;
        public bool Bought
        {
            get { return _bought; }
            set 
            { 
                _bought = value;
                if (UpdateItemBoughtState != null)
                {
                    UpdateItemBoughtState.Invoke(this); ;
                }
                OnPropertyChanged(nameof(Bought));
            }
        }

        public ItemViewModel()
        {

        }

        public ItemViewModel(ItemViewModel itemViewModel)
        {
            Id = itemViewModel.Id;
            Name = itemViewModel.Name;
            Qty = itemViewModel.Qty;
            Unit = itemViewModel.Unit;
            Bought = itemViewModel.Bought;
        }
    }
}
