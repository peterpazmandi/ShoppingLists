using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}