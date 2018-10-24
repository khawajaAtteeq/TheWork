using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InventoryItemUnitEntity
    {
        public int Id { get; set; }
        public string ItemUnitCode { get; set; }
        public string ItemUnitName { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
