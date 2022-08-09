using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class VehicleMaintenanceRequestDetailsViewModel
    {
        public string RegistrationNumber { get; set; }
        public int VehicleId { get; set; }
        public SelectList AllVehicles { get; set; }
        public string MaintenanceDescription { get; set; }
        public decimal MaintenanceCost { get; set; }
        public string MaintainedBy { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int RequestId { get; set; }
        public List<VehicleMaintananceSparepartViewModel> spareParts { get; set; }
        public List<IFormFile> ReceiptFiles { get; set; }
        public List<VehicleRequestPhotoReceipt> ReceiptImages { get; set; }
    }
   
}
