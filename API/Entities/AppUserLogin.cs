using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUserLogin: IdentityUserLogin<int>
    {
        [Key]
        public int Id { get; set; }
    }
}