using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountsTransactionVoucherDetailEntity
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public int AccountId { get; set; }
        public string Comments { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string CheckTitle { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime? chequeDate { get; set; }
        public bool? IsDebit { get; set; }
        public bool? IsCredit { get; set; }
    }
}
