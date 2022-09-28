using APIRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extensions
{
    public static class AsyncObservableCollectionExtensions
    {
        public static void AddList<T>(this ObservableCollection<T> list, IEnumerable<T> items)
        {
            App.Current.Dispatcher.Invoke((System.Action)delegate
            {
                foreach (var item in items)
                {
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            });
        }
    }
}
