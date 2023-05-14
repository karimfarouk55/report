using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderContractDetail
    {
        public int TenderContractDetailId { get; set; }
        public int? TenderContractId { get; set; }
        public int? TenderOfferDetailId { get; set; }
        public int? TenderItemId { get; set; }
        public int? ParentTenderItemId { get; set; }
        public string Description { get; set; }
        public int? BasUnitId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public byte? ItemStatus { get; set; }
        public string ItemStatusDesc { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual ProjTenderContract TenderContract { get; set; }
    }
}
