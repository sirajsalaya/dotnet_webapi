using System;
using System.Collections.Generic;

namespace ProjexHR.Data.DbEntities
{
    public partial class ShiftMaster
    {
        public int ShiftId { get; set; }
        public string ShiftCd { get; set; }
        public string ShiftName { get; set; }
        public ulong IsDelete { get; set; }
        public ulong IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
