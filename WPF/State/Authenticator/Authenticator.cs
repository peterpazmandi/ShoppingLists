using APIRequests.Accounts;
using APIRequests.Models;
using APIRequests.Services;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountStore _accountStore;

        public Authenticator(IUnitOfWork unitOfWork, IAccountStore accountStore)
        {
            _unitOfWork = unitOfWork;
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
            CurrentUser = await _unitOfWork.AccountService.Login(username, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task Register(string email, string username, string password)
        {
            CurrentUser = await _unitOfWork.AccountService.Register(email, username, password);
        }
    }
}
