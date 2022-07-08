using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRequests
{
    public class ShoppingListsHttpClient
    {
        public readonly HttpClient _client;

        public ShoppingListsHttpClient(HttpClient client)
        {
            _client = client;
        }
    }
}