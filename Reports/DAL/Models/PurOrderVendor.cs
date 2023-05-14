﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class PurOrderVendor
    {
        public int? StorId { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public decimal? NetPrice { get; set; }
        public string VendorCode { get; set; }
        public string VendorDescA { get; set; }
        public string DocTrNo { get; set; }
        public string ManualTrNo { get; set; }
        public int PurOrderId { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public byte? TermType { get; set; }
        public int? TermId { get; set; }
        public int? BookId { get; set; }
        public bool? Executed { get; set; }
    }
}
