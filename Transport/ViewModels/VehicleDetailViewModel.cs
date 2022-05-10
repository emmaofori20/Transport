using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class VehicleDetailViewModel
    {
        public Vehicle vehicle { get; set; }
        public string MakeName { get; set; }
        public string UseName { get; set; }
        public string StatusName { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
        public string InsurancePolicyName { get; set; }
        public List<VehiclePhotoViewModel> VehiclePhotos { get; set; }



    }
}
