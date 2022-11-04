using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public record struct UpdateItemBoughtDto
    {
        public int ItemId { get; set; }
        public bool Bought { get; set; }
    }
}