﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ItemID { get; set; }

        public Item Item { get; set; }

        public double Price { get; set; }

        public Guid OrderID { get; set; }

        public Order Order { get; set; }

        public DateTime? DispatchDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
