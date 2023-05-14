using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProjTenderContractorExitractAdds
    {
        public int ContractorExitractAddId { get; set; }
        public int? ContractorExitractId { get; set; }
        public int? AccountId { get; set; }
        public string HelpAccType { get; set; }
        public bool? Accomulative { get; set; }
        public decimal? PreviousValue { get; set; }
        public decimal? AddPercent { get; set; }
        public decimal? AddValu { get; set; }
        public decimal? TotalValue { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual ProjTenderContractorExitract ContractorExitract { get; set; }
    }
}
