using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class VehicleListViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleRegNo { get; set; }
        public string ModelName { get; set; }
        public string ColourName { get; set; }
        public string InsurancePolicyName { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
    }
}
