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
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task UpdateItemBoughtStateById(int itemId, bool bought)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
            item.Bought = bought;
        }
    }
}