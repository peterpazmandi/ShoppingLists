using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CreateShoppingListDto
    {
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public IEnumerable<string> Members { get; set; }
        public IEnumerable<CreateItemDto> Items { get; set; }
    }
}