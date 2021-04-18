using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class ItemSubType
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ItemTypeId { get; set; }

        public ItemType ItemType { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
