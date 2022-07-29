using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;

namespace WPF.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> OrderItemsByBought<T>(this ObservableCollection<T> list) where T: ItemViewModel
        {
            ObservableCollection<T> orderedList = new ObservableCollection<T>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (!list[i].Bought)
                {
                    orderedList.Add(list[i]);
                }
            }
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].Bought)
                {
                    orderedList.Add(list[i]);
                }
            }

            list.Clear();
            foreach (var item in orderedList)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
