using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InventoryTransactionPurchaseHeadEntity
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseNo { get; set; }
        public int VendorId { get; set; }
        public string Remarks { get; set; }
        public decimal? PurchaseTotalAmount { get; set; }
        public int? PurchaseOrderId { get; set; }
        public string PurchaseStatus { get; set; }
        public int? EntryUserId { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? CheckedUserId { get; set; }
        public DateTime? CheckedDate { get; set; }
        public int? PostedUserId { get; set; }
        public DateTime? PostedDate { get; set; }
    }
}
