using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class AccountsDetailAccountEntity
    {
        public int Id { get; set; }
        public string DetailAccountCode { get; set; }
        public string DetailAccountName { get; set; }
        public int HeadAccountId { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
