using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.SignalR.Models
{
    public record struct UpdateItemBoughtDto
    {
        public int ItemId { get; set; }
        public bool Bought { get; set; }
    }
}
