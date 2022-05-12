using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class SparePart
    {
        public SparePart()
        {
            RoutineMaintenanceLists = new HashSet<RoutineMaintenanceList>();
            SparePartQuantities = new HashSet<SparePartQuantity>();
        }

        public int SparePartId { get; set; }
        public string SparePartName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<RoutineMaintenanceList> RoutineMaintenanceLists { get; set; }
        public virtual ICollection<SparePartQuantity> SparePartQuantities { get; set; }
    }
}
