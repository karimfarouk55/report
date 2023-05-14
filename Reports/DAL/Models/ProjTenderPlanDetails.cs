using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderPlanDetails
    {
        public int TenderPlanDetailId { get; set; }
        public int? TenderPlanId { get; set; }
        public int? TenderItemId { get; set; }
        public int? ParentTenderItemId { get; set; }
        public string Description { get; set; }
        public DateTime? EstimateDeliverDate { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual ProjTenderPlan TenderPlan { get; set; }
    }
}
