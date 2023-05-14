using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsStores
    {
        public MsStores()
        {
            CalJurnalEntry = new HashSet<CalJurnalEntry>();
            MsPartition = new HashSet<MsPartition>();
        }

        public int StoreId { get; set; }
        public int? UserId { get; set; }
        public int? UserGroupId { get; set; }
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public bool? StoreType { get; set; }
        public string StorePosition { get; set; }
        public string StoreKeeper { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Remarks { get; set; }
        public string PrintHeaderFont { get; set; }
        public string PrintFooterFont { get; set; }
        public string PrintHeaderFontColor { get; set; }
        public string PrintFooterFontColor { get; set; }
        public byte? PrintHeaderFontSize { get; set; }
        public byte? PrintFooterFontSize { get; set; }
        public byte? PrintHeaderFontStyle { get; set; }
        public byte? PrintFooterFontStyle { get; set; }
        public int? BoxId { get; set; }
        public int? CityId { get; set; }
        public byte[] BranchLogo { get; set; }
        public string PrintHeader { get; set; }
        public string PrintFooter { get; set; }
        public string EtaxCode { get; set; }
        public string TaxReg { get; set; }
        public string CommercialName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual MsBoxBank Box { get; set; }
        public virtual ICollection<CalJurnalEntry> CalJurnalEntry { get; set; }
        public virtual ICollection<MsPartition> MsPartition { get; set; }
    }
}
