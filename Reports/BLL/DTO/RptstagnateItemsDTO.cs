using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class RptstagnateItemsDTO:ParametersDTO
    {
        public bool GetAll { get; set; }
        public string DateFrom { get; set; }
    }
}