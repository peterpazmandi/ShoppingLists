using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.DTOs
{
    public record MemberDto(string Username)
    {
        public override string ToString()
        {
            return Username;
        }
    }
}
