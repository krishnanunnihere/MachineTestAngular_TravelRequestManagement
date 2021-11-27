using System;
using System.Collections.Generic;

namespace TravelRequestManagementAPI.Models
{
    public partial class TblEmployeeRegistration
    {
        public TblEmployeeRegistration()
        {
            TblRequestTable = new HashSet<TblRequestTable>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string EmpAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int? UserId { get; set; }

        public virtual TblUser User { get; set; }
        public virtual ICollection<TblRequestTable> TblRequestTable { get; set; }
    }
}
