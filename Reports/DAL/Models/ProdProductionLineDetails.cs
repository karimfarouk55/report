using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProdProductionLineDetails
    {
        public int ProdLineDetailId { get; set; }
        public int? ProLineId { get; set; }
        public int? TaskId { get; set; }
        public decimal? TimeBeforFormat { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? Minutes { get; set; }
        public decimal? Hours { get; set; }
        public decimal? Days { get; set; }
        public decimal? Months { get; set; }
        public string Remarks { get; set; }

        public virtual ProdProductionLine ProLine { get; set; }
    }
}
