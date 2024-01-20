using System;
using System.Collections.Generic;

namespace Dotnet.Data
{
    public partial class UserMaster
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? UserRole { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public bool? UserStatus { get; set; }
        public bool? Suspended { get; set; }
        public DateTime? LastLoginDttm { get; set; }
        public DateTime? PasswordChangeDttm { get; set; }
        public int? FailedAttempts { get; set; }
        public DateTime? FailedAttemptDttm { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
