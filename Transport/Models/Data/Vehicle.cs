using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Hirings = new HashSet<Hiring>();
            VehicleMaintenanceRequests = new HashSet<VehicleMaintenanceRequest>();
            VehiclePhotos = new HashSet<VehiclePhoto>();
            VehicleRoutineMaintenances = new HashSet<VehicleRoutineMaintenance>();
            VehicleTransportStaffs = new HashSet<VehicleTransportStaff>();
        }

        public int VehicleId { get; set; }
        public string Owner { get; set; }
        public string Colour { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public string OldRegistrationNumber { get; set; }
        public string PostalAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public string ChasisNumber { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string Description { get; set; }
        public int? NumberOfAxles { get; set; }
        public int NumberOfWheels { get; set; }
        public string CountryOfOrigin { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public string SizeOfFrontTyre { get; set; }
        public string SizeofMiddleTyre { get; set; }
        public string SizeOfRearTyre { get; set; }
        public string FrontPermAxleLoad { get; set; }
        public string MiddlePermAxleLoad { get; set; }
        public string RearPermAxleLoad { get; set; }
        public decimal? NetVehicleWeight { get; set; }
        public decimal? GrossVehicleWeight { get; set; }
        public decimal? PermCapacityLoad { get; set; }
        public string NumberOfPersons { get; set; }
        public string PolicyNumber { get; set; }
        public string EngineNumber { get; set; }
        public int NumberOfCylinders { get; set; }
        public int EngineCapacity { get; set; }
        public int? HorsePower { get; set; }
        public string FuelType { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int StatusId { get; set; }
        public int MakeId { get; set; }
        public int InsuranceId { get; set; }
        public int DepartmentId { get; set; }
        public int CollegeId { get; set; }
        public int VehicleUseId { get; set; }

        public virtual College College { get; set; }
        public virtual Department Department { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual Make Make { get; set; }
        public virtual Status Status { get; set; }
        public virtual VehicleUse VehicleUse { get; set; }
        public virtual ICollection<Hiring> Hirings { get; set; }
        public virtual ICollection<VehicleMaintenanceRequest> VehicleMaintenanceRequests { get; set; }
        public virtual ICollection<VehiclePhoto> VehiclePhotos { get; set; }
        public virtual ICollection<VehicleRoutineMaintenance> VehicleRoutineMaintenances { get; set; }
        public virtual ICollection<VehicleTransportStaff> VehicleTransportStaffs { get; set; }
    }
}
