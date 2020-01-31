using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

    }
}
