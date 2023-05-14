using System;
using System.Collections.Generic;
using System.Text;

namespace Static.VM
{
    public class VendorVM
    {
        public int ItemCardId { get; set; }
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Price2 { get; set; }
        public decimal? Price3 { get; set; }
        public decimal? CoastAVG { get; set; }
        public object Vendors { get; set; }
        public string image { get; set; }
    }
}
