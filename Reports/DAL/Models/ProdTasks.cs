using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProdTasks
    {
        public ProdTasks()
        {
            ProdJoinTaskEquipments = new HashSet<ProdJoinTaskEquipments>();
            ProdJoinTaskJob = new HashSet<ProdJoinTaskJob>();
            ProjProjItemEmpTaskJoin = new HashSet<ProjProjItemEmpTaskJoin>();
        }

        public int TaskId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName1 { get; set; }
        public string TaskName2 { get; set; }
        public string TaskDesc { get; set; }
        public string Remarks { get; set; }
        public string Comment { get; set; }
        public int? PurOrderId { get; set; }
        public byte? OperationType { get; set; }
        public decimal? Duration { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProdJoinTaskEquipments> ProdJoinTaskEquipments { get; set; }
        public virtual ICollection<ProdJoinTaskJob> ProdJoinTaskJob { get; set; }
        public virtual ICollection<ProjProjItemEmpTaskJoin> ProjProjItemEmpTaskJoin { get; set; }
    }
}
