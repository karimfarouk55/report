using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class StockTranTypes
    {
        public int StockTranTypId { get; set; }
        public byte? TermType { get; set; }
        public int? BookId { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public byte? StockEffect { get; set; }
        public byte? CashEffect1 { get; set; }
        public int? TermId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
