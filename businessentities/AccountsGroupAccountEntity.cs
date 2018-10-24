using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountsGroupAccountEntity
    {
        public int Id { get; set; }
        public string GroupAccountCode { get; set; }
        public string GroupAccountName { get; set; }
        public int MainAccountId { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive
        {
            get; set;
        }
    }
}
