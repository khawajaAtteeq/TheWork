using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BrandEntity
    {
        public string BrandCode { get; set; }

        public int CompanyId { get; set; }
        
        public string ProductGroupCode { get; set; }

        public string ProductSubGroupCode { get; set; }

        public string BrandName { get; set; }

        public string BrandDescription { get; set; }

        public bool Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
