using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderExecutionExitractDetail
    {
        public int ExecutExitractDetailId { get; set; }
        public int? ExecutExitractId { get; set; }
        public int? TenderPlanDetailId { get; set; }
        public int? TenderDetailId { get; set; }
        public int? TenderItemId { get; set; }
        public int? ParentTenderItemId { get; set; }
        public int? BasUnitId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? PrevQuantity { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? TenderCat { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? TotalSubItem { get; set; }
        public decimal? CurrentQty { get; set; }
        public decimal? WorkPercent { get; set; }
        public decimal? ProfitPercent { get; set; }
        public decimal? ProfitValue { get; set; }
        public decimal? TenderItemPrice { get; set; }
        public decimal? TotalProfit { get; set; }
        public decimal? TenderTotalPrice { get; set; }
        public decimal? DistQty { get; set; }
        public decimal? TotalSubDist { get; set; }
        public decimal? TotalPriceDist { get; set; }
        public DateTime? EstimateDeliverDate { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual ProjTenderExecutionExitract ExecutExitract { get; set; }
    }
}
