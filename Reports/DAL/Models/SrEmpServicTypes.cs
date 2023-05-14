using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SrEmpServicTypes
    {
        public int SrId { get; set; }
        public int? EmpId { get; set; }
        public int? SrTypId { get; set; }

        public virtual HrEmployees Emp { get; set; }
        public virtual SrServiceTypes SrTyp { get; set; }
    }
}
