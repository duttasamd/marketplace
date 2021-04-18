using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ItemSubTypeID { get; set; }

        public ItemSubType ItemSubType { get; set; }

        public double ItemPrice { get; set; }
    }
}
