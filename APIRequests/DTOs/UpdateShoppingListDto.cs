using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.DTOs
{
    public record struct UpdateShoppingListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<UsernameDto> Members { get; set; }

        public IEnumerable<ItemDto> Items { get; set; }
    }
}
