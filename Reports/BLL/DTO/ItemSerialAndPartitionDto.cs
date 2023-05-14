using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ItemSerialAndPartitionDto
    {
        public int ItemSerialId { get; set; }
        public string SRNo1 { get; set; }
        public string Color { get; set; }
        public decimal Height { get; set; }
        public string PartCode { get; set; }
        public string PartDescA { get; set; }
        public string PartDescE { get; set; }
        public int StorePartId { get; set; }
        public decimal QtyInNotebook { get; set; }
        public decimal CoastAverage { get; set; }
        public decimal ReservedQty { get; set; }

    }
}
