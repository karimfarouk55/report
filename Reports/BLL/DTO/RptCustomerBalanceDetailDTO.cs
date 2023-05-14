using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class RptCustomerBalanceDetailDTO:ParametersDTO
    {
        public string CustomerCodeFrom { get; set; }

        public string CatCodeFrom { get; set; }
    }
}