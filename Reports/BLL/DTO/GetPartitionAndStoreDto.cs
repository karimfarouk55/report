using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class GetPartitionAndStoreDto
    {
        public string PartCode { get; set; }
        public string PartDescA { get; set; }
        public string PartDescE { get; set; }
        public int StorePartId { get; set; }
        public decimal QtyInNotebook { get; set; }
        public decimal CoastAverage { get; set; }
        public decimal ReservedQty { get; set; }

        public int StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
    }
}
