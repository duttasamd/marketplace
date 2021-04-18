using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class ItemType
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ItemSubType> ItemSubTypes { get; set; }
    }
}
