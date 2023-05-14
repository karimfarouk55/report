using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class CodLandRetainResJoin
    {
        public int LandRetainResJoinId { get; set; }
        public int? LandId { get; set; }
        public int? LandRetainResId { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual CodLands Land { get; set; }
        public virtual CodLandRetainRsons LandRetainRes { get; set; }
    }
}
