using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AccountsProfitLoseNoteEntity
    {
        public int Id { get; set; }
        public int ProfitLoseNoteNumber { get; set; }
        public string ProfitLoseNoteName { get; set; }
        public bool? IsActive { get; set; }
    }
}
