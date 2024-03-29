﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
    public interface IVehicleService
    {
        List<VehicleListViewModel> GetAllVehicles();
        Task<VehicleDetailViewModel> GetVehicleById(int Id);
        Task <int> AddNewVehicle(AddVehicleViewModel model);
        public AddVehicleViewModel setAllList();
        public AddVehicleViewModel listOfModelsByMake(int MakeId);
        Task<UpdateVehicleViewModel> GetVehicleToUpdate(int Id);
        Task<int> UpdateVehicle(UpdateVehicleViewModel model);
        public void DeleteVehicle(int Id);

    }
}
