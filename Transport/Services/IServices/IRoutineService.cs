﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
    public interface IRoutineService
    {
        public RoutineMaintenanceVehicleViewModel routineMaintenanceVehicle();
        public VehicleRoutineMaintenance AddRoutineMaintenanceVehicle(RoutineMaintenanceVehicleViewModel model);
        public List<VehicleRoutineMaintenance> GetVehicleRoutineMaintenances();
        public RoutineMaintenanceVehicleViewModel ViewRoutineVehicleMaintenance(int RoutineId);
        public void EditRoutineMaintenanceVehicle(RoutineMaintenanceVehicleViewModel model);
        public void DeleteRoutineMaintenanceVehicle(int RoutineId);
        public bool CheckRoutineMaintenanceVehicleSpareParts(RoutineMaintenanceVehicleViewModel model);
    }
}
