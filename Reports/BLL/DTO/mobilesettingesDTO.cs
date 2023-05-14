using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
   public class mobilesettingesDTO
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object data { get; set; }
        public int bookid { get; set; }

        public string termid { get; set; }

        public string termname { get; set; }
        public bool termisdefualt { get; set; }

    }
}
