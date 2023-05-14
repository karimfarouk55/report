using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class WorkForcProblems
    {
        public int WorkForcProbId { get; set; }
        public int WfpassPortId { get; set; }
        public string Complaint { get; set; }
        public string ComplaintType { get; set; }
    }
}
