using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class CrmLeadTypes
    {
        public CrmLeadTypes()
        {
            CrmLeads = new HashSet<CrmLeads>();
        }

        public int LeadTypeId { get; set; }
        public string LeadTypeCode { get; set; }
        public string LeadTypeName1 { get; set; }
        public string LeadTypeName2 { get; set; }
        public string LeadTypeDes { get; set; }
        public string CreayedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<CrmLeads> CrmLeads { get; set; }
    }
}
