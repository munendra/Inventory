using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item ITem { get; set; }

        public Guid ItemId { get; set; }

        public int Quantity { get; set; }

        public Guid OrderMasterId { get; set; }

        [ForeignKey("OrderMasterId")]
        public  OrderMaster OrderMaster { get; set; }
    }
}
