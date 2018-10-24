using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class CompanyEntity
    {
        public int Id { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyFullName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
