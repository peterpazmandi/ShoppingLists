using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.DTOs
{
    public class ShoppingListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public ICollection<UsernameDto> Members { get; set; }

        public ICollection<ItemDto> Items { get; set; }

        public int ItemsCount => this.Items.Count;
        public int BoughtItems => this.Items.Count(x => x.Bought);
    }
}
