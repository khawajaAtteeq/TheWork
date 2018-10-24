using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountsVoucherTypeEntity
    {
        public int Id { get; set; }
        public string VoucherTypeCode { get; set; }
        public string VoucherTypeName { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
