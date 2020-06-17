using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class ItemType
    {
        [Key]
        public Guid ItemTypeID { get; set; }

        public string ItemTypeName { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
