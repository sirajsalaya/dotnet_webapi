using System;
using System.Collections.Generic;

namespace ProjexHR.Data.DbEntities
{
    public partial class WageMaster
    {
        public int WageId { get; set; }
        public string WageCd { get; set; }
        public string WageName { get; set; }
        public ulong IsDelete { get; set; }
        public ulong IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
