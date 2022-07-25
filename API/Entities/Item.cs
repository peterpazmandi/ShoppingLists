using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double Qty { get; set; }
        public string Unit { get; set; } = "";

        public bool Bought { get; set; } = false;

        public int ShoppingListId { get; set; }

        public ShoppingList ShoppingList { get; set; }
    }
}