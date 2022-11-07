using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TransportDbContext _context;
        public VehicleRepository(TransportDbContext context)
        {
            _context = context;
        }

        public async Task<(List<VehicleListViewModel>, List<Vehicle>)> GetAllVehicles()
        {

            var vehicles = await _context.Vehicles
                .Include(x => x.Insurance)
                .Include(x => x.Department)
                .Include(x => x.College)
                .Include(x => x.Model)
                .Include(x => x.Colour)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.VehicleId)
                .Include(x => x.Status)
                .Include(x => x.VehiclePhotos)
                .ToListAsync();
            List<VehicleListViewModel> allVehicles = new List<VehicleListViewModel>();

            foreach (var vehicle in vehicles)
            {
                var vehicleListViewModel = new VehicleListViewModel()
                {
                    VehicleId = vehicle.VehicleId,
                    VehicleRegNo = vehicle.RegistrationNumber,
                    ModelName = vehicle.Model.ModelName,
                    ColourName = vehicle.Colour.ColourName,
                    InsurancePolicyName = vehicle.Insurance.InsurancePolicyName,
                    DepartmentName = vehicle.Department.DepartmentName,
                    CollegeName = vehicle.College.CollegeName,
                };

                allVehicles.Add(vehicleListViewModel);
            }

            return (allVehicles, vehicles);
        }
        public async Task<VehicleDetailViewModel> GetVehicle(int Id)
        {
            try
            {
                var vehicle = await _context.Vehicles
                .Include(x => x.Make)
                .Include(x => x.Model)
                .Include(x => x.VehicleType)
                .Include(x => x.Country)
                .Include(x => x.Colour)
                .Include(x => x.Department)
                .Include(x => x.College)
                .Include(x => x.Insurance)
                .Include(x => x.Status)
                .Include(x => x.VehicleUse)
                .Include(x => x.FrontTyreSizeNavigation)
                .Include(x => x.MiddleTyreSizeNavigation)
                .Include(x => x.RearTyreSizeNavigation)
                .Include(x => x.FrontPermAxleLoadNavigation)
                .Include(x => x.MiddlePermAxleLoadNavigation)
                .Include(x => x.RearPermAxleLoadNavigation)
                .Include(x => x.TransmissionType)
                .Include(x => x.WheelCountNavigation)
                .Include(x => x.AxleCountNavigation)
                .Include(x => x.CylinderCountNavigation)
                .Include(x => x.PersonCountNavigation)
                .Include(x => x.FuelType)
                .Include(x => x.VehiclePhotos)
                .FirstOrDefaultAsync(x => x.VehicleId == Id);
                VehicleDetailViewModel vehicleDetailViewModel = new VehicleDetailViewModel()
                {
                    vehicle = vehicle,
                    MakeName = vehicle.Make.MakeName,
                    ModelName = vehicle.Model.ModelName,
                    VehicleTypeName = vehicle.VehicleType.VehicleTypeName,
                    TransmissionTypeName = vehicle.VehicleType.VehicleTypeName,
                    CountryName = vehicle.Country.CountryName,
                    ColourName = vehicle.Colour.ColourName,
                    FuelTypeName = vehicle.FuelType.FuelTypeName,
                    DepartmentName = vehicle.Department.DepartmentName,
                    CollegeName = vehicle.College.CollegeName,
                    InsurancePolicyName = vehicle.Insurance.InsurancePolicyName,
                    StatusName = vehicle.Status.StatusName,
                    UseName = vehicle.VehicleUse.UseName,
                    FrontTyreSizeValue = vehicle.FrontTyreSizeNavigation.TyreSizeNumber,
                    MiddleTyreSizeValue = vehicle.MiddleTyreSizeNavigation != null ? vehicle.MiddleTyreSizeNavigation.TyreSizeNumber : null,
                    RearTyreSizeValue = vehicle.RearTyreSizeNavigation.TyreSizeNumber,
                    FrontPermAxleLoadValue = vehicle.FrontPermAxleLoadNavigation != null ? vehicle.FrontPermAxleLoadNavigation.PermAxleLoadValue : 0,
                    MiddlePermAxleLoadValue = vehicle.MiddlePermAxleLoadNavigation != null ? vehicle.MiddlePermAxleLoadNavigation.PermAxleLoadValue : 0,
                    RearPermAxleLoadValue = vehicle.RearPermAxleLoadNavigation != null ? vehicle.RearPermAxleLoadNavigation.PermAxleLoadValue : 0,
                    WheelCountNumber = vehicle.WheelCountNavigation.Number,
                    AxleCountNumber = vehicle.AxleCountNavigation.Number,
                    CylinderCountNumber = vehicle.CylinderCountNavigation.Number,
                    PersonCountNumber = vehicle.PersonCountNavigation.Number,
                    PhotoItems = vehicle.VehiclePhotos.Select(x => new VehiclePhoto
                    {
                        VehiclePhotoId = x.VehiclePhotoId,
                        PhotoSectionId = x.PhotoSectionId,
                        PhotoName = x.PhotoName,
                        PhotoFile = x.PhotoFile,
                    }).ToList()
                };
                return vehicleDetailViewModel;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<int> AddVehicle(AddVehicleViewModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                var newVehicle = new Vehicle()
                {
                    Owner = vehicleModel.Owner,
                    ColourId = vehicleModel.ColourId,
                    ModelId = vehicleModel.ModelId,
                    VehicleTypeId = vehicleModel.VehicleTypeId,
                    RegistrationNumber = vehicleModel.RegistrationNumber,
                    OldRegistrationNumber = vehicleModel.OldRegistrationNumber,
                    PostalAddress = vehicleModel.PostalAddress,
                    ResidentialAddress = vehicleModel.ResidentialAddress,
                    Description = vehicleModel.Description,
                    ChasisNumber = vehicleModel.ChasisNumber,
                    Length = vehicleModel.Length,
                    Width = vehicleModel.Width,
                    Height = vehicleModel.Height,
                    AxleCount = vehicleModel.AxleCount,
                    WheelCount = vehicleModel.WheelCount,
                    CountryId = vehicleModel.CountryId,
                    YearOfManufacture = vehicleModel.YearOfManufacture,
                    FrontTyreSize = vehicleModel.FrontTyreSize,
                    MiddleTyreSize = vehicleModel.MiddleTyreSize,
                    RearTyreSize = vehicleModel.RearTyreSize,
                    FrontPermAxleLoad = vehicleModel.FrontPermAxleLoad,
                    MiddlePermAxleLoad = vehicleModel.MiddlePermAxleLoad,
                    RearPermAxleLoad = vehicleModel.RearPermAxleLoad,
                    NetVehicleWeight = vehicleModel.NetVehicleWeight,
                    GrossVehicleWeight = vehicleModel.GrossVehicleWeight,
                    PermCapacityLoad = vehicleModel.PermCapacityLoad,
                    PersonCount = vehicleModel.PersonCount,
                    PolicyNumber = vehicleModel.PolicyNumber,
                    EngineNumber = vehicleModel.EngineNumber,
                    CylinderCount = vehicleModel.CylinderCount,
                    EngineCapacity = vehicleModel.EngineCapacity,
                    HorsePower = vehicleModel.HorsePower,
                    Mileage = vehicleModel.Mileage,
                    FuelTypeId = vehicleModel.FuelTypeId,
                    DateOfEntry = vehicleModel.DateOfEntry,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "User",
                    IsDeleted = false,
                    CollegeId = vehicleModel.CollegeId,
                    DepartmentId = vehicleModel.DepartmentId,
                    MakeId = vehicleModel.MakeId,
                    StatusId = vehicleModel.StatusId,
                    VehicleUseId = vehicleModel.VehicleUseId,
                    InsuranceId = vehicleModel.InsuranceId,
                    TransmissionTypeId = vehicleModel.TransmissionTypeId,
                };


                await _context.Vehicles.AddAsync(newVehicle);
                await _context.SaveChangesAsync();

                foreach (var item in vehicleModel.PhotoItems)
                {
                    VehiclePhoto newPhoto = new VehiclePhoto
                    {
                        VehicleId = newVehicle.VehicleId,
                        PhotoSectionId = item.PhotoSectionId,
                        PhotoFile = ConvertToByte(item.PhotoFile),
                        PhotoName = item.PhotoFile.FileName,
                        CreatedBy = "User",
                        CreatedOn = DateTime.UtcNow
                    };

                    await _context.VehiclePhotos.AddAsync(newPhoto);

                }
                await _context.SaveChangesAsync();

                return newVehicle.VehicleId;
            }

            return 0;

        }

        private byte[] ConvertToByte(IFormFile formFile)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                fileBytes = stream.ToArray();
            }

            return fileBytes;
        }

        public async Task<UpdateVehicleViewModel> GetVehicleForUpdate(int Id)
        {
            try
            {
                var vehicle = await _context.Vehicles
                .Include(x => x.Make)
                .Include(x => x.Department)
                .Include(x => x.College)
                .Include(x => x.Insurance)
                .Include(x => x.Status)
                .Include(x => x.VehicleUse)
                .Include(x => x.VehiclePhotos)
                .Include(x => x.Colour)
                .Include(x => x.Model)
                .Include(x => x.VehicleType)
                .FirstOrDefaultAsync(x => x.VehicleId == Id);
                UpdateVehicleViewModel updateVehicleViewModel = new UpdateVehicleViewModel()
                {
                    VehicleId = vehicle.VehicleId,
                    Owner = vehicle.Owner,
                    ColourId = vehicle.ColourId,
                    ModelId = vehicle.ModelId,
                    VehicleTypeId = vehicle.VehicleTypeId,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    OldRegistrationNumber = vehicle.OldRegistrationNumber,
                    PostalAddress = vehicle.PostalAddress,
                    ResidentialAddress = vehicle.ResidentialAddress,
                    Description = vehicle.Description,
                    ChasisNumber = vehicle.ChasisNumber,
                    Length = vehicle.Length,
                    Width = vehicle.Width,
                    Height = vehicle.Height,
                    AxleCount = vehicle.AxleCount,
                    WheelCount = vehicle.WheelCount,
                    CountryId = vehicle.CountryId,
                    YearOfManufacture = vehicle.YearOfManufacture,
                    FrontTyreSize = vehicle.FrontTyreSize,
                    MiddleTyreSize = vehicle.MiddleTyreSize,
                    RearTyreSize = vehicle.RearTyreSize,
                    FrontPermAxleLoad = vehicle.FrontPermAxleLoad,
                    MiddlePermAxleLoad = vehicle.MiddlePermAxleLoad,
                    RearPermAxleLoad = vehicle.RearPermAxleLoad,
                    NetVehicleWeight = vehicle.NetVehicleWeight,
                    GrossVehicleWeight = vehicle.GrossVehicleWeight,
                    PermCapacityLoad = vehicle.PermCapacityLoad,
                    PersonCount = vehicle.PersonCount,
                    PolicyNumber = vehicle.PolicyNumber,
                    EngineNumber = vehicle.EngineNumber,
                    CylinderCount = vehicle.CylinderCount,
                    EngineCapacity = vehicle.EngineCapacity,
                    HorsePower = vehicle.HorsePower,
                    Mileage = vehicle.Mileage,
                    FuelTypeId = vehicle.FuelTypeId,
                    DateOfEntry = vehicle.DateOfEntry,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = "User",
                    CollegeId = vehicle.CollegeId,
                    DepartmentId = vehicle.DepartmentId,
                    MakeId = vehicle.MakeId,
                    StatusId = vehicle.StatusId,
                    VehicleUseId = vehicle.VehicleUseId,
                    InsuranceId = vehicle.InsuranceId,
                    TransmissionTypeId = vehicle.TransmissionTypeId,
                    PhotoItems = vehicle.VehiclePhotos.Select(x => new PhotoItemForUpdate
                    {
                        PhotoSectionId = x.PhotoSectionId,
                        PhotoSectionName = x.PhotoSection.PhotoSectionName,
                        PhotoByte = x.PhotoFile,
                    }).ToList()

                };


                return updateVehicleViewModel;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<int> UpdateVehicle(UpdateVehicleViewModel model)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == model.VehicleId);
            if (vehicle != null)
            {
                vehicle.VehicleId = model.VehicleId;
                vehicle.Owner = model.Owner;
                vehicle.ColourId = model.ColourId;
                vehicle.ModelId = model.ModelId;
                vehicle.VehicleTypeId = model.VehicleTypeId;
                vehicle.RegistrationNumber = model.RegistrationNumber;
                vehicle.OldRegistrationNumber = model.OldRegistrationNumber;
                vehicle.PostalAddress = model.PostalAddress;
                vehicle.ResidentialAddress = model.ResidentialAddress;
                vehicle.Description = model.Description;
                vehicle.ChasisNumber = model.ChasisNumber;
                vehicle.Length = model.Length;
                vehicle.Width = model.Width;
                vehicle.Height = model.Height;
                vehicle.AxleCount = model.AxleCount;
                vehicle.WheelCount = model.WheelCount;
                vehicle.CountryId = model.CountryId;
                vehicle.YearOfManufacture = model.YearOfManufacture;
                vehicle.FrontTyreSize = model.FrontTyreSize;
                vehicle.MiddleTyreSize = model.MiddleTyreSize;
                vehicle.RearTyreSize = model.RearTyreSize;
                vehicle.FrontPermAxleLoad = model.FrontPermAxleLoad;
                vehicle.MiddlePermAxleLoad = model.MiddlePermAxleLoad;
                vehicle.RearPermAxleLoad = model.RearPermAxleLoad;
                vehicle.NetVehicleWeight = model.NetVehicleWeight;
                vehicle.GrossVehicleWeight = model.GrossVehicleWeight;
                vehicle.PermCapacityLoad = model.PermCapacityLoad;
                vehicle.PersonCount = model.PersonCount;
                vehicle.PolicyNumber = model.PolicyNumber;
                vehicle.EngineNumber = model.EngineNumber;
                vehicle.CylinderCount = model.CylinderCount;
                vehicle.EngineCapacity = model.EngineCapacity;
                vehicle.HorsePower = model.HorsePower;
                vehicle.Mileage = model.Mileage;
                vehicle.FuelTypeId = model.FuelTypeId;
                vehicle.DateOfEntry = model.DateOfEntry;
                vehicle.UpdatedOn = DateTime.Now;
                vehicle.UpdatedBy = "User";
                vehicle.IsDeleted = false;
                vehicle.CollegeId = model.CollegeId;
                vehicle.DepartmentId = model.DepartmentId;
                vehicle.MakeId = model.MakeId;
                vehicle.StatusId = model.StatusId;
                vehicle.VehicleUseId = model.VehicleUseId;
                vehicle.TransmissionTypeId = model.TransmissionTypeId;

                _context.Vehicles.Update(vehicle);
                _context.SaveChanges();

                var vehiclePhotoItems = _context.VehiclePhotos.Where(x => x.VehicleId == vehicle.VehicleId).ToList();

                foreach (var item in model.PhotoItems)
                {
                    var currentPhoto = vehiclePhotoItems.Where(x => x.PhotoSectionId == item.PhotoSectionId).FirstOrDefault();

                    if (item.PhotoFile != null)
                    {
                        currentPhoto.PhotoFile = ConvertToByte(item.PhotoFile);
                        _context.VehiclePhotos.Update(currentPhoto);
                    }


                };

            };

            _context.SaveChanges();
            return vehicle.VehicleId;
        }

        public void DeleteVehicle(int Id)
        {
            Vehicle vehicle = _context.Vehicles
                .Include(x => x.Hirings)
                .Include(x => x.VehicleRoutineMaintenances)
                .Include(x => x.VehicleTransportStaffs)
                .Include(x => x.VehicleMaintenanceRequests)
                .Include(x => x.VehiclePhotos)
                .Where(x => x.VehicleId == Id).FirstOrDefault();
            if (vehicle != null)
            {
                vehicle.IsDeleted = true;
                vehicle.UpdatedBy = "User";
                vehicle.UpdatedOn = DateTime.Now;
            }

            //foreach (var item in vehicle.Hirings)
            //{
            //    _context.Remove(item);
            //}

            //foreach (var item in vehicle.VehicleRoutineMaintenances)
            //{
            //    _context.Remove(item);
            //}
            //foreach (var item in vehicle.VehicleTransportStaffs)
            //{
            //    _context.Remove(item);
            //}
            //foreach (var item in vehicle.VehicleMaintenanceRequests)
            //{
            //    _context.Remove(item);
            //}
            //foreach (var item in vehicle.VehiclePhotos)
            //{
            //    _context.Remove(item);
            //}

            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }



    }
}

