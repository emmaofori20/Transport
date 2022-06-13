using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly IRoutineMaintenanceActivityRepository routineMaintenanceActivityRepository;
        private readonly IRequestService requestService;
        private readonly ISparePartQuantityRepository sparePartQuantityRepository;
        private readonly IVehicleRoutineMaintenanceRepository vehicleRoutineMaintenanceRepository;
        private readonly IRoutneMaintenanceListRepository routneMaintenanceListRepository;

        public RoutineService(IRoutineMaintenanceActivityRepository routineMaintenanceActivityRepository, 
                                IRequestService requestService,
                                ISparePartQuantityRepository sparePartQuantityRepository,
                                IVehicleRoutineMaintenanceRepository vehicleRoutineMaintenanceRepository,
                                IRoutneMaintenanceListRepository routneMaintenanceListRepository)
        {
            this.routineMaintenanceActivityRepository = routineMaintenanceActivityRepository;
            this.requestService = requestService;
            this.sparePartQuantityRepository = sparePartQuantityRepository;
            this.vehicleRoutineMaintenanceRepository = vehicleRoutineMaintenanceRepository;
            this.routneMaintenanceListRepository = routneMaintenanceListRepository;
        }

        public void AddRoutineMaintenanceVehicle(RoutineMaintenanceVehicleViewModel model)
        {
            var RoutineMaintenance = vehicleRoutineMaintenanceRepository.AddRoutineRequest(model);

            for (int i = 0; i < model.RoutineActivity.Count; i++)
            {
               routneMaintenanceListRepository.AddRoutineMaintenanceLsit(model.RoutineActivity[i], RoutineMaintenance.VehicleRoutineMaintenanceId);
            }
        }

        public List<VehicleRoutineMaintenance> GetVehicleRoutineMaintenances()
        {
            return vehicleRoutineMaintenanceRepository.GetAllRoutineMaintenances();
        }

        public RoutineMaintenanceVehicleViewModel routineMaintenanceVehicle()
        {
            List<RoutineActivityCheck> activityCheck = new List<RoutineActivityCheck>();

            var routineActivities = routineMaintenanceActivityRepository.GetAllActivity();

            for (int i = 0; i < routineActivities.Count; i++)
            {
                RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                {
                    IsRequiredSparePart = false,
                    Isokay = false,
                    ActivityId = routineActivities[i].RoutineMaintenanceActivityId,
                    ActivityName = routineActivities[i].ActivityName
                };

                activityCheck.Add(routineActivityCheck);
            }

            RoutineMaintenanceVehicleViewModel routineMaintenanceVehicle = new RoutineMaintenanceVehicleViewModel() {
                AllVehicles = new SelectList(requestService
                                                    .GetAllVehicleMaintenanceRequest().Item2
                                                    .Select(s => new { VehicleId = s.VehicleId, RegistrationNumber = $"{s.RegistrationNumber}", ChasisNumber = $"{s.ChasisNumber}" }), "VehicleId", "RegistrationNumber", "ChasisNumber"),

                RoutineActivity = activityCheck,
                SparePartsUsed = new SelectList(sparePartQuantityRepository.GetSpareParts()
                                                                .Select(s=> new { SparePartId = s.SparePartId, SparePartName = $"{s.SparePart.SparePartName}" }), "SparePartId", "SparePartName")
            }; 

            return routineMaintenanceVehicle;
        }

        public RoutineMaintenanceVehicleViewModel ViewRoutineVehicleMaintenance(int RoutineId)
        {
            List<RoutineActivityCheck> activityCheck = new List<RoutineActivityCheck>();

            var RoutineMaintainanceList = vehicleRoutineMaintenanceRepository.GetRoutineMaintenance(RoutineId);

            ///////PREPARING LIST////////////////////
            for (int i = 0; i < RoutineMaintainanceList.Count; i++)
            {
                if ((bool)RoutineMaintainanceList[i].IsSparePartUsed)
                {
                    RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                    {
                        IsRequiredSparePart = true,
                        Isokay = true,
                        ActivityId = RoutineMaintainanceList[i].RoutineMaintenanceActivityId,
                        ActivityName = RoutineMaintainanceList[i].RoutineMaintenanceActivity.ActivityName,
                        Quantity = (double)RoutineMaintainanceList[i].Quantity,
                        SparePartName = RoutineMaintainanceList[i].SparePart.SparePartName
                    };

                    activityCheck.Add(routineActivityCheck);
                }
                else
                {
                    RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                    {
                        IsRequiredSparePart = false,
                        Isokay = true,
                        ActivityId = RoutineMaintainanceList[i].RoutineMaintenanceActivityId,
                        ActivityName = RoutineMaintainanceList[i].RoutineMaintenanceActivity.ActivityName
                    };

                    activityCheck.Add(routineActivityCheck);
                }
            }
            ///////PREPARING LIST////////////////////

            var OtherDetails = GetVehicleRoutineMaintenances().
                                            Where(x => x.VehicleRoutineMaintenanceId == RoutineId)
                                           .FirstOrDefault();
            RoutineMaintenanceVehicleViewModel routineMaintenanceVehicle = new RoutineMaintenanceVehicleViewModel()
            {
                RoutineId = RoutineId,
                RoutineActivity = activityCheck,
                RegistrationNumber = OtherDetails.Vehicle.RegistrationNumber,
                Date = OtherDetails.CreatedOn,
                CreatedBy = OtherDetails.CreatedBy
            };
            return routineMaintenanceVehicle;
        }
    }
}
