using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }

        public int ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public int StaffId { get; set; }
        public string SurName { get; set; }
        public string OtherNames { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
