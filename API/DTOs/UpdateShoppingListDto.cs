using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UpdateShoppingListDto
    {        
        public int Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<string> MembersUsername { get; set; }
        public IEnumerable<UpdateItemDto> Items { get; set; }
    }
}