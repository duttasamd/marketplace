using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketplace.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public Boolean IsFulfilled { get; set; }

        public DateTime? FulfilledDate { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
