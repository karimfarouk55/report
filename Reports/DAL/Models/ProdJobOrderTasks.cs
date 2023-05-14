using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProdJobOrderTasks
    {
        public int JobTaskId { get; set; }
        public int? JobOrderId { get; set; }
        public int? TaskId { get; set; }
        public int? BillOfMaterialId { get; set; }
        public decimal? TimeBeforFormat { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? Minutes { get; set; }
        public decimal? Hours { get; set; }
        public decimal? Days { get; set; }
        public decimal? Months { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ProdJobOrder JobOrder { get; set; }
    }
}
