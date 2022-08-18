using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetUsersByUsernamesAsync(IEnumerable<string> usernames);
        Task<IEnumerable<AppUser>> GetUsersByUsernameAsync(string usernames);
    }
}