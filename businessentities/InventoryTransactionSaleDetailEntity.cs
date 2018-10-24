using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InventoryTransactionSaleDetailEntity
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ItemId { get; set; }
        public int ItemUnitId { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public double? VatPercentage { get; set; }
        public decimal? Vat { get; set; }
        public double? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal SaleAmount { get; set; }
        public string Comments { get; set; }
    }
}
