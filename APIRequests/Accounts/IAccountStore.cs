using APIRequests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIRequests.Accounts
{
    public interface IAccountStore
    {
        User CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
