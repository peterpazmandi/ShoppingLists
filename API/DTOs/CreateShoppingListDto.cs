using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CreateShoppingListDto
    {
        public string Title { get; set; }

        public IEnumerable<string> MembersUsername { get; set; }
        public IEnumerable<CreateItemDto> Items { get; set; }
    }
}