using APIRequests;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using APIRequests.SignalR.ShoppingList;
using Microsoft.Extensions.Logging;
using APIRequests.Accounts;

namespace WPF.HostBuilders
{
    public static class AddHubHostbuilderExtensions
    {
        public static IHostBuilder AddHub(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                var shoppingListHub = context.Configuration.GetValue<string>("ShoppingListHub");
                services.AddSingleton<IShoppingListHubService, ShoppingListHubService>(c => 
                    new ShoppingListHubService(shoppingListHub, c.GetRequiredService<IAccountStore>() , c.GetRequiredService<ILogger<ShoppingListHubService>>()));
            });

            return host;
        }
    }
}
