﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsVendorTypes
    {
        public MsVendorTypes()
        {
            MsVendor = new HashSet<MsVendor>();
        }

        public int VendorTypeId { get; set; }
        public string VendorTypeCode { get; set; }
        public string VendorTypeDescA { get; set; }
        public string VendorTypeDescE { get; set; }
        public int? VendorTypeParent { get; set; }
        public int? VendorTypeLevel { get; set; }
        public byte? VendorTypeLevelType { get; set; }
        public int? CurrentTrNo { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsVendor> MsVendor { get; set; }
    }
}
