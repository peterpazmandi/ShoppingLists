using APIRequests.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WPF.State.Accounts;

namespace SimpleTrader.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private User _currentAccount;
        public User CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

    }
}
