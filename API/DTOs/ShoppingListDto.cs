using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ShoppingListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public ICollection<UsernameDto> Members { get; set; }

        public  ICollection<ItemDto> Items { get; set; }
    }
}