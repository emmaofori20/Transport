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
        public string ModelName { get; set; }
        public string VehicleTypeName { get; set; }
        public string TransmissionTypeName { get; set; }
        public string CountryName { get; set; }
        public string ColourName { get; set; }
        public string FuelTypeName { get; set; }
        public string UseName { get; set; }
        public string StatusName { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
        public string InsurancePolicyName { get; set; }
        public string FrontTyreSizeValue { get; set; }
        public string MiddleTyreSizeValue { get; set; }
        public string RearTyreSizeValue { get; set; }
        public Decimal FrontPermAxleLoadValue { get; set; }
        public Decimal MiddlePermAxleLoadValue { get; set; }
        public Decimal RearPermAxleLoadValue { get; set; }
        public int WheelCountNumber { get; set; }
        public int AxleCountNumber { get; set; }
        public int CylinderCountNumber { get; set; }
        public int PersonCountNumber { get; set; }
        public List<VehiclePhoto> PhotoItems { get; set; }



    }
}
