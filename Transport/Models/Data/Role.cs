using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Role
    {
        public Role()
        {
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
