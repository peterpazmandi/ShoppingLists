using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.bin.Data;
using API.Data.Repositories.Interfaces;
using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ShoppingList?> GetByIdAsync(int id)
        {
            return await _context.ShoppingLists
                .Include(s => s.Items.OrderBy(i => i.Bought))
                .Include(s => s.Members)
                .Where(s => s.Id == id)
                .OrderByDescending(s => s.Modified)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ShoppingList>> GetByUsernameAsync(string username)
        {
            return await _context.ShoppingLists
                .Include(s => s.Items.OrderBy(i => i.Bought))
                .Include(s => s.Members)
                .Where(s => s.Members.Where(m => m.UserName.Equals(username)).Count() > 0)
                .OrderByDescending(s => s.Modified)
                .ToListAsync();
        }
    }
}