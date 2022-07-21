using APIRequests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIRequests.Accounts
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
