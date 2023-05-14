using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AssetAssetMoveDocDetail
    {
        public int AssetMovDetailId { get; set; }
        public int? AssetMovId { get; set; }
        public int? AssetId { get; set; }
        public int? OldStoreId { get; set; }
        public int? NewStoreId { get; set; }
        public int? OldDepartMentId { get; set; }
        public int? NewDepartMentId { get; set; }
        public decimal? MoveCost { get; set; }

        public virtual AssetAssetMoveDoc AssetMov { get; set; }
    }
}
