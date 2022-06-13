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
            VehicleDocuments = new HashSet<VehicleDocument>();
            VehicleMaintenanceRequests = new HashSet<VehicleMaintenanceRequest>();
            VehiclePhotos = new HashSet<VehiclePhoto>();
            VehicleRoutineMaintenances = new HashSet<VehicleRoutineMaintenance>();
            VehicleTransportStaffs = new HashSet<VehicleTransportStaff>();
        }

        public int VehicleId { get; set; }
        public string Owner { get; set; }
        public string RegistrationNumber { get; set; }
        public string OldRegistrationNumber { get; set; }
        public string PostalAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public string ChasisNumber { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string Description { get; set; }
        public int YearOfManufacture { get; set; }
        public decimal? NetVehicleWeight { get; set; }
        public decimal? GrossVehicleWeight { get; set; }
        public decimal? PermCapacityLoad { get; set; }
        public string PolicyNumber { get; set; }
        public string EngineNumber { get; set; }
        public int EngineCapacity { get; set; }
        public int? Mileage { get; set; }
        public int? HorsePower { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int StatusId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int InsuranceId { get; set; }
        public int DepartmentId { get; set; }
        public int CollegeId { get; set; }
        public int VehicleUseId { get; set; }
        public int VehicleTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int ColourId { get; set; }
        public int RearTyreSize { get; set; }
        public int? MiddleTyreSize { get; set; }
        public int FrontTyreSize { get; set; }
        public int CylinderCount { get; set; }
        public int WheelCount { get; set; }
        public int PersonCount { get; set; }
        public int AxleCount { get; set; }
        public int TransmissionTypeId { get; set; }
        public int? FrontPermAxleLoad { get; set; }
        public int? MiddlePermAxleLoad { get; set; }
        public int? RearPermAxleLoad { get; set; }
        public int CountryId { get; set; }

        public virtual Quantity AxleCountNavigation { get; set; }
        public virtual College College { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Country Country { get; set; }
        public virtual Quantity CylinderCountNavigation { get; set; }
        public virtual Department Department { get; set; }
        public virtual PermAxleLoad FrontPermAxleLoadNavigation { get; set; }
        public virtual TyreSize FrontTyreSizeNavigation { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual Make Make { get; set; }
        public virtual PermAxleLoad MiddlePermAxleLoadNavigation { get; set; }
        public virtual TyreSize MiddleTyreSizeNavigation { get; set; }
        public virtual Model Model { get; set; }
        public virtual Quantity PersonCountNavigation { get; set; }
        public virtual PermAxleLoad RearPermAxleLoadNavigation { get; set; }
        public virtual TyreSize RearTyreSizeNavigation { get; set; }
        public virtual Status Status { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual VehicleUse VehicleUse { get; set; }
        public virtual Quantity WheelCountNavigation { get; set; }
        public virtual ICollection<Hiring> Hirings { get; set; }
        public virtual ICollection<VehicleDocument> VehicleDocuments { get; set; }
        public virtual ICollection<VehicleMaintenanceRequest> VehicleMaintenanceRequests { get; set; }
        public virtual ICollection<VehiclePhoto> VehiclePhotos { get; set; }
        public virtual ICollection<VehicleRoutineMaintenance> VehicleRoutineMaintenances { get; set; }
        public virtual ICollection<VehicleTransportStaff> VehicleTransportStaffs { get; set; }
    }
}
