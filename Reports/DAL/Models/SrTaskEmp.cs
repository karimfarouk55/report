﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SrTaskEmp
    {
        public int TskTech { get; set; }
        public int? TaskId { get; set; }
        public int? EmpId { get; set; }
        public string EmpRole { get; set; }

        public virtual HrEmployees Emp { get; set; }
        public virtual SrTasks Task { get; set; }
    }
}
