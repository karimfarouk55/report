using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class WorkForcTestResultsDetails
    {
        public int TestResultDetailId { get; set; }
        public int? TestResultId { get; set; }
        public int? WftempId { get; set; }
        public int? WfpassPortId { get; set; }
        public string Remarks { get; set; }
        public bool? Succeeded { get; set; }
        public decimal? Grad { get; set; }

        public virtual WorkForcTestResults TestResult { get; set; }
    }
}
