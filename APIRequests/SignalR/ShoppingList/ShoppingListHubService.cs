using APIRequests.Accounts;
using APIRequests.SignalR.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.SignalR.ShoppingList
{
    public sealed class ShoppingListHubService : IShoppingListHubService
    {
        public event Action<ShoppingListOpenedDto> OnShoppingListOpened;

        private readonly IAccountStore _account;
        private readonly ILogger _logger;

        private readonly HubConnection connection;

        public ShoppingListHubService(string shoppingListHub, IAccountStore account, ILogger logger)
        {
            _account = account;
            _logger = logger;

            connection = new HubConnectionBuilder()
                .WithUrl(shoppingListHub)
                .WithAutomaticReconnect()
                .Build();

            connection.Reconnecting += (sender) =>
            {
                return Task.CompletedTask;
            };

            connection.Reconnected += (sender) =>
            {
                return Task.CompletedTask;
            };

            connection.Closed += (sender) =>
            {
                return Task.CompletedTask;
            };

            connection.On<string, string>("OpenedShoppingList", (message, openedShoppingList) =>
            {
                _logger.LogInformation(message);
            });

            Task.Run(async () =>
            {
                await connection.StartAsync();
                await ConnectAsync();
            });
        }

        public async Task ConnectAsync()
        {
            try
            {
                await connection.InvokeAsync("ShoppingListOpened", _account.CurrentAccount.Username, 2);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }
    }
}
