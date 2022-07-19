using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.bin.Data;
using API.Data.Repositories.Interfaces;
using API.DTOs;
using API.Entities;

namespace API.Data.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly DataContext _context;

        public ShoppingListRepository(DataContext context)
        {
            _context = context;
        }



        public async Task CreateAsync(ShoppingList shoppingList)
        {
            await _context.ShoppingLists.AddAsync(shoppingList);
        }
    }
}