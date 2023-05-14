using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class WorkForcTemplatesDetails
    {
        public int WftempDetailId { get; set; }
        public int WftempId { get; set; }
        public int? WfpassPortId { get; set; }

        public virtual WorkForcTemplates Wftemp { get; set; }
    }
}
