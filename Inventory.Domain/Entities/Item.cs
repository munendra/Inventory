using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
      
        public double Price { get; set; }
    }
}
