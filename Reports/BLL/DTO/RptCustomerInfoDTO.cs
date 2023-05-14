using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class RptCustomerInfoDTO:ParametersDTO
    {
        public string CustomerCode { get; set; }

        public string CatCodeFrom { get; set; }

    }
}