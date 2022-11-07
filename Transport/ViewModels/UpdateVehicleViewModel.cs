using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class UpdateVehicleViewModel
    {
        public int VehicleId { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Name of Vehicle Owner")]
        public string Owner { get; set; }

        [Required]
        public int ColourId { get; set; }
        public SelectList Colours { get; set; }

        [Required]
        public int ModelId { get; set; }
        public SelectList Models { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }
        public SelectList VehicleTypes { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Vehicle Registration No.")]
        public string RegistrationNumber { get; set; }

        public string OldRegistrationNumber { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Postal Address")]
        public string PostalAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public string Description { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Vehicle Chasis No.")]
        public string ChasisNumber { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public int CountryId { get; set; }
        public SelectList Countries { get; set; }

        [Required(ErrorMessage = "Enter Year of Manufacture")]
        public int YearOfManufacture { get; set; }

        public decimal? NetVehicleWeight { get; set; }
        public decimal? GrossVehicleWeight { get; set; }
        public decimal? PermCapacityLoad { get; set; }
        public string PolicyNumber { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Engine Number")]
        public string EngineNumber { get; set; }

        [Required(ErrorMessage = "Enter Engine Capacity")]
        public int EngineCapacity { get; set; }
        public int? HorsePower { get; set; }

        public int? Mileage { get; set; }

        [Required]
        public int FuelTypeId { get; set; }
        public SelectList FuelTypes { get; set; }
        public DateTime? DateOfEntry { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }

        [Required]
        public string UpdatedBy { get; set; }
        public int StatusId { get; set; }
        public SelectList Statuses { get; set; }
        public SelectList TyreSizes { get; set; }

        [Required]
        public int FrontTyreSize { get; set; }
        public int? MiddleTyreSize { get; set; }
        [Required]
        public int RearTyreSize { get; set; }
        public SelectList PermAxleLoads { get; set; }
        public int? FrontPermAxleLoad { get; set; }
        public int? MiddlePermAxleLoad { get; set; }
        public int? RearPermAxleLoad { get; set; }

        public SelectList Quantities { get; set; }

        [Required]
        public int CylinderCount { get; set; }

        [Required]
        public int WheelCount { get; set; }

        [Required]
        public int PersonCount { get; set; }
        public int AxleCount { get; set; }
        public int MakeId { get; set; }
        public SelectList Makes { get; set; }

        public int DepartmentId { get; set; }
        public SelectList Departments { get; set; }
        public int CollegeId { get; set; }
        public SelectList Colleges { get; set; }
        public int VehicleUseId { get; set; }
        public SelectList VehicleUses { get; set; }
        public int InsuranceId { get; set; }
        public SelectList Insurances { get; set; }
        public int TransmissionTypeId { get; set; }
        public SelectList TransmissionTypes { get; set; }

        public List<PhotoSection> PhotoSections { get; set; }

        public List<PhotoItemForUpdate> PhotoItems { get; set; }

    }
    public class PhotoItemForUpdate
    {
        public int PhotoSectionId { get; set; }
        public string PhotoSectionName { get; set; }
        public byte[] PhotoByte { get; set; }
        public IFormFile PhotoFile { get; set; }
    }

}
