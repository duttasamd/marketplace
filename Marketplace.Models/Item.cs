using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class Item
    {
        [Key]
        public Guid ItemID { get; set; }

        public string ItemName { get; set; }

        public Guid ItemTypeID { get; set; }

        public ItemType ItemType { get; set; }

        public double ItemPrice { get; set; }
    }
}
