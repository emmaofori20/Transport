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
        public VehicleService(
            IVehicleRepository vehicleRepository,
            ICollegeRepository collegeRepository,
            IDepartmentRepository departmentRepository,
            IVehicleUseRepository vehicleUseRepository,
            IMakeRepository makeRepository,
            IInsuranceRepository insuranceRepository,
            IVehicleStatusRepository vehicleStatusRepository
            )
        {
            _vehicleRepository = vehicleRepository;
            _collegeRepository = collegeRepository;
            _departmentRepository = departmentRepository;
            _vehicleUseRepository = vehicleUseRepository;
            _makeRepository = makeRepository;
            _insuranceRepository = insuranceRepository;
            _vehicleStatusRepository = vehicleStatusRepository;
        }


        public async Task<List<VehicleListViewModel>> GetAllVehicles()
        {
            return await _vehicleRepository.GetAllVehicles();
        }

        public async Task<VehicleDetailViewModel> GetVehicleById(int Id) 
        {
           return await _vehicleRepository.GetVehicle(Id);   
        }



        public async Task<int> AddNewVehicle(AddVehicleViewModel model)
        {
             
            
            if (model != null)
            {
                return await _vehicleRepository.AddVehicle(model);

            }
            return 0;
        }


        public AddVehicleViewModel setAllList()
        {
            var setVehicle = new AddVehicleViewModel
            {
                Colleges= _collegeRepository.GetColleges(),
                Departments = _departmentRepository.GetDepartments(),
                Makes = _makeRepository.GetAllMake(),
                Insurances = _insuranceRepository.GetAllInsurance(),
                VehicleUses = _vehicleUseRepository.GetAllVehicleUse(),
                Statuses = _vehicleStatusRepository.GetAllVehicleStatuses(),
            };

            return setVehicle;
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
