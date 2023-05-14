using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TrOpenningBalanceDetails
    {
        public int OpeningBalanceDetailsId { get; set; }
        public int? TrOpenningBalanceId { get; set; }
        public int? AccountId { get; set; }
        public int? LineNumber { get; set; }
        public decimal? Creditor { get; set; }
        public decimal? Debitor { get; set; }

        public virtual TrOpenningBalance TrOpenningBalance { get; set; }
    }
}
