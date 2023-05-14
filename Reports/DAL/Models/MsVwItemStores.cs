using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsVwItemStores
    {
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public int StoreId { get; set; }
        public int ItemCardId { get; set; }
    }
}
