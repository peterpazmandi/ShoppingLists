using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Repositories.Interfaces;

namespace API.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IShoppingListRepository ShoppingListRepository { get; }
        

        Task<bool> CompleteAsync();
        bool HasChanges();
    }
}