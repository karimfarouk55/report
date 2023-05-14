using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class TaxesDto
    {
        public int TaxesId { get; set; }
        public int TaxStyle { get; set; }
        public string TaxCode { get; set; }
        public string TaxNameA { get; set; }
        public string TaxNameE { get; set; }
        public decimal TaxRate { get; set; }
        public bool IsAccomulative { get; set; }
        public bool PlusOrMinus { get; set; }
        
    }
}
