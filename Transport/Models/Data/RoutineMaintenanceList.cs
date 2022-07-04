using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class RoutineMaintenanceList
    {
        public int RoutineMaintenanceListId { get; set; }
        public int VehicleRoutineMaintenanceId { get; set; }
        public int RoutineMaintenanceActivityId { get; set; }
        public int? SparePartId { get; set; }
        public bool? IsSparePartUsed { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int? Quantity { get; set; }
        public bool? IsRoutineCheck { get; set; }

        public virtual RoutineMaintenanceActivity RoutineMaintenanceActivity { get; set; }
        public virtual SparePart SparePart { get; set; }
        public virtual VehicleRoutineMaintenance VehicleRoutineMaintenance { get; set; }
    }
}
