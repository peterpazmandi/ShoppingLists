using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class ItemViewModel: ViewModelBase
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
    }
}
