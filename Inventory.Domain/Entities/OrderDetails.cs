using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

        public IList<Item> ITems { get; set; }

        public int Quantity { get; set; }

        public Guid OrderMasterId { get; set; }

        [ForeignKey("OrderMasterId")]
        public OrderMaster OrderMaster { get; set; }
    }
}
