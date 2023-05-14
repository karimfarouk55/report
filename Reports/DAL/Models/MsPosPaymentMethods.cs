using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsPosPaymentMethods
    {
        public int PayMethodId { get; set; }
        public decimal? AddPercent { get; set; }
        public byte[] MethodImage { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public bool? MandatoryFieldData { get; set; }
        public string UserQuestion { get; set; }
    }
}
