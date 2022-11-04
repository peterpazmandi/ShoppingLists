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
        public event Action<UpdateItemBoughtDto> OnItemBoughtStateChanged;

        private readonly string _shoppingListHub;
        private readonly IAccountStore _account;

        private HubConnection connection;

        public ShoppingListHubService(string shoppingListHub, IAccountStore account)
        {
            _shoppingListHub = shoppingListHub;
            _account = account;
        }

        public async Task ConnectAsync()
        {
            try
            {
                connection = new HubConnectionBuilder()
                    .WithUrl(_shoppingListHub + $"?user={_account.CurrentAccount.Username}")
                    .WithAutomaticReconnect()
                    .Build();

                connection.On<UpdateItemBoughtDto>("OnItemBoughtStateChanged", updateItemBoughtDto =>
                {
                    OnItemBoughtStateChanged?.Invoke(updateItemBoughtDto);
                });

                await connection.StartAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DisconnectAsync()
        {
            await connection.StopAsync();
        }

        public async Task SendUpdateItemBoughtChanged(int itemId, bool bought)
        {
            try
            {
                await connection.InvokeAsync("UpdateItemBoughtStateById", new UpdateItemBoughtDto() { ItemId = itemId, Bought = bought });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task ListenToItemBoughtStateChanges()
        {
            connection.On<UpdateItemBoughtDto>("ReceiveMessage", updateItemBoughtDto =>
            {

            });
        }
    }
}
