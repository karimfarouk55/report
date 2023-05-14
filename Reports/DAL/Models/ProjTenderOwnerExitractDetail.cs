using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderOwnerExitractDetail
    {
        public int OwnerExitractDetailId { get; set; }
        public int? OwnerExitractId { get; set; }
        public int? TenderPlanDetailId { get; set; }
        public int? TenderDetailId { get; set; }
        public int? TenderItemId { get; set; }
        public int? ParentTenderItemId { get; set; }
        public int? BasUnitId { get; set; }
        public decimal? PrevQuantity { get; set; }
        public decimal? ContractQuantity { get; set; }
        public decimal? CurrentQty { get; set; }
        public decimal? Price { get; set; }
        public decimal? PreviousRais { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? WorkValue { get; set; }
        public decimal? CurrentValue { get; set; }
        public decimal? RaisValue { get; set; }
        public decimal? RaisPercent { get; set; }
        public decimal? PrevReturn { get; set; }
        public decimal? RaisBeforPrevReturn { get; set; }
        public decimal? TenderCat { get; set; }
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

        public virtual ProjTenderOwnerExitract OwnerExitract { get; set; }
    }
}
