using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO
{
    public class CreateCustomerDto
    {
        public int CustomerId { get; set; }
        public int SalPrice { get; set; }

        public decimal TotalAccount { get; set; }
        public int Size_No { get; set; }
        public int Page_No { get; set; }
        public string CustomerDescA { get; set; }
        public string CustomerDescE { get; set; }
        public string Tel { get; set; }
        public string CustomerCode { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object data { get; set; }
    }
}
