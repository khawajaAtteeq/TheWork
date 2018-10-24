using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InventoryItemGroupEntity
    {
        public int Id { get; set; }
        public string ItemGroupCode { get; set; }
        public string ItemGroupName { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
