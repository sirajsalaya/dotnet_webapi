using System;
using System.Collections.Generic;

namespace ProjexHR.Data.DbEntities
{
    public partial class DesignationMaster
    {
        public int DesignationId { get; set; }
        public string DesignationCd { get; set; }
        public string DesignationName { get; set; }
        public ulong IsDelete { get; set; }
        public ulong IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
