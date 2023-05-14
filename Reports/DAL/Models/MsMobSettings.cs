using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsMobSettings
    {
        public int MobSetId { get; set; }
        public int? UserId { get; set; }
        public byte? TermType { get; set; }
        public int? StoreId { get; set; }
        public int? BookId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
