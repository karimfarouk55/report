using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class Rpt_CustomerSalesInvoiceDTO: ParametersDTO
    {
        public int? CustomerId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}