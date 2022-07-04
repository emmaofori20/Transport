using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class RoutineMaintenanceVehicleViewModel
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public int RoutineId { get; set; }
        public DateTime Date { get; set; }
        public string CreatedBy { get; set; }
        public SelectList AllVehicles { get; set; }
        public SelectList SparePartsUsed { get; set; }
        public List<RoutineActivityCheck> RoutineActivity { get; set; }
    }

    public class RoutineActivityCheck
    {
        public string ActivityName { get; set; }
        public bool Isokay { get; set; }
        public  bool IsRequiredSparePart { get; set; }
        public int ActivityId { get; set; }
        public double Quantity { get; set; }
        public int SparePartId { get; set; }
        public string SparePartName { get; set; }

    }
}
