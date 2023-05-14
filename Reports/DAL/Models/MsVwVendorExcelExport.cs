﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsVwVendorExcelExport
    {
        public string VendorCode { get; set; }
        public string VendorDescA { get; set; }
        public string VendorDescE { get; set; }
        public bool? IsActive { get; set; }
        public int? CreditPeriod { get; set; }
        public decimal? CreditLimit { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public string CatCode { get; set; }
        public string CatDescA { get; set; }
    }
}
