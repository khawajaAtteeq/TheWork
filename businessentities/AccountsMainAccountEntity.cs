using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountsMainAccountEntity
    {
        public int Id { get; set; }
        public string MainAccountCode { get; set; }
        public string MainAccountName { get; set; }
        public string AccountClass { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
