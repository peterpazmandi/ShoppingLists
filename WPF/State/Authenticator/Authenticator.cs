using APIRequests.Accounts;
using APIRequests.Models;
using APIRequests.Services.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Authenticator;

namespace SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAccountService _accountService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAccountService accountService, IAccountStore accountStore)
        {
            _accountService = accountService;
            _accountStore = accountStore;
        }

        public User CurrentUser
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action StateChanged;

        public async Task Login(string username, string password)
        {
            CurrentUser = await _accountService.Login(username, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task Register(string email, string username, string password)
        {
            CurrentUser = await _accountService.Register(email, username, password);
        }
    }
}
