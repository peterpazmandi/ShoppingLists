using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Data.Repositories.Interfaces
{
    public interface IShoppingListRepository
    {
        Task CreateAsync(ShoppingList shoppingList);
        Task<ShoppingList?> GetByIdAsync(int id);
        Task<List<ShoppingList>> GetByUsernameAsync(string username);
    }
}