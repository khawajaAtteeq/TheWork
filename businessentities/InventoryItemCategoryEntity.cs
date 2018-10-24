using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InventoryItemCategoryEntity
    {
        public int Id { get; set; }
        public string ItemCategoryCode { get; set; }
        public string ItemCategoryName { get; set; }
        public int ItemGroupID { get; set; }
        public int? PurchaseAccountID { get; set; }
        public int? SaleAccountID { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
