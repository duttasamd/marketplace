using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public Boolean IsFulfilled { get; set; }

        public DateTime? FulfilledDate { get; set; }

        public string CustomerUserName { get; set; }
        
        public ICollection<SubOrder> SubOrders { get; set; }
    }
}
