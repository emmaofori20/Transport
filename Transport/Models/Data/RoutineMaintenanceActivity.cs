using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class RoutineMaintenanceActivity
    {
        public RoutineMaintenanceActivity()
        {
            RoutineMaintenanceLists = new HashSet<RoutineMaintenanceList>();
        }

        public int RoutineMaintenanceActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime CreatedBy { get; set; }

        public virtual ICollection<RoutineMaintenanceList> RoutineMaintenanceLists { get; set; }
    }
}
