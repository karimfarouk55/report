using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderOwnerExitractDiscounts
    {
        public int OwnerExitractDiscId { get; set; }
        public int? OwnerExitractId { get; set; }
        public int? AccountId { get; set; }
        public string HelpAccType { get; set; }
        public bool? Accomulative { get; set; }
        public decimal? PreviousValue { get; set; }
        public decimal? DiscPercent { get; set; }
        public decimal? DiscValu { get; set; }
        public decimal? AccomulativeValue { get; set; }
        public decimal? AccomulativePercent { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual ProjTenderOwnerExitract OwnerExitract { get; set; }
    }
}
