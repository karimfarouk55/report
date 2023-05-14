using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderPlanDistributionDetails
    {
        public int TenderPlanJoinId { get; set; }
        public int? TenderPlanDistId { get; set; }
        public int? TenderPlanDetailId { get; set; }
        public int? TenderDetailId { get; set; }
        public int? BasUnitId { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? EstimateDeliverDate { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual ProjTenderPlanDistribution TenderPlanDist { get; set; }
    }
}
