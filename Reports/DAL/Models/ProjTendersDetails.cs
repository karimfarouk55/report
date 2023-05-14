using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTendersDetails
    {
        public int TenderDetailId { get; set; }
        public int? TenderId { get; set; }
        public int? TenderItemId { get; set; }
        public int? ParentTenderItemId { get; set; }
        public string Description { get; set; }
        public int? BasUnitId { get; set; }
        public decimal? Quantity { get; set; }
        public byte? ItemStatus { get; set; }
        public string ItemStatusDesc { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual ProjTenders Tender { get; set; }
    }
}
