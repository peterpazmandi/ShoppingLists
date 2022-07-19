using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.bin.Data;
using API.Data.Repositories;
using API.Data.Repositories.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public IUserRepository UserRepository => new UserRepository(_context, _mapper);
        public IShoppingListRepository ShoppingListRepository => new ShoppingListRepository(_context);

        

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}