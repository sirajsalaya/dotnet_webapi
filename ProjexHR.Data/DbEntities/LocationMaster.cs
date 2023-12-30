using System;
using System.Collections.Generic;

namespace ProjexHR.Data.DbEntities
{
    public partial class LocationMaster
    {
        public int LocationId { get; set; }
        public string LocationCd { get; set; }
        public string LocationName { get; set; }
        public ulong IsDelete { get; set; }
        public ulong IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
