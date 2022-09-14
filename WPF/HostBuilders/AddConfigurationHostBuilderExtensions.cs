using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.HostBuilders
{
    public static class AddConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
#if DEBUG
                c.AddJsonFile("appsettings.Development.json");
#else
                c.AddJsonFile("appsettings.json");
#endif

                c.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
