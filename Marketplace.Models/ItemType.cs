using System;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class ItemType
    {
        public Guid ItemTypeID { get; set; }

        public String ItemTypeName { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
