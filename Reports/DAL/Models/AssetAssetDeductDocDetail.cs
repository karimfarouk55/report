using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AssetAssetDeductDocDetail
    {
        public int DeductAssetDetailId { get; set; }
        public int? AssetDeductId { get; set; }
        public int? AssetId { get; set; }
        public int? AssetAccountId { get; set; }
        public int? CostCenterId { get; set; }
        public decimal? DeductValue { get; set; }
        public string Remarks { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }

        public virtual AssetAssetDeductDoc AssetDeduct { get; set; }
    }
}
