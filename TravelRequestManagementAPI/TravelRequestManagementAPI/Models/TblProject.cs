using System;
using System.Collections.Generic;

namespace TravelRequestManagementAPI.Models
{
    public partial class TblProject
    {
        public TblProject()
        {
            TblRequestTable = new HashSet<TblRequestTable>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<TblRequestTable> TblRequestTable { get; set; }
    }
}
