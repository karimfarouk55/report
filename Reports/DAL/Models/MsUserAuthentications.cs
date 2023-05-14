using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class MsUserAuthentications
    {
        public int AuthId { get; set; }
        public int? UserId { get; set; }
        public string AuthCode { get; set; }
        public string AuthName { get; set; }
        public string AuthDesc { get; set; }
        public bool? Authinticated { get; set; }
        public int? AuthenticatedBy { get; set; }
    }
}
