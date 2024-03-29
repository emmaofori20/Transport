﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleMaintenanceSparePartRepository
    {
        public void AddVehicleMaintenanceSparePart(VehicleMaintananceSparepartViewModel sparePart, int ListId);

        public List<VehicleMaintenanceSparepart> GetList(int Id);

        public void DeleteAllVehicleMaintenanceSparepart( int ListId);
    }
}
