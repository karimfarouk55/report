using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsVwItemBatchStores
    {
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public int StoreId { get; set; }
        public int ItemCardId { get; set; }
        public int ItemAtrribBatchId { get; set; }
    }
}
