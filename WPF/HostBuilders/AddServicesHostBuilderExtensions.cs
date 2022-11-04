using APIRequests;
using APIRequests.Accounts;
using APIRequests.Services;
using APIRequests.Services.Account;
using APIRequests.Services.Item;
using APIRequests.Services.Member;
using APIRequests.Services.ShoppingList;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Helpers;

namespace WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                var shoppingListHub = context.Configuration.GetValue<string>("ShoppingListHub");

                services.AddSingleton<IUnitOfWork, UnitOfWork>(s =>
                    new UnitOfWork(
                        s.GetRequiredService<ShoppingListsHttpClient>(),
                        s.GetRequiredService<IAccountStore>(),
                        shoppingListHub));

                services.AddSingleton<IMemberService, MemberService>();
                services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            });

            return host;
        }
    }
}
