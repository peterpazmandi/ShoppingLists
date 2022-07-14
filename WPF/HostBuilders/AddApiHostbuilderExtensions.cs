using APIRequests;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WPF.HostBuilders
{
    public static class AddApiHostbuilderExtensions
    {
        public static IHostBuilder AddApi(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                var baseApiUrl = context.Configuration.GetValue<string>("BaseApiUrl");
                services.AddHttpClient<ShoppingListsHttpClient>(c =>
                {
                    c.BaseAddress = new Uri(context.Configuration.GetValue<string>("BaseApiUrl"));
                });
            });

            return host;
        }
    }
}
