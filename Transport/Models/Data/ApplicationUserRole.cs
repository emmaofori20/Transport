using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class ApplicationUserRole
    {
        public int ApplicationUserRoleId { get; set; }
        public int ApplicationUserId { get; set; }
        public int RoleId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
