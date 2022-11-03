using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SignalR.Tracker
{
    public class ShoppingListOpeningTracker
    {
        private static readonly ConcurrentDictionary<string, int> OpenedShoppingListsByUsers = new();

        public bool OnShoppingListOpened(string username, int shoppingListId)
        {
            lock (OpenedShoppingListsByUsers)
            {
                if (!OpenedShoppingListsByUsers.Contains(new KeyValuePair<string, int>(username, shoppingListId)))
                {
                    var added = OpenedShoppingListsByUsers.TryAdd(username, shoppingListId);

                    return added;
                }
            }

            return false;
        }
    }
}