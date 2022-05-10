using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class AddVehicleViewModel
    {
        public int VehicleId { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Name of Vehicle Owner")]
        public string Owner { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Colour of Vehicle")]
        public string Colour { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Vehicle Model")]
        public string Model { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Type of Vehicle")]
        public string VehicleType { get; set; }

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
        public int? NumberOfAxles { get; set; }


        [Required(ErrorMessage = "Enter Number of Wheels")]
        public int NumberOfWheels { get; set; }

        public string CountryOfOrigin { get; set; }

        [Required(ErrorMessage = "Enter Year of Manufacture")]
        [DataType(DataType.Date)]
        public DateTime YearOfManufacture { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Size of Front Tyre")]
        public string SizeOfFrontTyre { get; set; }
        public string SizeofMiddleTyre { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Size of Rear Tyre")]
        public string SizeOfRearTyre { get; set; }
        public string FrontPermAxleLoad { get; set; }
        public string MiddlePermAxleLoad { get; set; }
        public string RearPermAxleLoad { get; set; }
        public decimal? NetVehicleWeight { get; set; }
        public decimal? GrossVehicleWeight { get; set; }
        public decimal? PermCapacityLoad { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Number of Persons")]
        public string NumberOfPersons { get; set; }
        public string PolicyNumber { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Engine Number")]
        public string EngineNumber { get; set; }


        [Required(ErrorMessage = "Enter Number of Cylinders")]
        public int NumberOfCylinders { get; set; }

        [Required(ErrorMessage = "Enter Engine Capacity")]
        public int EngineCapacity { get; set; }
        public int? HorsePower { get; set; }
        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter Fuel Type")]
        public string FuelType { get; set; }
        public DateTime? DateOfEntry { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        public int StatusId { get; set; }
        public SelectList Statuses { get; set; }

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

        public IFormFileCollection PhotoFiles { get; set; }

        public List<VehiclePhoto> Photos { get; set; }


    }
}
