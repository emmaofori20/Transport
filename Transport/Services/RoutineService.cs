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
        private readonly ISparePartService sparePartService;
        private readonly IVehicleRoutineMaintenanceRepository vehicleRoutineMaintenanceRepository;
        private readonly IRoutneMaintenanceListRepository routneMaintenanceListRepository;

        public RoutineService(IRoutineMaintenanceActivityRepository routineMaintenanceActivityRepository, 
                                IRequestService requestService,
                                ISparePartQuantityRepository sparePartQuantityRepository,
                                ISparePartService sparePartService,
                                IVehicleRoutineMaintenanceRepository vehicleRoutineMaintenanceRepository,
                                IRoutneMaintenanceListRepository routneMaintenanceListRepository)
        {
            this.routineMaintenanceActivityRepository = routineMaintenanceActivityRepository;
            this.requestService = requestService;
            this.sparePartQuantityRepository = sparePartQuantityRepository;
            this.sparePartService = sparePartService;
            this.vehicleRoutineMaintenanceRepository = vehicleRoutineMaintenanceRepository;
            this.routneMaintenanceListRepository = routneMaintenanceListRepository;
        }

        public VehicleRoutineMaintenance AddRoutineMaintenanceVehicle(RoutineMaintenanceVehicleViewModel model)
        {

                var RoutineMaintenance = vehicleRoutineMaintenanceRepository.AddRoutineRequest(model);
                for (int i = 0; i < model.RoutineActivity.Count; i++)
                {
                    routneMaintenanceListRepository.AddRoutineMaintenanceLsit(model.RoutineActivity[i], RoutineMaintenance.VehicleRoutineMaintenanceId,model.CreatedBy);
                }
                return RoutineMaintenance;

        }

        public bool CheckRoutineMaintenanceVehicleSpareParts(RoutineMaintenanceVehicleViewModel model)
        { 
            //CHECK TOTAL NUMBER OF A SPARE PART BEFORE PROCEDDING///
            var AllCurrentSpareParts = sparePartService.GetAllSpareParts().Item1;

            List<bool> checks = new List<bool>();

            for (int i = 0; i < model.RoutineActivity.Where(x => x.IsRequiredSparePart == true).Count(); i++)
            {
                //Checking if the spareparts are of the same ID and the quantity left is greater than the quantity requested
                bool query = AllCurrentSpareParts.Any(x => x.SparePartId == model.RoutineActivity[i].SparePartId
                                                   && x.QuantityLeft <= model.RoutineActivity[i].Quantity);
                checks.Add(query);
            }
            //CHECK TOTAL NUMBER OF A SPARE PART BEFORE PROCEDDING///
            return checks.Any(x=>x == true);/// if any of them is true then the code should not continue
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
                SparePartsUsed = new SelectList(sparePartService.GetAllSpareParts().Item1
                                                                .Select(s=> new { SparePartId = s.SparePartId, SparePartName = $"{s.SparePart.SparePartName}" }), "SparePartId", "SparePartName")
            }; 

            return routineMaintenanceVehicle;
        }

        public RoutineMaintenanceVehicleViewModel ViewRoutineVehicleMaintenance(int RoutineId)
        {
            List<RoutineActivityCheck> activityCheck = new List<RoutineActivityCheck>();

            var RoutineMaintainanceList = vehicleRoutineMaintenanceRepository.GetRoutineMaintenance(RoutineId);

            ///////PREPARING LIST FOR ROUTINE MAINTENANCE////////////////////
            for (int i = 0; i < RoutineMaintainanceList.Count; i++)
            {
                //checks if
                if ((bool)RoutineMaintainanceList[i].IsSparePartUsed && (bool)RoutineMaintainanceList[i].IsRoutineCheck)
                {
                    RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                    {
                        
                        IsRequiredSparePart = true,
                        Isokay = true,
                        ActivityId = RoutineMaintainanceList[i].RoutineMaintenanceActivityId,
                        ActivityName = RoutineMaintainanceList[i].RoutineMaintenanceActivity.ActivityName,
                        Quantity = (double)RoutineMaintainanceList[i].Quantity,
                        SparePartName = RoutineMaintainanceList[i].SparePart.SparePartName,
                        SparePartId = (int)RoutineMaintainanceList[i].SparePartId

                        
                    };

                    activityCheck.Add(routineActivityCheck);
                }
                else if((bool)RoutineMaintainanceList[i].IsRoutineCheck || (bool)RoutineMaintainanceList[i].IsSparePartUsed)
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
                else
                {
                    RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                    {
                        IsRequiredSparePart = false,
                        Isokay = false,
                        ActivityId = RoutineMaintainanceList[i].RoutineMaintenanceActivityId,
                        ActivityName = RoutineMaintainanceList[i].RoutineMaintenanceActivity.ActivityName
                    };

                    activityCheck.Add(routineActivityCheck);
                }
            }
            ///////PREPARING LIST FOR ROUTINE MAINTENANCE////////////////////

            var OtherDetails = GetVehicleRoutineMaintenances().
                                            Where(x => x.VehicleRoutineMaintenanceId == RoutineId)
                                           .FirstOrDefault();
            RoutineMaintenanceVehicleViewModel routineMaintenanceVehicle = new RoutineMaintenanceVehicleViewModel()
            {
                RoutineId = RoutineId,
                RoutineActivity = activityCheck,
                VehicleId = OtherDetails.Vehicle.VehicleId,
                RegistrationNumber = OtherDetails.Vehicle.RegistrationNumber,
                //incase of an edit, select list are prepopulated
                AllVehicles = new SelectList(requestService
                                                    .GetAllVehicleMaintenanceRequest().Item2
                                                    .Select(s => new { VehicleId = s.VehicleId, RegistrationNumber = $"{s.RegistrationNumber}", ChasisNumber = $"{s.ChasisNumber}" }), "VehicleId", "RegistrationNumber", "ChasisNumber"),
                Date = OtherDetails.CreatedOn,

                //incase of an edit, select list are prepopulated
                SparePartsUsed = new SelectList(sparePartService.GetAllSpareParts().Item1
                                                                .Select(s => new { SparePartId = s.SparePartId, SparePartName = $"{s.SparePart.SparePartName}" }), "SparePartId", "SparePartName"),
                CreatedBy = OtherDetails.CreatedBy
            };
            return routineMaintenanceVehicle;
        }

        public void EditRoutineMaintenanceVehicle(RoutineMaintenanceVehicleViewModel model)
        {

            //check vehicleId if has been changed
            vehicleRoutineMaintenanceRepository.EditRoutineMaintenanceRequest(model);

            //continue function when all is true
            for (int i = 0; i < model.RoutineActivity.Count; i++)
            {
                routneMaintenanceListRepository.EditRoutineMaintenanceList(model.RoutineActivity[i], model.RoutineId, model.CreatedBy);
            }
        }

        public bool CheckSparePartQuanityBeforeEdit(RoutineMaintenanceVehicleViewModel model)
        {
            //// getting previous routine maintenance data
            var routinemaintenance = ViewRoutineVehicleMaintenance(model.RoutineId);

            //Getting all current spareparts
            var AllCurrentSpareParts = sparePartService.GetAllSpareParts().Item1;
            List<bool> checks = new List<bool>();

            // Check if spareparts quantity has changed
            for (int i = 0; i < model.RoutineActivity.Count; i++)
            {
                //check if the activities are the same
                if (model.RoutineActivity[i] == routinemaintenance.RoutineActivity[i])
                {
                    //check if the previous spare part quantity is the same as the incoming spare part quantity
                    if (model.RoutineActivity[i].Quantity > routinemaintenance.RoutineActivity[i].Quantity)
                    {
                        //Checking if the spareparts are of the same ID and the quantity left is greater than the quantity requested
                        bool query = AllCurrentSpareParts.Any(x => x.SparePartId == model.RoutineActivity[i].SparePartId
                                                           && x.QuantityLeft <= model.RoutineActivity[i].Quantity - routinemaintenance.RoutineActivity[i].Quantity);
                        checks.Add(query);

                    }
                    else if (model.RoutineActivity[i].Quantity < routinemaintenance.RoutineActivity[i].Quantity)
                    {
                        //Checking if the spareparts are of the same ID and the quantity left is less than the quantity requested
                        bool query = AllCurrentSpareParts.Any(x => x.SparePartId == model.RoutineActivity[i].SparePartId
                                                           && x.QuantityLeft <= routinemaintenance.RoutineActivity[i].Quantity - model.RoutineActivity[i].Quantity);
                        checks.Add(query);

                    }
                    else
                    {
                        //Checking if the spareparts are of the same ID and the quantity left is equal the quantity requested
                        bool query = AllCurrentSpareParts.Any(x => x.SparePartId == model.RoutineActivity[i].SparePartId
                                                           && x.QuantityLeft == model.RoutineActivity[i].Quantity);
                        checks.Add(query);

                    }

                }

            }

            return checks.Any(x => x == true);/// if any of them is true then the code should not continue
        }

        public void SubstractAndAddSparePartQuantity(RoutineMaintenanceVehicleViewModel model)
        {
            //// getting previous routine maintenance data
            var routinemaintenance = ViewRoutineVehicleMaintenance(model.RoutineId);

            //Getting all current spareparts
            for (int i = 0; i < model.RoutineActivity.Count; i++)
            {
                //check if the activities are the same and id sparepart required ticked
                if (model.RoutineActivity[i].ActivityId == routinemaintenance.RoutineActivity[i].ActivityId && model.RoutineActivity[i].IsRequiredSparePart == true)
                {
                    //check if the previous spare part quantity is the same as the incoming spare part quantity
                    if (model.RoutineActivity[i].Quantity > routinemaintenance.RoutineActivity[i].Quantity)
                    {
                        RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                        {
                            ActivityId = model.RoutineActivity[i].ActivityId,
                            ActivityName = model.RoutineActivity[i].ActivityName,
                            Isokay = model.RoutineActivity[i].Isokay,
                            IsRequiredSparePart = model.RoutineActivity[i].IsRequiredSparePart,
                            SparePartId = model.RoutineActivity[i].SparePartId,
                            SparePartName = model.RoutineActivity[i].SparePartName,
                            Quantity = model.RoutineActivity[i].Quantity-routinemaintenance.RoutineActivity[i].Quantity 
                        };
                        sparePartQuantityRepository.SubtractSparePartQuantityAfterRoutineMaintenanceActivity(routineActivityCheck, model.CreatedBy);

                    }
                    else if (model.RoutineActivity[i].Quantity < routinemaintenance.RoutineActivity[i].Quantity)
                    {
                        RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                        {
                            ActivityId = model.RoutineActivity[i].ActivityId,
                            ActivityName = model.RoutineActivity[i].ActivityName,
                            Isokay = model.RoutineActivity[i].Isokay,
                            IsRequiredSparePart = model.RoutineActivity[i].IsRequiredSparePart,
                            SparePartId = model.RoutineActivity[i].SparePartId,
                            SparePartName = model.RoutineActivity[i].SparePartName,
                            Quantity = routinemaintenance.RoutineActivity[i].Quantity - model.RoutineActivity[i].Quantity
                        };
                        sparePartQuantityRepository.AddSparePartQuantityAfterRoutineMaintenanceActivity(routineActivityCheck, model.CreatedBy);
                    }
                    else
                    {
                      

                    }

                }else 
                {
                    RoutineActivityCheck routineActivityCheck = new RoutineActivityCheck()
                    {
                        ActivityId = model.RoutineActivity[i].ActivityId,
                        ActivityName = model.RoutineActivity[i].ActivityName,
                        Isokay = model.RoutineActivity[i].Isokay,
                        IsRequiredSparePart = model.RoutineActivity[i].IsRequiredSparePart,
                        SparePartId = model.RoutineActivity[i].SparePartId,
                        SparePartName = model.RoutineActivity[i].SparePartName,
                        Quantity = routinemaintenance.RoutineActivity[i].Quantity 
                    };
                    sparePartQuantityRepository.AddSparePartQuantityAfterRoutineMaintenanceActivity(routineActivityCheck, model.CreatedBy);
                }
                

            }

        }
        public void DeleteRoutineMaintenanceVehicle(int RoutineId, string Issuer)
        {
            vehicleRoutineMaintenanceRepository.DeleteRoutineMaintenanceRequest(RoutineId, Issuer);
        }
    }
}
