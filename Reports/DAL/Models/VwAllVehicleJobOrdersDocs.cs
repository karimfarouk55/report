using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class VwAllVehicleJobOrdersDocs
    {
        public int VjorderId { get; set; }
        public string DocTrNo { get; set; }
        public string DocType { get; set; }
        public string DocTypeName1 { get; set; }
        public string DocTypeName2 { get; set; }
        public DateTime? TrDate { get; set; }
        public string ManualTrNo { get; set; }
        public string DocRemarks { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public bool? DefualtCurrency { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal? DocValue { get; set; }
    }
}
