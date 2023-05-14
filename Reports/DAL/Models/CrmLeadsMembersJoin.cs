using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class CrmLeadsMembersJoin
    {
        public int LeadMemberJoin { get; set; }
        public int? LeadMemberId { get; set; }
        public int? LeadId { get; set; }

        public virtual CrmLeads Lead { get; set; }
        public virtual CrmLeadsMembers LeadMember { get; set; }
    }
}
