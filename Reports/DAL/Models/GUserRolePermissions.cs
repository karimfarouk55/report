using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class GUserRolePermissions
    {
        public int UserRolePermId { get; set; }
        public int? UserRoleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleDescA { get; set; }
        public byte? ModuleType { get; set; }
        public bool CanOpen { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanPrint { get; set; }
        public bool CanPreView { get; set; }
        public bool CanPost { get; set; }

        public virtual GUserRole UserRole { get; set; }
    }
}
