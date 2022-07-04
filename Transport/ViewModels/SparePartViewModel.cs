using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;


namespace Transport.ViewModels
{
    public class SparePartViewModel
    {
        public int SparePartId { get; set; }
        [Required]
        public string SparePartName { get; set; }
        [Required]
        public int SparePartQuantity { get; set; }
    }

    public class RoutineActivityViewModel
    {
        [Required]
        public string RoutineActivityName { get; set; }
    }

    public class SparePartRoutineActiviesViewModel
    {
        public List<SparePartQuantity> SparePartQuantities { get; set; }

        public List<RoutineMaintenanceActivity> RoutineMaintenanceActivities { get; set; }
    }
}
