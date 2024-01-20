using System;
using System.Collections.Generic;

namespace Dotnet.Data
{
    public partial class WageMaster
    {
        public int WageId { get; set; }
        public string WageCd { get; set; } = null!;
        public string WageName { get; set; } = null!;
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
