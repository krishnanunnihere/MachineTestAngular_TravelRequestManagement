using System;
using System.Collections.Generic;

namespace TravelRequestManagementAPI.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblEmployeeRegistration = new HashSet<TblEmployeeRegistration>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? RoleId { get; set; }

        public virtual TblRole Role { get; set; }
        public virtual ICollection<TblEmployeeRegistration> TblEmployeeRegistration { get; set; }
    }
}
