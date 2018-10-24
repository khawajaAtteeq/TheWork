using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountsHeadAccountEntity
    {
        public int Id { get; set; }
        public string HeadAccountCode { get; set; }
        public string HeadAccountName { get; set; }
        public int GroupAccountId { get; set; }
        public int? BalanceSheetNoteId { get; set; }
        public int? ProfitLoseNoteId { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
