using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class RPTCustomerStatementDTO:ParametersDTO
    {
        public string TrdateFrom { get; set; }
        public string TrdateTo { get; set; }
        public string CustomerCodeFrom { get; set; }

    }
}