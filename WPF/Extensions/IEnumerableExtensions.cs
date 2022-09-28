using APIRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extensions
{
    public static class IEnumerableExtensions
    {
        public static AsyncObservableCollection<T> ToAsyncObservableCollection<T>(this IEnumerable<T> list)
        {
            var toAsyncObservableCollection = new AsyncObservableCollection<T>();

            foreach (var item in list)
            {
                toAsyncObservableCollection.Add(item);
            }

            return toAsyncObservableCollection;
        }
    }
}
