using System;
using System.Collections.Generic;

namespace TravelRequestManagementAPI.Models
{
    public partial class TblRequestTable
    {
        public int RequestId { get; set; }
        public string CauseTravel { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Mode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? NoDays { get; set; }
        public string Priority { get; set; }
        public int? ProjectId { get; set; }
        public int? EmpId { get; set; }
        public string Status { get; set; }

        public virtual TblEmployeeRegistration Emp { get; set; }
        public virtual TblProject Project { get; set; }
    }
}
