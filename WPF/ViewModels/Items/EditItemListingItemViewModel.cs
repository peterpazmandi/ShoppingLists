using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands.Items;

namespace WPF.ViewModels.Items
{
    public sealed class EditItemListingItemViewModel: ViewModelBase
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
            set 
            { 
                _name = value;
            }
        }
        
        private double _qty;
        public double Qty
        {
            get { return _qty; }
            set 
            {
                _qty = value;
            }
        }

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
            }
        }


        public ICommand RemoveItemCommand { get; set; }


        public EditItemListingItemViewModel(RemoveItemdelegate removeItemEvent)
        {
            RemoveItemCommand = new RemoveItemCommand(removeItemEvent);
        }
    }
}
