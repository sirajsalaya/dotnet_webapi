using System;
using System.Collections.Generic;

namespace ProjexHR.Data
{
    public partial class DesignationMaster
    {
        public int DesignationId { get; set; }
        public string DesignationCd { get; set; } = null!;
        public string DesignationName { get; set; } = null!;
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
