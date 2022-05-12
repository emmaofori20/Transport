using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        
        public async Task<List<VehicleListViewModel>> GetAllVehicles()
        {
            
            var vehicles = await _context.Vehicles.Include(x => x.Make)
                .Include(x => x.Insurance)
                .Include(x => x.Department)
                .Include(x => x.College)
                .ToListAsync();
            List<VehicleListViewModel> allVehicles = new List<VehicleListViewModel>();
            
            foreach(var vehicle in vehicles)
            {
                var vehicleListViewModel = new VehicleListViewModel()
                {
                    VehicleId = vehicle.VehicleId,
                    VehicleRegNo = vehicle.RegistrationNumber,
                    Model = vehicle.Model,
                    MakeName = vehicle.Make.MakeName,
                    Colour = vehicle.Colour,
                    InsurancePolicyName = vehicle.Insurance.InsurancePolicyName,
                    DepartmentName = vehicle.Department.DepartmentName,
                    CollegeName = vehicle.College.CollegeName,
                };

               allVehicles.Add(vehicleListViewModel);
            }

            return allVehicles;
        }
        public async Task<VehicleDetailViewModel> GetVehicle(int Id)
        {
            var vehicle = await _context.Vehicles
                .Include(x => x.Make)
                .Include(x => x.Department)
                .Include(x => x.College)
                .Include(x => x.Insurance)
                .Include(x => x.Status)
                .Include(x => x.VehicleUse)
                .Include(x => x.VehiclePhotos)
                .FirstOrDefaultAsync(x => x.VehicleId == Id);
            VehicleDetailViewModel vehicleDetailViewModel = new VehicleDetailViewModel()
            {
                vehicle = vehicle,
                MakeName = vehicle.Make.MakeName,
                DepartmentName = vehicle.Department.DepartmentName,
                CollegeName = vehicle.College.CollegeName,
                InsurancePolicyName = vehicle.Insurance.InsurancePolicyName,
                StatusName = vehicle.Status.StatusName,
                UseName = vehicle.VehicleUse.UseName,
                VehiclePhotos = vehicle.VehiclePhotos.Select(g => new VehiclePhotoViewModel
                {
                    PhotoId = g.VehicleId,
                    PhotoName = g.PhotoName,
                    PhotoFile = g.PhotoFile
                }).ToList(),
            };

            return vehicleDetailViewModel;
        }
        public async Task<int> AddVehicle(AddVehicleViewModel vehicleModel)
        {
           if(vehicleModel != null)
            {
                var newVehicle = new Vehicle()
                {
                    Owner = vehicleModel.Owner,
                    Colour = vehicleModel.Colour,
                    Model = vehicleModel.Model,
                    VehicleType = vehicleModel.VehicleType,
                    RegistrationNumber = vehicleModel.RegistrationNumber,
                    OldRegistrationNumber = vehicleModel.OldRegistrationNumber,
                    PostalAddress = vehicleModel.PostalAddress,
                    ResidentialAddress = vehicleModel.ResidentialAddress,
                    Description = vehicleModel.Description,
                    ChasisNumber = vehicleModel.ChasisNumber,
                    Length = vehicleModel.Length,
                    Width = vehicleModel.Width,
                    Height = vehicleModel.Height,
                    NumberOfAxles = vehicleModel.NumberOfAxles,
                    NumberOfWheels = vehicleModel.NumberOfWheels,
                    CountryOfOrigin = vehicleModel.CountryOfOrigin,
                    YearOfManufacture = DateTime.Now,
                    SizeOfFrontTyre = vehicleModel.SizeOfFrontTyre,
                    SizeofMiddleTyre = vehicleModel.SizeofMiddleTyre,
                    SizeOfRearTyre = vehicleModel.SizeOfRearTyre,
                    FrontPermAxleLoad = vehicleModel.FrontPermAxleLoad,
                    MiddlePermAxleLoad = vehicleModel.MiddlePermAxleLoad,
                    RearPermAxleLoad = vehicleModel.RearPermAxleLoad,
                    NetVehicleWeight = vehicleModel.NetVehicleWeight,
                    GrossVehicleWeight = vehicleModel.GrossVehicleWeight,
                    PermCapacityLoad = vehicleModel.PermCapacityLoad,
                    NumberOfPersons = vehicleModel.NumberOfPersons,
                    PolicyNumber = vehicleModel.PolicyNumber,
                    EngineNumber = vehicleModel.EngineNumber,
                    NumberOfCylinders = vehicleModel.NumberOfCylinders,
                    EngineCapacity = vehicleModel.EngineCapacity,
                    HorsePower = vehicleModel.HorsePower,
                    FuelType = vehicleModel.FuelType,
                    DateOfEntry = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "User",
                    CollegeId = vehicleModel.CollegeId,
                    DepartmentId = vehicleModel.DepartmentId,
                    MakeId = vehicleModel.MakeId,
                    StatusId = vehicleModel.StatusId,
                    VehicleUseId = vehicleModel.VehicleUseId,
                    InsuranceId = vehicleModel.InsuranceId,
                };

                newVehicle.VehiclePhotos = new List<VehiclePhoto>();
                foreach (var file in vehicleModel.Photos)
                {
                    newVehicle.VehiclePhotos.Add(new VehiclePhoto()
                    {
                        PhotoName = file.PhotoName,
                        PhotoFile = file.PhotoFile,
                    });
                }

                await _context.Vehicles.AddAsync(newVehicle);
                await _context.SaveChangesAsync();

                return newVehicle.VehicleId;
            }

            return 0;
                
        }

        public async Task<UpdateVehicleViewModel> GetVehicleForUpdate(int Id)
        {
            var vehicle = await _context.Vehicles
                .Include(x => x.Make)
                .Include(x => x.Department)
                .Include(x => x.College)
                .Include(x => x.Insurance)
                .Include(x => x.Status)
                .Include(x => x.VehicleUse)
                .Include(x => x.VehiclePhotos)
                .FirstOrDefaultAsync(x => x.VehicleId == Id);
            UpdateVehicleViewModel updateVehicleViewModel = new UpdateVehicleViewModel()
            {
                VehicleId = vehicle.VehicleId,
                Owner = vehicle.Owner,
                Colour = vehicle.Colour,
                Model = vehicle.Model,
                VehicleType = vehicle.VehicleType,
                RegistrationNumber = vehicle.RegistrationNumber,
                OldRegistrationNumber = vehicle.OldRegistrationNumber,
                PostalAddress = vehicle.PostalAddress,
                ResidentialAddress = vehicle.ResidentialAddress,
                Description = vehicle.Description,
                ChasisNumber = vehicle.ChasisNumber,
                Length = vehicle.Length,
                Width = vehicle.Width,
                Height = vehicle.Height,
                NumberOfAxles = vehicle.NumberOfAxles,
                NumberOfWheels = vehicle.NumberOfWheels,
                CountryOfOrigin = vehicle.CountryOfOrigin,
                YearOfManufacture = vehicle.YearOfManufacture,
                SizeOfFrontTyre = vehicle.SizeOfFrontTyre,
                SizeofMiddleTyre = vehicle.SizeofMiddleTyre,
                SizeOfRearTyre = vehicle.SizeOfRearTyre,
                FrontPermAxleLoad = vehicle.FrontPermAxleLoad,
                MiddlePermAxleLoad = vehicle.MiddlePermAxleLoad,
                RearPermAxleLoad = vehicle.RearPermAxleLoad,
                NetVehicleWeight = vehicle.NetVehicleWeight,
                GrossVehicleWeight = vehicle.GrossVehicleWeight,
                PermCapacityLoad = vehicle.PermCapacityLoad,
                NumberOfPersons = vehicle.NumberOfPersons,
                PolicyNumber = vehicle.PolicyNumber,
                EngineNumber = vehicle.EngineNumber,
                NumberOfCylinders = vehicle.NumberOfCylinders,
                EngineCapacity = vehicle.EngineCapacity,
                HorsePower = vehicle.HorsePower,
                FuelType = vehicle.FuelType,
                DateOfEntry = vehicle.DateOfEntry,
                UpdatedOn = DateTime.Now,
                UpdatedBy = "User",
                CollegeId = vehicle.CollegeId,
                DepartmentId = vehicle.DepartmentId,
                MakeId = vehicle.MakeId,
                StatusId = vehicle.StatusId,
                VehicleUseId = vehicle.VehicleUseId,
                InsuranceId = vehicle.InsuranceId,
                Photos = vehicle.VehiclePhotos.Select(x => new VehiclePhoto()
                {
                    VehiclePhotoId = x.VehiclePhotoId,
                    PhotoName = x.PhotoName,
                    PhotoFile = x.PhotoFile
                }).ToList()
            };

            return updateVehicleViewModel;

        }

        public async Task<int> UpdateVehicle(UpdateVehicleViewModel model)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == model.VehicleId);
            if(vehicle != null)
            {
                vehicle.Owner = model.Owner;
                vehicle.Model = model.Model;
                vehicle.Colour = model.Colour;
                vehicle.VehicleType = model.VehicleType;
                vehicle.RegistrationNumber = model.RegistrationNumber;
                vehicle.OldRegistrationNumber = model.OldRegistrationNumber;
                vehicle.PostalAddress = model.PostalAddress;
                vehicle.ResidentialAddress = model.ResidentialAddress;
                vehicle.Description = model.Description;
                vehicle.ChasisNumber = model.ChasisNumber;
                vehicle.Length = model.Length;
                vehicle.Width = model.Width;
                vehicle.Height = model.Height;
                vehicle.NumberOfAxles = model.NumberOfAxles;
                vehicle.NumberOfWheels = model.NumberOfWheels;
                vehicle.CountryOfOrigin = model.CountryOfOrigin;
                vehicle.YearOfManufacture = model.YearOfManufacture;
                vehicle.SizeOfFrontTyre = model.SizeOfFrontTyre;
                vehicle.SizeofMiddleTyre = model.SizeofMiddleTyre;
                vehicle.SizeOfRearTyre = model.SizeOfRearTyre;
                vehicle.FrontPermAxleLoad = model.FrontPermAxleLoad;
                vehicle.MiddlePermAxleLoad = model.MiddlePermAxleLoad;
                vehicle.RearPermAxleLoad = model.RearPermAxleLoad;
                vehicle.NetVehicleWeight = model.NetVehicleWeight;
                vehicle.GrossVehicleWeight = model.GrossVehicleWeight;
                vehicle.PermCapacityLoad = model.PermCapacityLoad;
                vehicle.NumberOfPersons = model.NumberOfPersons;
                vehicle.PolicyNumber = model.PolicyNumber;
                vehicle.EngineNumber = model.EngineNumber;
                vehicle.NumberOfCylinders = model.NumberOfCylinders;
                vehicle.EngineCapacity = model.EngineCapacity;
                vehicle.HorsePower = model.HorsePower;
                vehicle.FuelType = model.FuelType;
                vehicle.DateOfEntry = model.DateOfEntry;
                vehicle.UpdatedOn = DateTime.Now;
                vehicle.UpdatedBy = "User";
                vehicle.CollegeId = model.CollegeId;
                vehicle.DepartmentId = model.DepartmentId;
                vehicle.MakeId = model.MakeId;
                vehicle.StatusId = model.StatusId;
                vehicle.VehicleUseId = model.VehicleUseId;
                vehicle.InsuranceId = model.InsuranceId;
                //vehicle.VehiclePhotos = new List<VehiclePhoto>();
                foreach (var file in model.Photos)
                {
                    vehicle.VehiclePhotos.Add(new VehiclePhoto()
                    {
                        PhotoName = file.PhotoName,
                        PhotoFile = file.PhotoFile
                    });
                }
            };
            _context.Vehicles.Update(vehicle);
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
            if(vehicle != null)
            {
                //vehicle.IsDeleted = true;
                vehicle.UpdatedBy = "User";
                vehicle.UpdatedOn = DateTime.Now;
            }

            foreach(var item in vehicle.Hirings)
            {
                _context.Remove(item);
            }

            foreach(var item in vehicle.VehicleRoutineMaintenances)
            {
                _context.Remove(item);
            }
            foreach(var item in vehicle.VehicleTransportStaffs)
            {
                _context.Remove(item);
            }
            foreach(var item in vehicle.VehicleMaintenanceRequests)
            {
                _context.Remove(item);
            }
            foreach(var item in vehicle.VehiclePhotos)
            {
                _context.Remove(item);
            }

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }

        

    }
}

