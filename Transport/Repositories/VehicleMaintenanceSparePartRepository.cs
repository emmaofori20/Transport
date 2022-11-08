using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class VehicleMaintenanceSparePartRepository: IVehicleMaintenanceSparePartRepository
    {
        private readonly TransportDbContext _context;

        public VehicleMaintenanceSparePartRepository(TransportDbContext context)
        {
            _context = context;

        }

        public void AddVehicleMaintenanceSparePart(VehicleMaintananceSparepartViewModel sparePart, int ListId)
        {
            VehicleMaintenanceSparepart vehicleMaintenanceSparepart = new VehicleMaintenanceSparepart
            {
                Quantity =sparePart.Quantity,
                NameOfPart = sparePart.SparePartName,
                VehicleMaintenanceRequestId = ListId,
                Amount = (decimal)sparePart.Amount,
                CreatedBy= "Admin",
                CreatedOn= DateTime.Now
            };

            //_context.VehicleMaintenanceSpareparts.Add(vehicleMaintenanceSparepart);
            //_context.SaveChanges();
        }

        //public void DeleteAllVehicleMaintenanceSparepart(int ListId)
        //{
        //    //get all spare parts with that Id
        //    var results= GetList(ListId);

        //    foreach (var item in results)
        //    {
        //        //_context.VehicleMaintenanceSpareparts.Remove(item);
        //        //_context.SaveChanges();

        //    }
        //}

        //public List<VehicleMaintenanceSparepart> GetList(int Id)
        //{
        //    //var results = _context.VehicleMaintenanceSpareparts.Where(x => x.VehicleMaintenanceRequestId == Id).ToList();
        //    //return results;
        //}
    }
}
