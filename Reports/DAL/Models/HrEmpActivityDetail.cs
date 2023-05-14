using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class HrEmpActivityDetail
    {
        public HrEmpActivityDetail()
        {
            HrActivityDetailElements = new HashSet<HrActivityDetailElements>();
        }

        public int EmpActivityDetailId { get; set; }
        public int? EmpActivityId { get; set; }
        public int? EmpId { get; set; }

        public virtual HrEmpActivity EmpActivity { get; set; }
        public virtual ICollection<HrActivityDetailElements> HrActivityDetailElements { get; set; }
    }
}
