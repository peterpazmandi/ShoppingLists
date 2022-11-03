using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SignalR.Model
{
    public record struct ShoppingListOpenedDto
    {
        public string Username { get; set; }
        public int ShoppingListId { get; set; }
    }
}