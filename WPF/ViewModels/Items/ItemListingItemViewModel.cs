using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels.Items
{
    public sealed class ItemListingItemViewModel: ViewModelBase
    {
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
            set { _bought = value; }
        }
    }
}
