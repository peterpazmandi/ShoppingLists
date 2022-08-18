using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services.Member
{
    public interface IMemberService
    {
        Task<IEnumerable<UsernameDto>> FindMembersByUsername(string username);
    }
}
