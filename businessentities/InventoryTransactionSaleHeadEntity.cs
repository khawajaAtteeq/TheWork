using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InventoryTransactionSaleHeadEntity
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string SaleNo { get; set; }
        public int CustomerId { get; set; }
        public string Remarks { get; set; }
        public decimal? SaleTotalAmount { get; set; }
        public int? SaleOrderId { get; set; }
        public string SaleStatus { get; set; }
        public int? EntryUserId { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? CheckedUserId { get; set; }
        public DateTime? CheckedDate { get; set; }
        public int? PostedUserId { get; set; }
        public DateTime? PostedDate { get; set; }
    }
}
