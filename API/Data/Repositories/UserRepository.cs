using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.bin.Data;
using API.Data.Repositories.Interfaces;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetUsersByUsernamesAsync(IEnumerable<string> usernames)
        {
            return await _context.Users
                .Where(x => usernames.Contains(x.UserName))
                .ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetUsersByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName.ToLower().Contains(username.ToLower()))
                .ToListAsync();
        }
    }
}