using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AssetAssetReceiveDocDetail
    {
        public int ReceiveAssetDetailId { get; set; }
        public int? ReceiveAssetId { get; set; }
        public int? AssetId { get; set; }
        public int? EmpId { get; set; }
        public decimal? AddValue { get; set; }
        public string Remarks { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }

        public virtual AssetAssetReceiveDoc ReceiveAsset { get; set; }
    }
}
