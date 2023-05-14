using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class RPTQuantityAndPlacesOfItemsDTO : ParametersDTO
    {
        public int? StoreId { get; set; }
        public string ItemCode { get; set; }
        public string PartitionCode { get; set; }
        public int? fromQtyPart { get; set; }
        public int? toQtyPart { get; set; }
        public int? fromQtyNote { get; set; }
        public int? toQtyNote { get; set; }
        public string ItemCatCode { get; set; }
        public string LotNumberExpiry { get; set; }
    }
}