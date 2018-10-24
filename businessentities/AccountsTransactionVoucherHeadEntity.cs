using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountsTransactionVoucherHeadEntity
    {
        public int Id { get; set; }
        public int VoucherTypeId { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherMethod { get; set; }
        public int? ReferenceAccountId { get; set; }
        public string VoucherRemarks { get; set; }
        public string VoucherStatus { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? CheckedUserId { get; set; }
        public DateTime? CheckedDate { get; set; }
        public int? PostedUserId { get; set; }
        public DateTime? PostedDate { get; set; }
    }
}
