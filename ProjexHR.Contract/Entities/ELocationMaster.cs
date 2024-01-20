using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjexHR.Contract
{
    public class ELocationMaster
    {
        public int LocationId { get; set; }
        public string LocationCd { get; set; }
        public string LocationName { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}