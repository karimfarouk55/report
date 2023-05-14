using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SysRemotBranchesLog
    {
        public SysRemotBranchesLog()
        {
            SysRemoteBranchesLogDetaile = new HashSet<SysRemoteBranchesLogDetaile>();
        }

        public long LogId { get; set; }
        public string TableCode { get; set; }
        public int? TableEntityId { get; set; }
        public DateTime? LogTime { get; set; }
        public int? StoreId { get; set; }
        public byte? LogType { get; set; }
        public int? UserId { get; set; }
        public byte[] LogTimStamp { get; set; }
        public bool? RemotExecuted { get; set; }
        public bool? IsMasterFile { get; set; }

        public virtual ICollection<SysRemoteBranchesLogDetaile> SysRemoteBranchesLogDetaile { get; set; }
    }
}
