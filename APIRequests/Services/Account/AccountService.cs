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
        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
