using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class RptCashOnHandStatementDTO:ParametersDTO
    {
        public string AccountCodeFrom { get; set; }
            
        public string TrdateFrom { get; set; }
    
        public string TrdateTo { get; set; }

    }
}