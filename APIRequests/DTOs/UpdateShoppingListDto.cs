using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.DTOs
{
    public class UpdateShoppingListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<UsernameDto> Members { get; set; }

        public ICollection<ItemDto> Items { get; set; }
    }
}
