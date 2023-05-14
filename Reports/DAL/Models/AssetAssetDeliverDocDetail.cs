using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AssetAssetDeliverDocDetail
    {
        public int DeliverAssetDetailId { get; set; }
        public int? DeliverAssetId { get; set; }
        public int? AssetId { get; set; }
        public int? EmpId { get; set; }
        public decimal? AddValue { get; set; }
        public string Remarks { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }

        public virtual AssetAssetDeliverDoc DeliverAsset { get; set; }
    }
}
