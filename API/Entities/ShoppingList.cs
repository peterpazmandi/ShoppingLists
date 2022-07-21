using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [JsonIgnore]
        public virtual List<AppUser> Members { get; set; }

        [JsonIgnore]
        public virtual List<Item> Items { get; set; }
    }
}