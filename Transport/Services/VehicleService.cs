using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICollegeRepository _collegeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IVehicleUseRepository _vehicleUseRepository;
        private readonly IMakeRepository _makeRepository;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IVehicleStatusRepository _vehicleStatusRepository;
        private readonly ITyreSizeRepository _tyreSizeRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly IColourRepository _colourRepository;
        private readonly IQuantityRepository _quantityRepository;
        private readonly ITransmissionTypeRepository _transmissionTypeRepository;
        private readonly IPermAxleLoadRepository _permAxleLoadRepository;
        private readonly IPhotoSectionRepository _photoSectionRepository;

        public VehicleService(
            IVehicleRepository vehicleRepository,
            ICollegeRepository collegeRepository,
            IDepartmentRepository departmentRepository,
            IVehicleUseRepository vehicleUseRepository,
            IMakeRepository makeRepository,
            IInsuranceRepository insuranceRepository,
            IVehicleStatusRepository vehicleStatusRepository,
            ITyreSizeRepository tyreSizeRepository,
            ICountryRepository countryRepository,
            IModelRepository modelRepository,
            IVehicleTypeRepository vehicleTypeRepository,
            IFuelTypeRepository fuelTypeRepository,
            IColourRepository colourRepository,
            IQuantityRepository quantityRepository,
            ITransmissionTypeRepository transmissionTypeRepository,
            IPermAxleLoadRepository permAxleLoadRepository,
            IPhotoSectionRepository photoSectionRepository
            )
        {
            _vehicleRepository = vehicleRepository;
            _collegeRepository = collegeRepository;
            _departmentRepository = departmentRepository;
            _vehicleUseRepository = vehicleUseRepository;
            _makeRepository = makeRepository;
            _insuranceRepository = insuranceRepository;
            _vehicleStatusRepository = vehicleStatusRepository;
            _tyreSizeRepository = tyreSizeRepository;
            _countryRepository = countryRepository;
            _modelRepository = modelRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
            _fuelTypeRepository = fuelTypeRepository;
            _colourRepository = colourRepository;
            _quantityRepository = quantityRepository;
            _transmissionTypeRepository = transmissionTypeRepository;
            _permAxleLoadRepository = permAxleLoadRepository;
            _photoSectionRepository = photoSectionRepository;

        }


        public List<VehicleListViewModel> GetAllVehicles()
        {
            return  _vehicleRepository.GetAllVehicles().Result.Item1;
        }
      

        public async Task<VehicleDetailViewModel> GetVehicleById(int Id) 
        {
            try
            {
                return await _vehicleRepository.GetVehicle(Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public async Task<int> AddNewVehicle(AddVehicleViewModel model)
        {


            try
            {
                if (model != null)
                {
                    return await _vehicleRepository.AddVehicle(model);

                }
                return 0;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public AddVehicleViewModel setAllList()
        { 
            var setVehicle = new AddVehicleViewModel
            {
                Colleges = _collegeRepository.GetColleges(),
                Departments = _departmentRepository.GetDepartments(),
                Makes = _makeRepository.GetAllMake(),
                Insurances = _insuranceRepository.GetAllInsurance(),
                VehicleUses = _vehicleUseRepository.GetAllVehicleUse(),
                Statuses = _vehicleStatusRepository.GetAllVehicleStatuses(),
                TyreSizes = _tyreSizeRepository.GetTyreSizes(),
                Countries = _countryRepository.GetAllCountries(),
                VehicleTypes = _vehicleTypeRepository.GetVehicleTypes(),
                FuelTypes = _fuelTypeRepository.GetAllFuelTypes(),
                Colours = _colourRepository.GetColours(),
                Quantities = _quantityRepository.GetAllQuantities(),
                TransmissionTypes = _transmissionTypeRepository.GetTransmissionTypes(),
                PermAxleLoads = _permAxleLoadRepository.GetPermAxleLoads(),
                PhotoSections = _photoSectionRepository.GetPhotoSections(),
                PhotoItems = new List<PhotoItem>()
            };

            foreach (var item in setVehicle.PhotoSections)
            {
                setVehicle.PhotoItems.Add(new PhotoItem { PhotoSectionId = item.PhotoSectionId,PhotoSectionName = item.PhotoSectionName });
            }

            return setVehicle;
        }

        public AddVehicleViewModel listOfModelsByMake(int MakeId)
        {
            var listOfModels = new AddVehicleViewModel
            {
                Models = _modelRepository.GetAllModelsByMakeId(MakeId),
            };

            return listOfModels;
        }

        public async Task<UpdateVehicleViewModel> GetVehicleToUpdate(int Id) 
        {
            if(Id > 0)
            {
                return await _vehicleRepository.GetVehicleForUpdate(Id);
            }
            return null;
           
        }
        public async Task<int> UpdateVehicle(UpdateVehicleViewModel model) 
        {
            if(model != null)
            {
                return await _vehicleRepository.UpdateVehicle(model);
            }

            return 0;
        }

        public void DeleteVehicle(int Id)
        {
            if(Id > 0)
            {
                 _vehicleRepository.DeleteVehicle(Id);

            }
         
        }

    }
}
