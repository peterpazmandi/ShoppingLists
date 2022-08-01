using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UpdateItemBoughtDto
    {
        public int ItemId { get; set; }
        public bool Bought { get; set; }
    }
}