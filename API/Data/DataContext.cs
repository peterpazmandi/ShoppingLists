using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.bin.Data
{
    public class DataContext: IdentityDbContext<AppUser,
                                IdentityRole<int>,
                                int,
                                IdentityUserClaim<int>,
                                IdentityUserRole<int>,
                                IdentityUserLogin<int>,
                                IdentityRoleClaim<int>,
                                IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options): base(options)
        {
            
        }
    }
}