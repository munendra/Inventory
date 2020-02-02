using System;

namespace Inventory.Dto
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
      
        public double Price { get; set; }

    }
}
