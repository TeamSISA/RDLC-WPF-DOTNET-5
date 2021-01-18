using System;
using System.Collections.Generic;

#nullable disable

namespace RDLC.EFCore.Models.DB
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short ModelYear { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
