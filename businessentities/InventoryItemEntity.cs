using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InventoryItemEntity
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double? PackQuantity { get; set; }
        public decimal? UnitPurchasePrice { get; set; }
        public decimal? UnitSalePrice { get; set; }
        public bool? IsVat { get; set; }
        public double?  StockMaxLevel { get; set; }
        public double? StoctNormalLevel { get; set; }
        public double? StockMinLevel { get; set; }
        public string ItemImagePath { get; set; }
        public int ItemUnitId { get; set; }
        public int ItemGroupId { get; set; }
        public int ItemCategoryId { get; set; }
        public bool? IsActive { get; set; }
    }
}
