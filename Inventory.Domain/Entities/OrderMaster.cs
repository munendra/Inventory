using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain.Entities
{
    public class OrderMaster
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime OrderAt { get; set; }

        public string OrderBy { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
