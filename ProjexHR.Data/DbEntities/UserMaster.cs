using System;
using System.Collections.Generic;

namespace ProjexHR.Data.DbEntities
{
    public partial class UserMaster
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string UserRole { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public ulong UserStatus { get; set; }
        public ulong Suspended { get; set; }
        public DateTime? LastLoginDttm { get; set; }
        public DateTime? PasswordChangeDttm { get; set; }
        public int? FailedAttempts { get; set; }
        public DateTime? FailedAttemptDttm { get; set; }
        public ulong IsDelete { get; set; }
        public ulong IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
