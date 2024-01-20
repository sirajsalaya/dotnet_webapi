using System;
using System.Collections.Generic;

namespace ProjexHR.Data
{
    public partial class ShiftMaster
    {
        public int ShiftId { get; set; }
        public string ShiftCd { get; set; } = null!;
        public string ShiftName { get; set; } = null!;
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
