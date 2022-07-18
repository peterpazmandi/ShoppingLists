using APIRequests.DTOs;
using APIRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly ShoppingListsHttpClient _client;

        public AccountService(ShoppingListsHttpClient client)
        {
            _client = client;
        }

        public async Task<User> Register(string email, string username, string password)
        {
            return await _client.PostAsync<User>(
                "Account/Register",
                new RegisterDto
                {
                    Email = email,
                    Username = username,
                    Password = password
                });
        }

        public async Task<User> Login(string username, string password)
        {
            return await _client.PostAsync<User>(
                "Account/login", 
                new LoginDto 
                { 
                    Username = username, 
                    Password = password 
                });
        }
    }
}
