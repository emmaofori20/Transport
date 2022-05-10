using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleRepository
    {
        public Task<List<VehicleListViewModel>> GetAllVehicles();
        public Task<VehicleDetailViewModel> GetVehicle(int Id);
        public Task<int> AddVehicle(AddVehicleViewModel vehicleModel);
        public Task<UpdateVehicleViewModel> GetVehicleForUpdate(int Id);
        public Task<int> UpdateVehicle(UpdateVehicleViewModel model);
        public void DeleteVehicle(int Id);

    }
}
