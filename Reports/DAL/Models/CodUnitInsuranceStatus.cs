﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class CodUnitInsuranceStatus
    {
        public CodUnitInsuranceStatus()
        {
            ProjProjInsuranceUnit = new HashSet<ProjProjInsuranceUnit>();
        }

        public int UnitInsurstatId { get; set; }
        public int Code { get; set; }
        public string DescA { get; set; }
        public string DescE { get; set; }
        public int? Aid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }

        public virtual ICollection<ProjProjInsuranceUnit> ProjProjInsuranceUnit { get; set; }
    }
}
